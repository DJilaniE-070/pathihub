using System.Net;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

using PathiHub;
public static class OMDBAddMovie
{

public static string GetApiResponse(string apiUrl)
    {
        using var client = new WebClient();
        return client.DownloadString(apiUrl);
    }

public static void AddMoviePresentationWebb(string Header)
    {
        Helpers.PrintStringToColor(Header,"yellow");
        Helpers.CharLine('-',80);

        Helpers.PrintStringToColor("\n\nWhat movie do You want to add: ","blue");

        string websearch = Helpers.Color("yellow").Replace(" ","_").ToLower();
        string apiKey = MovieOptionsLogic.GetApiKey();

        string apiUrl = $"http://www.omdbapi.com/?s={websearch}&apikey={apiKey}";

        string WebSearch;
        List<Movie> movies = new();
        // IF wifi goes down mid search then return to add movie option
            try
            {
                string response = GetApiResponse(apiUrl);
                WebSearch = response;
            }
            catch (Exception)
            {
                Console.WriteLine($"An error occurred: No Internet");
                Thread.Sleep(600);
                Console.Clear();
                MovieOptionPresentation.AddMoviePresentationWebbOption();
                return;
            }

        if (!MovieOptionsLogic.CheckSearch(WebSearch))
        {
            Helpers.PrintStringToColor("Movie not found Press ENTER to try again","red");
            Helpers.Color("white");
            Console.Clear();
            AddMoviePresentationWebb(Header);
            return;
        }

        JObject jsonObject = JObject.Parse(WebSearch);
        JArray SearchResults = (JArray)jsonObject["Search"];
        Console.WriteLine("Please wait a moment");

        foreach (JObject result in SearchResults)
        {
            try
            {
                string imdbID = result["imdbID"].ToString();

                string IMDBurl = $"http://www.omdbapi.com/?i={imdbID}&apikey={apiKey}";

                string IMDBresponse = GetApiResponse(IMDBurl);
    
                Movie movie = OMDBMovieMaker(IMDBresponse);
                movies.Add(movie);
            }
            catch (Exception)
            {
                Helpers.PrintStringToColor($"An error occurred /n/nPress ENTER to try again if it continue to give errors try searching for something else or Restart the program","red");
                Thread.Sleep(600);
                Helpers.Color("Yellow");
                Console.Clear();
                MovieOptionPresentation.AddMoviePresentationWebbOption();
                return;
            }


        }

        Thread.Sleep(600);
        Console.Clear();
        List<string> ColomnNames = new(){"MovieTitle", "ReleaseYear",
        "Director", "Genre", "Rating"};
        Movie SelectedMovie = (Movie)ObjCatalogePrinter.TabelPrinter<Movie>(Header, movies,ColomnNames);
        
        MoviesAccess moviesAccess = new();
        if(moviesAccess.LoadFromJson())
        {
            MovieOptionsLogic.InitializeMovies(moviesAccess.GetItemList());
            if (MovieOptionsLogic.AddMovie(SelectedMovie) != true)
            {
                Helpers.PrintStringToColor("\nMovie already exits\nYou will be redirected to the Menu","red");
                Thread.Sleep(1000);
                ManagerMenu.Start();

                
            }
            else
            {
                ScheduleOption option = new(true);
                option.Start();

                List<Schedule>schedules = option.SelectedSchedules;
                List<int> Auditoriums = option.SelectedAuds;
                List<string> Times = new();

                foreach (Schedule schedule in schedules)
                {
                    Times.Add(schedule.Scheduled);
                }

                if (schedules.Count > 0 && Times.Count > 0)
                {
                    SelectedMovie.Scheduled = Times;
                    SelectedMovie.Auditorium = Auditoriums;

                }
                else
                {
                    SelectedMovie.Scheduled =  new List<string> { "X" };
                    SelectedMovie.Auditorium =  new List<int> {};
                }
                Helpers.PrintStringToColor($"\n+ {SelectedMovie.MovieTitle}  has been added\n","green");
                moviesAccess.SaveToJson();

                List<Movie> FilteredMovies = MovieOptionsLogic.FilterMovies();

                MovieToAuditoriumLogic logic = new();
                logic.initializerAuditorium(FilteredMovies);
            }

            Console.WriteLine("Press ENTER to continue");
            Helpers.Color("Yellow");
            ManagerMenu.Start();


        }
        else
        {
            Helpers.PrintStringToColor("Movies not found. No movies loaded.\n", "red");
            Console.WriteLine("Press ENTER to continue");
            Helpers.Color("Yellow");
            ManagerMenu.Start();
        }

        }


        // This line will choose the movie i need to convert the list of movies and give ColomnNames to choose from browser movies
    

        public static Movie OMDBMovieMaker(string OMDBMovie)
        {
            JObject movieJson = JObject.Parse(OMDBMovie);

            
            Movie movie = new Movie
            {
                MovieTitle = (string)movieJson["Title"], 
                ReleaseYear = GetIntOrZero((string)movieJson["Year"]),
                ReleaseDate = (string)movieJson["Released"],
                Genre = ((string)movieJson["Genre"]).Split(',').ToList(),
                Actors = ((string)movieJson["Actors"]).Split(',').ToList(),
                Directors = (string)movieJson["Director"],
                Writers = ((string)movieJson["Writer"]).Split(',').ToList(),
                Plot = (string)movieJson["Plot"],
                Rating = GetDoubleOrZero((string)movieJson["imdbRating"]),
                RuntimeMinutes = GetIntOrZero(((string)movieJson["Runtime"]).Split(" ")[0]), 
                Languages = (string)movieJson["Language"],
                Countrys = (string)movieJson["Country"],
                Awards = ((string)movieJson["Awards"]).Split(',').ToList(),
                Poster = (string)movieJson["Poster"],
                // Hier een functie to assign to the correct day and time and auditorium
                Auditorium = new List<int>{0}, // Set the default value, you may need to change this based on your logic
                // Hierzo een functie die direct een movieschedule hieraan linkt
                Scheduled = new List<string>{""},
            };
            return movie;

        }

        private static double GetDoubleOrZero(string value)
        {
            if (value != null && value.ToString() != "N/A")
            {
                return Convert.ToDouble(value);
            }
            return 0.0;
        }
        // WTF man normale - kan hij niet detecten van de value
        // 
    private static int GetIntOrZero(string value)
    {
        if (value != null && value.ToString() != "N/A")
        {
            string valueCorrected = value.Replace("\u2013", "-");

            if (valueCorrected.Contains("-"))
            {
                string[] parts = valueCorrected.Split("-");
                if (int.TryParse(parts[0], out int result))
                {
                    return result;
                }
            }
            else
            {
                if (int.TryParse(valueCorrected, out int result))
                {
                    return result;
                }
            }
        }

        return 0;
    }
}

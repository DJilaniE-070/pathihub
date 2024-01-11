using System.Security.Cryptography.X509Certificates;

public class ChooseFromSchedule
{

    public int Auditorium;
    public static string HeaderSched = @"
 _____      _              _       _           
/  ___|    | |            | |     | |          
\ `--.  ___| |__   ___  __| |_   _| | ___  ___ 
 `--. \/ __| '_ \ / _ \/ _` | | | | |/ _ \/ __|
/\__/ / (__| | | |  __/ (_| | |_| | |  __/\__ \
\____/ \___|_| |_|\___|\__,_|\__,_|_|\___||___/";


    public static string HeaderMovies = @"
___  ___           _           
|  \/  |          (_)          
| .  . | _____   ___  ___  ___ 
| |\/| |/ _ \ \ / / |/ _ \/ __|
| |  | | (_) \ V /| |  __/\__ \
\_|  |_/\___/ \_/ |_|\___||___/";
    private static List<string> ColomnNameSchedule = new(){"Scheduled", "MovieTitle",
        "Directors", "ReleaseYear", " "};

    private static List<string> ColomnNamesMovie = new(){"MovieTitle", "ReleaseYear",
    "Directors", "Genre", "Rating"};
    private static List<Schedule> schedule1;
    private static List<Schedule> schedule2;
    private static List<Schedule> schedule3;

    private static List<Movie> movies = new();
    MovieToAuditoriumLogic logic = new();
    private static Schedule SelectedSchedule;
    private static ScheduleAcces acces1;
    private static ScheduleAcces acces2;
    private static ScheduleAcces acces3;
    private static MoviesAccess moviesAccess;
    private void Select()
    {

        acces1 = new(1);
        acces2 = new(2);
        acces3 = new(3);
        moviesAccess = new();
        


        if (acces1.LoadFromJson() && acces2.LoadFromJson() && acces3.LoadFromJson()&& moviesAccess.LoadFromJson())
        {
            
            schedule1 = acces1.GetItemList();
            schedule2 = acces2.GetItemList();
            schedule3 = acces3.GetItemList();
            movies = moviesAccess.GetItemList();
            SelectedSchedule = SelectSched();

        }
    }


    public void start()
    {
            Select();
            Movie foundMovie = movies.FirstOrDefault(movie =>
            movie.MovieTitle == SelectedSchedule.MovieTitle &&
            movie.Directors == SelectedSchedule.Directors &&
            movie.ReleaseYear == Convert.ToInt32(SelectedSchedule.ReleaseYear));

            if (foundMovie == null)
            {
                Helpers.PrintStringToColor("Error Occurred You will be sent to the main menu","red");
                Thread.Sleep(1200);
                start();
            }
            else
            {
                    MovieSchedule.SelectedMovie = foundMovie;
                    MovieSchedule.Selectedauditorium = Auditorium;
                    MovieSchedule.SelectedSchedule = SelectedSchedule.Scheduled;
                    logic.Connector(MovieSchedule.SelectedMovie);
            }
    }
    public Schedule? SelectSched()
    {
        Schedule SelectedSchedule = null;
        while (SelectedSchedule == null)
        {
            ConsoleKeyInfo key;
            Console.Clear();
            Helpers.PrintStringToColor(HeaderSched,"yellow");
            Helpers.PrintStringToColor("\nPress [1] Auditorium 1 / [2] for Auditorium 2 / [3] for Auditorium 3 or BACKSPACE to return and choose no schedule" , "cyan");

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Auditorium = 1;
                    SelectedSchedule = (Schedule)ObjCatalogePrinter.TabelPrinter<Schedule>(HeaderSched,schedule1 , ColomnNameSchedule);
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Auditorium = 2;
                    SelectedSchedule = (Schedule)ObjCatalogePrinter.TabelPrinter<Schedule>(HeaderSched,schedule2 , ColomnNameSchedule);
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    Auditorium = 3;
                    SelectedSchedule =  (Schedule)ObjCatalogePrinter.TabelPrinter<Schedule>(HeaderSched, schedule3 , ColomnNameSchedule);
                    break; 
                case ConsoleKey.Backspace:
                    Helpers.BackToYourMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
            Console.Clear();

        }
        return SelectedSchedule;

    }

    public void AddMovieToSchedule()
    {
        Select();
 
        if (SelectedSchedule == null)
        {
            Helpers.PathiHubPrint();
            Helpers.PrintStringToColor("Error: The SelectedSchedule is null. Please select a schedule first.\nPress Enter to continue", "Red");
            Helpers.Color("yellow");
            AddMovieToSchedule();
        }

        if (SelectedSchedule.MovieTitle != "N/A" && SelectedSchedule.Directors != "N/A" && SelectedSchedule.ReleaseYear != "N/A")
        {
            Helpers.PathiHubPrint();
            Helpers.PrintStringToColor("The SelectedSchedule is already assigned to a movie. First, clear the schedule, then assign your movie or choose another schedule time.\nPress Enter to continue", "Red");
            Helpers.Color("yellow");
            AddMovieToSchedule();

        }

        // SelectedSchedule day, time, etc.
        Movie selectedMovie = (Movie)ObjCatalogePrinter.TabelPrinter<Movie>(HeaderMovies, movies, ColomnNamesMovie);

        if (selectedMovie != null)
        {
            SelectedSchedule.MovieTitle = selectedMovie.MovieTitle;
            SelectedSchedule.Directors = selectedMovie.Directors;
            SelectedSchedule.ReleaseYear = Convert.ToString(selectedMovie.ReleaseYear);

            if (!selectedMovie.Auditorium.Contains(Auditorium) || selectedMovie.Auditorium.Count == 0)
            {
                selectedMovie.Auditorium.Add(Auditorium);
            }
            if (!selectedMovie.Scheduled.Contains(SelectedSchedule.Scheduled) || selectedMovie.Scheduled.Count == 0)
            {
                selectedMovie.Scheduled.Add(SelectedSchedule.Scheduled);
            }

            // Check if the Auditorium is valid before saving
            if (Auditorium == 1 || Auditorium == 2 || Auditorium == 3)
            {
                if (Auditorium == 1) acces1.SaveToJson();
                else if (Auditorium == 2) acces2.SaveToJson();
                else if (Auditorium == 3) acces3.SaveToJson();
                moviesAccess.SaveToJson();

            }
        }
        Console.Clear();
        Helpers.PathiHubPrintLogo();
        Helpers.PrintStringToColor($"The movie {selectedMovie.MovieTitle} has been added to Auditorium {Auditorium} {SelectedSchedule.Scheduled}\nPress enter to go to Your menu","green");
        Helpers.Color("white");
        Helpers.BackToYourMenu();
    }
    public void RemoveMovieFromSchedule()
    {
        Select();
 
        if (SelectedSchedule == null)
        {
            Helpers.PathiHubPrint();
            Helpers.PrintStringToColor("Error: The SelectedSchedule is null. Please select a schedule first.\nPress Enter to continue", "Red");
            Helpers.Color("yellow");
            RemoveMovieFromSchedule();
        }

        if (SelectedSchedule.MovieTitle == "N/A" && SelectedSchedule.Directors == "N/A" && SelectedSchedule.ReleaseYear == "N/A")
        {
            Helpers.PathiHubPrint();
            Helpers.PrintStringToColor("The SelectedSchedule is already clear. Choose another schedule time to remove.\nPress Enter to continue", "Red");
            Helpers.Color("yellow");
            RemoveMovieFromSchedule();
        }

        // SelectedSchedule day, time, etc.
          Movie selectedMovie = movies.FirstOrDefault(movie =>
            movie.MovieTitle.ToLower() == SelectedSchedule.MovieTitle.ToLower() &&
            movie.Directors.ToLower() == SelectedSchedule.Directors.ToLower() &&
            movie.ReleaseYear == Convert.ToInt32(SelectedSchedule.ReleaseYear));


        if (selectedMovie != null)
        {
            // reset waarden
            SelectedSchedule.MovieTitle = "N/A";
            SelectedSchedule.Directors = "N/A";
            SelectedSchedule.ReleaseYear = "N/A";
            SelectedSchedule.StoredAuditorium = null;
            // verwijder scheduled
            selectedMovie.Scheduled.Remove(SelectedSchedule.Scheduled);


            selectedMovie.Auditorium = new();
            if (selectedMovie.Scheduled.Count == 0)
            {
            if (Auditorium == 1 || Auditorium == 2 || Auditorium == 3)
            {
                if (Auditorium == 1) acces1.SaveToJson();
                else if (Auditorium == 2) acces2.SaveToJson();
                else if (Auditorium == 3) acces3.SaveToJson();


                moviesAccess.SaveToJson();

            }
            }
            foreach(string schedulename in selectedMovie.Scheduled)
            {
                 string[] components = schedulename.Split('/');
                if (components.Length == 3 && components[2].StartsWith("Aud"))
                {
                    string auditoriumlet = components[2].Substring(3);

                    if (int.TryParse(auditoriumlet, out int auditorium))
                    {
                        // Check if the auditorium is not already in the set, then add it
                        if (!selectedMovie.Auditorium.Contains(auditorium) || selectedMovie.Auditorium.Count == 0)
                        {
                            selectedMovie.Auditorium.Add(auditorium);
                        }
                    }
            }
            // Check if the Auditorium is valid before saving
            if (Auditorium == 1 || Auditorium == 2 || Auditorium == 3)
            {
                if (Auditorium == 1) acces1.SaveToJson();
                else if (Auditorium == 2) acces2.SaveToJson();
                else if (Auditorium == 3) acces3.SaveToJson();


                moviesAccess.SaveToJson();

            }
        }
        Helpers.PathiHubPrintLogo();
        Helpers.PrintStringToColor($"The movie {selectedMovie.MovieTitle} has been removed from Auditorium {Auditorium} {SelectedSchedule.Scheduled}\nPress enter to go to Your menu","green");
        Helpers.Color("white");
        Helpers.BackToYourMenu();
    }
    }
}
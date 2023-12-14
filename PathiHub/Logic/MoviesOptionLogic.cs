using System.Net.Security;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

public class MovieOptionsLogic
{
    public static List<Movie> movies = new List<Movie>();

    public static string GetApiKey()
    {
        // Example: Use environment variable to store the API key
        string apiKey = Environment.GetEnvironmentVariable("MY_API_KEY");

        // If environment variable is not set, prompt user to enter the API key
        if (string.IsNullOrEmpty(apiKey))
        {
            apiKey = "761d0214";

            // You can save the entered key to an environment variable for subsequent runs
            Environment.SetEnvironmentVariable("MY_API_KEY", apiKey);
        }

        return apiKey;
    }
    public static void InitializeMovies (List<Movie> LOM)
    {
        movies = LOM;
    }

    public static bool CheckWifi()
    {
        if (NetworkInterface.GetIsNetworkAvailable())
        {
            return true;
        }
        return false;

    }

    public static bool CheckSearch(string searchterm)
    {
        if (searchterm.Contains("\"Response\":\"False\""))
        {
            return false;
        }
        return true;

    }

    public static bool AddMovie(Movie Movie)
    {
        bool movieExists = false;
        foreach (Movie movie in movies)
        {
            if (string.Equals(movie.MovieTitle, Movie.MovieTitle) &&
                string.Equals(movie.Directors, Movie.Directors))
            {
                // Movie already exists
                movieExists = true;
                break;
            }
        }

        if (movieExists == true)
        {
            return false; 
            //return false because movie exist and the movie has not been added to the json list
        }
        else
        {
            // Movie doesn't exist, proceed to add it to the list
            movies.Add(Movie);
            return true;
        }
    }

    public static bool RemoveMovie(string movieTitle,string Directors)
    {
        Movie movieToRemove = null;

        foreach (Movie movie in movies)
        {
            //search based on title and director
            if (string.Equals(movie.MovieTitle, movieTitle) &&
                string.Equals(movie.Directors, Directors))
            {
                movieToRemove = movie;
                break;
            }
        }

        if (movieToRemove != null)
        {
            movies.Remove(movieToRemove);
            return true;
        }
        else
        {
            return false;
        }
    }
    public static List<Movie> FilterMovies()
    {
        List<Movie> filteredMovies = new List<Movie>();

        if (movies == null)
        {
            Console.WriteLine("Movies collection is null.");
            return null;
        }

        foreach (Movie movie in MovieOptionsLogic.movies)
        {
            if (IsValidMovie(movie))
            {
                filteredMovies.Add(movie);
            }
        }
        
    return filteredMovies;      
    }

    private static bool IsValidMovie(Movie movie)
    {
        if (movie.Auditorium != null)
        {
            foreach (int num in movie.Auditorium)
            {
                if (num <= 0 && num >= 4)
                {
                    return false;
                }
            }
            return true;
        }

        return false;
    }
}

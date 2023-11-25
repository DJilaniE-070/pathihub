using System.Net.Security;
using Newtonsoft.Json;
public class MovieOptions
{
    public static List<Movie> movies = new List<Movie>();
    public MovieOptions(List<Movie> movielist)
    {
        movies = movielist;
    }

    public bool AddMovie(Movie Movie)
    {
        bool movieExists = false;
        foreach (Movie movie in movies)
        {
            if (string.Equals(movie.MovieTitle, Movie.MovieTitle) &&
                string.Equals(movie.Director, Movie.Director))
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

    public bool RemoveMovie(string movieTitle,string Director)
    {
        Movie movieToRemove = null;

        foreach (Movie movie in movies)
        {
            //search based on title and director
            if (string.Equals(movie.MovieTitle, movieTitle) &&
                string.Equals(movie.Director, Director))
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
}
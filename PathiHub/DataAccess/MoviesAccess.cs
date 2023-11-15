public class MoviesAccess : JsonFileAccess<Movie>
{
    public MoviesAccess() : base("Movies.json"){}
}
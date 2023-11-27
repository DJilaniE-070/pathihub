namespace PathiHub
{
    
}
public class PromotionMovieAccess : JsonFileAccess<Movie>
{
    public PromotionMovieAccess() : base("PromotionMovies.json") { }
    
    // public Movie GetPromotionMovie(string movieTitle)
    // {
    //     return GetItemList().FirstOrDefault(movie => movie.MovieTitle == movieTitle);
    // }
}
namespace PathiHub.tests;

[TestClass]
public class MoviesOptionLogicTests
{
    private Movie movie;
    private List<Movie> movies;
    
    [TestInitialize]
    public void Initialize()
    {
        movies = new ();
        movie = new() { MovieTitle = "MovieTitle", Director = "Director" };
        movies.Add(movie);
    }
    
    [TestMethod]
    public void TestAddMovie()
    {
        movie = new Movie() { MovieTitle = "test", Director = "test" };
        movies.Add(movie);
        Assert.AreEqual(2, movies.Count);
        Assert.AreEqual("MovieTitle", movies[0].MovieTitle);
        Assert.AreEqual("Director", movies[0].Director);
    }
    
    [TestMethod]
    public void TestRemoveMovie()
    {
        int count = movies.Count;
        movies.Remove(movie);
        Assert.AreEqual(count - 1, movies.Count);
    }
}
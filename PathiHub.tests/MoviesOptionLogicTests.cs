namespace PathiHub.tests;

[TestClass]
public class MoviesOptionLogicTests
{
    private Movie movie;
    private List<Movie> movies; 
    
    [TestInitialize]
    public void Initialize()
    {
        movies = MovieOptionsLogic.movies;
    }
    
    [TestMethod]
    public void TestAddMovie()
    {
        int count = movies.Count;
        movie = new Movie() { MovieTitle = "test", Directors = "test" };
        movies.Add(movie);
        Assert.AreEqual(count + 1, movies.Count);
        Assert.AreEqual("test", movies.Last().MovieTitle);
        Assert.AreEqual("test", movies.Last().Directors);
    }
    
    [TestMethod]
    public void TestRemoveMovie()
    {
        int count = movies.Count;
        movies.Remove(movies.Last());
        Assert.AreEqual(count - 1, movies.Count);
    }
}
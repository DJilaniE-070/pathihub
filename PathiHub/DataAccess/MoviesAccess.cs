using Newtonsoft.Json;

public class MoviesAcces
{

    public List<Movie> movies = new List<Movie>();
    
    public void SaveMoviesToJson()
    {
        string filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/Movies.json"));
        string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public bool LoadMoviesFromJson()
    {
        string filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/Movies.json"));
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            return true;
        }
        else
        {
            return false;
        }
    }
}
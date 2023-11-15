using Newtonsoft.Json;

public class MoviesAcces
{

    public List<Movie> Movies { get; set; } = new List<Movie>();
    
    public void SaveMoviesToJson()
    {
        string filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/Movies.json"));
        string json = JsonConvert.SerializeObject(Movies, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public bool LoadMoviesFromJson()
    {
        string filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/Movies.json"));
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            return true;
        }
        else
        {
            return false;
        }
    }
}
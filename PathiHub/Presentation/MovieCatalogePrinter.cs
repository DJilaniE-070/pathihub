using System.Text.Json;
using Newtonsoft.Json;

public class MovieCatalogePrinter
{
    public static void TabelPrinter()
    {
        MoviesAcces acces = new MoviesAcces();
        if (acces.LoadMoviesFromJson() == true)
        {
            // Hieronder staat een voorbeeld van hoe je de JSON-data kunt lezen uit een bestand met de naam "movies.json"
            string jsonFilePath = @"DataSources/Movies.json"; // Zorg ervoor dat je het juiste pad naar je JSON-bestand opgeeft

            // Lees de JSON-data uit het bestand
            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);

            // Deserialiseer de JSON naar een lijst van Movie-objecten
            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonContent);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("{0,-20} | {1,-15} | {2,-25} | {3,-30} | {4,-10}", "Movie Title", "Release Year",
                "Director", "Genre", "Rating");
            Console.WriteLine(new string('-', 110));

            // Gegevens weergeven met verticale lijnen
            foreach (var movie in movies)
            {
                Console.WriteLine("{0,-20} | {1,-15} | {2,-25} | {3,-30} | {4,-10}", movie.MovieTitle,
                    movie.ReleaseYear, movie.Director, string.Join(", ", movie.Genre), movie.Rating);
            }
        }
    }

}
    

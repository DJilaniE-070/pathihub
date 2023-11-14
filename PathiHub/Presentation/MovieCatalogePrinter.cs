using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class MovieCatalogePrinter
{
    private static int selectedMovieIndex = 0;

    public static void TabelPrinter()
    {
        MoviesAcces acces = new MoviesAcces();
        if (acces.LoadMoviesFromJson() == true)
        {
            
            
            string jsonFilePath = @"DataSources/Movies.json"; // Zorg ervoor dat je het juiste pad naar je JSON-bestand opgeeft

            // Lees de JSON-data uit het bestand
            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);

            // Deserialiseer de JSON naar een lijst van Movie-objecten
            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonContent);

            // Teken de tabel met films
            DrawMovieTable(movies);

            // Wacht op invoer van de gebruiker
            ConsoleKeyInfo key;
            do
            {
                
                
                key = Console.ReadKey();

                // Pas de index van de geselecteerde film aan op basis van de pijltjestoetsen
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedMovieIndex = (selectedMovieIndex - 1 + movies.Count) % movies.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedMovieIndex = (selectedMovieIndex + 1) % movies.Count;
                        break;
                }

                // Teken de tabel met films (opnieuw) om de geselecteerde film te markeren
                Console.Clear();
                DrawMovieTable(movies);

            } while (key.Key != ConsoleKey.Enter);

            // Nu heb je toegang tot de geselecteerde film in de "movies" lijst
            
            
            Console.Clear();
            Console.WriteLine($"you have selected the mocie: '{movies[selectedMovieIndex].MovieTitle}'.");
            Console.ReadLine(); // Voeg deze regel toe om het programma niet onmiddellijk te sluiten
        }
    }

    private static void DrawMovieTable(List<Movie> movies)
    {
        Console.WriteLine(@"

___  ___           _        _____       _        _                  
|  \/  |          (_)      /  __ \     | |      | |                 
| .  . | _____   ___  ___  | /  \/ __ _| |_ __ _| | ___   __ _  
| |\/| |/ _ \ \ / / |/ _ \ | |    / _` | __/ _` | |/ _ \ / _` |
| |  | | (_) \ V /| |  __/ | \__/\ (_| | || (_| | | (_) | (_| |
\_|  |_/\___/ \_/ |_|\___|  \____/\__,_|\__\__,_|_|\___/ \__, |
                                                          __/ |     
                                                         |___/     
");

        Helpers.StringLine(80);
        Console.WriteLine("This our movie Catalog");
        Helpers.StringLine(80);
        Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
        
        Console.WriteLine("{0,-20} | {1,-15} | {2,-25} | {3,-30} | {4,-10}", "Movie Title", "Release Year",
            "Director", "Genre", "Rating");
        
        Console.WriteLine(new string('-', 110));

        // Weergave van films met markering voor de geselecteerde film
        //Maak een functie max length voor de maximale lengte die word gebruikt bij de tabel
        for (int i = 0; i < movies.Count; i++)
        {
            if (i == selectedMovieIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine("{0,-20} | {1,-15} | {2,-25} | {3,-30} | {4,-10}", movies[i].MovieTitle,
                movies[i].ReleaseYear, movies[i].Director, string.Join(", ", movies[i].Genre), movies[i].Rating);

            Console.ResetColor();
        }
    }
}

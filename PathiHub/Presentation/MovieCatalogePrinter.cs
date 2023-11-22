using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class MovieCatalogePrinter
{
    private static int selectedMovieIndex = 0;


    public static Movie TabelPrinter(MoviesAccess access)
    {
        if (access.LoadFromJson() == true)
        {   
            List<Movie> movies = access.GetItemList();
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
            
            Console.WriteLine($"\nyou have selected the movie: '{movies[selectedMovieIndex].MovieTitle}'.");
            Thread.Sleep(500);
            DiscriptionPrinter.DrawBox(movies[selectedMovieIndex]);
            Thread.Sleep(100000);
            
            return movies[selectedMovieIndex];
            
        }

        return null;
    }

    public static void DrawMovieTable(List<Movie> movies)
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
        
        Helpers.CharLine('-' ,80);
        Console.WriteLine("This our movie Catalog");
        Helpers.CharLine('-' ,80);
        Console.WriteLine("\n\n\n\n");

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

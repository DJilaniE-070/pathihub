using System;
using System.Collections.Generic;
using System.Threading;

// Deze methode is eigenlijk alleen bedoeld voor de gebruikers
public class MovieCatalogePrinter
{
    private static int selectedMovieIndex = 0;
    // private static bool PressedEnter = false;

    public static Movie TabelPrinter(MoviesAccess access)
    {
        if (access.LoadFromJson() == true)
        {
            // List<Movie> movies = access.GetItemList(); dit is alle movies
            List<Movie> Movies = access.GetItemList();
            MovieOptionsLogic.InitializeMovies(Movies);
            List<Movie> movies = MovieOptionsLogic.FilterMovies();
            // de bovenstaande 3 regels zijn om de movies te sorteren
            // hieronder is voor de schedule json correct afgesteld te zijn op de films
            MovieToAuditoriumLogic logic = new();
            
            logic.initializerAuditorium(movies);

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
                    case ConsoleKey.Backspace:
                        Helpers.BackToYourMenu();
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.Escape:
                        Helpers.MainMenu();
                        break;

                }

                // Clear the console before redrawing the table
                Console.Clear();

                // Teken de tabel met films (opnieuw) om de geselecteerde film te markeren
                DrawMovieTable(movies);

                // Toon de plot van de geselecteerde film
                ShowSelectedMoviePlot(movies[selectedMovieIndex]);

            } while (key.Key != ConsoleKey.Enter);

            // Nu heb je toegang tot de geselecteerde film in de "movies" lijst
            Console.WriteLine($"\nYou have selected the movie: '{movies[selectedMovieIndex].MovieTitle}'.");
            Thread.Sleep(500);
            MovieSchedule.SelectedMovie = movies[selectedMovieIndex];
            // Choose auditorium
            MovieSchedule.ChooseAuditorium();
            // Choose time
             //Hier komt later nog een check die kijkt naar de staat van de inlog waardoor MovieCatalogePrinterManagerVersion kan worden verwijderd
            logic.Connector(MovieSchedule.SelectedMovie);
            Thread.Sleep(2000); // Optional delay
           
            return movies[selectedMovieIndex];
        }

        return null;
    }

    public static void DrawMovieTable(List<Movie> movies)
    {
        Helpers.PrintStringToColor(@" 
___  ___           _        _____       _        _                  
|  \/  |          (_)      /  __ \     | |      | |                 
| .  . | _____   ___  ___  | /  \/ __ _| |_ __ _| | ___   __ _  
| |\/| |/ _ \ \ / / |/ _ \ | |    / _` | __/ _` | |/ _ \ / _` |
| |  | | (_) \ V /| |  __/ | \__/\ (_| | || (_| | | (_) | (_| |
\_|  |_/\___/ \_/ |_|\___|  \____/\__,_|\__\__,_|_|\___/ \__, |
                                                          __/ |     
                                                         |___/     
","yellow");

        Helpers.CharLine('-', 80);
        Console.WriteLine("This is our movie Catalog");
        Helpers.CharLine('-', 80);
        Console.WriteLine("\n\n");

        Console.WriteLine("{0,-20} | {1,-15} | {2,-25} | {3,-30} | {4,-10}", "Movie Title", "Release Year",
            "Director", "Genre", "Rating");

        Console.WriteLine(new string('-', 110));

        // Weergave van films met markering voor de geselecteerde film
        for (int i = 0; i < movies.Count; i++)
        {
            if (i == selectedMovieIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine("{0,-20} | {1,-15} | {2,-25} | {3,-30} | {4,-10}",
            TruncateString(movies[i].MovieTitle,20),
            movies[i].ReleaseYear,
            TruncateString(movies[i].Directors, 20), 
            TruncateString( string.Join(", ", movies[i].Genre),20), 
            movies[i].Rating);
            Console.ResetColor();
        }
    }


    public static void ShowSelectedMoviePlot(Movie selectedMovie)
    {
        Console.WriteLine($"\nThe plot of: '{selectedMovie.MovieTitle}' is:\n");
        DiscriptionPrinter.DrawBox(selectedMovie);
        
         
    }
    public static string TruncateString(string stringValue, int maxLength)
    {
        if (stringValue.Length > maxLength)
        {
            stringValue = stringValue.Substring(0, maxLength - 3) + "...";
        }
        return stringValue;
    }
}

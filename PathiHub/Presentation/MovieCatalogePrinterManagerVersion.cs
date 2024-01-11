using System.ComponentModel;

namespace PathiHub.Presentation;
//Dit print de tabel waarmee je een bepaalde header mee geeft die word gebruikt

public class MovieCatalogePrinterManagerVersion
{
    private static int selectedMovieIndex = 0;
    // private static bool PressedEnter = false;

    public static Movie TabelPrinter(MoviesAccess access, string header)
    {
        if (access.LoadFromJson() == true)
        {
            List<Movie> movies = access.GetItemList();

            // Teken de tabel met films
            DrawMovieTable(movies, header);

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
                        Environment.Exit(0);
                        break;
                }

                // Clear the console before redrawing the table
                Console.Clear();

                // Teken de tabel met films (opnieuw) om de geselecteerde film te markeren
                DrawMovieTable(movies, header);

                // Toon de plot van de geselecteerde film
                ShowSelectedMoviePlot(movies[selectedMovieIndex]);

            } while (key.Key != ConsoleKey.Enter);

            // Nu heb je toegang tot de geselecteerde film in de "movies" lijst
            Console.WriteLine($"\nYou have selected the movie: '{movies[selectedMovieIndex].MovieTitle}'.");
            // MovieToAuditoriumLogic movieToAuditoriumLogic = new MovieToAuditoriumLogic();
            // movieToAuditoriumLogic.Connector(movies[selectedMovieIndex]);
            // Thread.Sleep(2000); // Optional delay
           

            return movies[selectedMovieIndex];
        }

        Helpers.PrintStringToColor("Something went wrong there is no data You will be redirected to Your Menu","red");
        Thread.Sleep(2000);
        Helpers.BackToYourMenu();
        return null;
    }

    public static void DrawMovieTable(List<Movie> movies, string header)
    {
        Helpers.PrintStringToColor(header,"yellow");
//         Console.WriteLine(@" 
// ___  ___           _        _____       _        _                  
// |  \/  |          (_)      /  __ \     | |      | |                 
// | .  . | _____   ___  ___  | /  \/ __ _| |_ __ _| | ___   __ _  
// | |\/| |/ _ \ \ / / |/ _ \ | |    / _` | __/ _` | |/ _ \ / _` |
// | |  | | (_) \ V /| |  __/ | \__/\ (_| | || (_| | | (_) | (_| |
// \_|  |_/\___/ \_/ |_|\___|  \____/\__,_|\__\__,_|_|\___/ \__, |
//                                                           __/ |     
//                                                          |___/     
// ");

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

            Console.WriteLine("{0,-20} | {1,-15} | {2,-25} | {3,-30} | {4,-10}", TruncateString(movies[i].MovieTitle,20 ),
                movies[i].ReleaseYear, TruncateString( movies[i].Directors, 20), TruncateString( string.Join(", ", movies[i].Genre), 20), movies[i].Rating);

            Console.ResetColor();
        }
    }
    public static string TruncateString(string stringValue, int maxLength)
    {
        if (stringValue.Length > maxLength)
        {
            stringValue = stringValue.Substring(0, maxLength - 3) + "...";
        }
        return stringValue;
    }


    public static void ShowSelectedMoviePlot(Movie selectedMovie)
    {
        Console.WriteLine($"\nThe plot of: '{selectedMovie.MovieTitle}' is:\n");
        DiscriptionPrinter.DrawBox(selectedMovie);
        
    }
}
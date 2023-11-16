using Newtonsoft.Json;

public class DeleteMovieOutTabel
{
    private static int selectedMovieIndex = 0;

    public static void MovieDeletor(string HeaderX)
    {
        MoviesAccess acces = new MoviesAccess();
        if (acces.LoadFromJson())
        {
            string jsonFilePath = @"DataSources/Movies.json";

            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);

            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonContent);

            DrawMovieTable(movies, HeaderX);

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedMovieIndex = (selectedMovieIndex - 1 + movies.Count) % movies.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedMovieIndex = (selectedMovieIndex + 1) % movies.Count;
                        break;
                }

                Console.Clear();
                DrawMovieTable(movies, HeaderX);

            } while (key.Key != ConsoleKey.Enter);

            // Delete the selected movie from the list
            
            Movie selectedMovie = movies[selectedMovieIndex];
            // Console.WriteLine($"Are you sure you want to delete movie:'{selectedMovie.MovieTitle}'.");
            Helpers.PrintStringToColor($"Are you sure you want to delete the movie'{selectedMovie.MovieTitle}'.\nPlease type 'yes' or 'no'.", "blue");
            Console.Write("\u2192 ");
            string answer = Console.ReadLine().ToLower();
            
            if (answer == "yes")
            {
                movies.Remove(selectedMovie);
                Helpers.PrintStringToColor($"You have deleted the movie: '{selectedMovie.MovieTitle}'.", "red");
                Thread.Sleep(2000);
                
                // Serialize the updated list back to JSON
                 string updatedJsonContent = JsonConvert.SerializeObject(movies, Formatting.Indented);
                 System.IO.File.WriteAllText(jsonFilePath, updatedJsonContent);
            }

            if (answer == "no")
            {
                Console.WriteLine($"You have chosen not to delete the movie:{selectedMovie.MovieTitle}.");
                Helpers.PrintStringToColor("Do you want to choose an other movie to remove?", "blue");
                Console.Write("\u2192 ");
                string answer2 = Console.ReadLine().ToLower();
                if(answer2 == "yes")
                {
                    Console.WriteLine("You will be redirected");
                    Thread.Sleep(800);
                    MovieOptionPresentation.RemoveMoviePresentation();
                }

                if (answer2 == "no")
                {
                    Console.WriteLine("you will be redirected");
                    Thread.Sleep(800);
                    ManagerMenu.Start();
                }
            }
            
            
            

            Console.Clear();
            
        }
    }


    private static void DrawMovieTable(List<Movie> movies, string HeaderX)
    {
        Console.WriteLine(HeaderX);

        Helpers.CharLine('-' ,80);
        Console.WriteLine("This our movie Catalog");
        Helpers.CharLine('-' ,80);
        Console.WriteLine("\n\n\n\n");

        Console.WriteLine("{0,-20} | {1,-15} | {2,-25} | {3,-30} | {4,-10}", "Movie Title", "Release Year",
            "Director", "Genre", "Rating");
        
        Console.WriteLine(new string('-', 110));
        
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

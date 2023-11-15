using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public  class DeleteMovieOutTabel
{
    private static int selectedMovieIndex = 0;

    public static void MovieDeletor(string HeaderX)
    {
        MoviesAcces acces = new MoviesAcces();
        if (acces.LoadMoviesFromJson())
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

            movies.Remove(selectedMovie);
            PrintStringToColor.Color($"You have deleted the movie: '{selectedMovie.MovieTitle}'.", "red");
            Thread.Sleep(2000);

            // Serialize the updated list back to JSON
            string updatedJsonContent = JsonConvert.SerializeObject(movies, Formatting.Indented);
            System.IO.File.WriteAllText(jsonFilePath, updatedJsonContent);

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

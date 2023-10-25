public static class MovieOptionPresentation
{
        public static void AddMoviePresentation()
        {
            Movie movie = new Movie();
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter movie title: ");
            movie.MovieTitle = Console.ReadLine();

            Console.WriteLine("Enter release year: ");
            int? releaseYearInput = Convert.ToInt32(Console.ReadLine());
            movie.ReleaseYear = releaseYearInput;

            Console.WriteLine("Enter genres (comma-separated, or press Enter for none): ");
            string? genresInput = Console.ReadLine();
            movie.Genre = string.IsNullOrEmpty(genresInput)
                ? null
                : new List<string>(genresInput.Split(','));


            Console.WriteLine("Enter director: ");
            string Director = Console.ReadLine();
            movie.Director = Director;

            Console.WriteLine("Enter writers (comma-separated, or press Enter for none): ");
            string? writersInput = Console.ReadLine();
            movie.Writers = string.IsNullOrEmpty(writersInput)
                ?null
                : new List<string>(writersInput.Split(','));

            Console.WriteLine("Enter plot: ");
            string? plot = Console.ReadLine();
            movie.Plot = plot;

            Console.WriteLine("Enter rating: ");
            string ratingInputString = Console.ReadLine();
            double? ratingInput = string.IsNullOrEmpty(ratingInputString) 
                ? null 
                : Convert.ToDouble(ratingInputString);
            movie.Rating = ratingInput;

            Console.WriteLine("Enter runtime in minutes: ");
            int? runtimeInput = Convert.ToInt32( Console.ReadLine());
            movie.RuntimeMinutes = runtimeInput;

            Console.WriteLine("Enter language: ");
            string? Language = Console.ReadLine();
            movie.Language = Language;

            Console.WriteLine("Enter country: ");
            string Country = Console.ReadLine();
            movie.Country = Country;

            Console.WriteLine("Enter Awards (comma-separated, or press Enter for none): ");
            string? AwardsInput = Console.ReadLine();
            movie.Awards = string.IsNullOrEmpty(AwardsInput)
                ?null
                : new List<string>(AwardsInput.Split(','));

            MovieOptions Option = new MovieOptions();
            if (Option.LoadMoviesFromJson() == true)
            {
                if (Option.AddMovie(movie) != true)
                {
                    Console.WriteLine("Movie already exits\n");
                }
                else
                {
                    Console.WriteLine("Movie has been added\n");
                }
                Option.SaveMoviesToJson();
            }
            else
            {
                Console.WriteLine("File not found. No movies loaded.");
            }
        }   

        public static void RemoveMovie()
        {
            Console.WriteLine("\n\n\n\n\nTitle of the movie You want to remove");
            string MovieTitle = Console.ReadLine();
            Console.WriteLine("Director of the movie You want to remove");
            string MovieDirector = Console.ReadLine();
            MovieOptions Options = new MovieOptions();
            if (Options.LoadMoviesFromJson() == true)
            {
                if (Options.RemoveMovie(MovieTitle,MovieDirector) !=true)
                {
                    Console.WriteLine("\nMovie doesn't exist");
                }
                else
                {
                    Console.WriteLine("\nMovie has been removed");
                }
                Options.SaveMoviesToJson();
            }
            else
            {
            Console.WriteLine("File not found. No movies loaded.");
            }
        }
}
public static class MovieOptionPresentation
{
        public static void AddMoviePresentation()
        {
            Console.Clear();
            Console.WriteLine(@"
          ___      _     _  ___  ___           _      
   _     / _ \    | |   | | |  \/  |          (_)     
 _| |_  / /_\ \ __| | __| | | .  . | _____   ___  ___ 
|_   _| |  _  |/ _` |/ _` | | |\/| |/ _ \ \ / / |/ _ \
  |_|   | | | | (_| | (_| | | |  | | (_) \ V /| |  __/
        \_| |_/\__,_|\__,_| \_|  |_/\___/ \_/ |_|\___|
                                                      ");
            Movie movie = new Movie();
            Console.WriteLine("\n\n");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.Write("Enter movie title: ");
            movie.MovieTitle = WriteInputColor.Color("DarkYellow");

            bool inputIsValid = false;
            while (!inputIsValid)
            {
                try
                {
                    Console.Write("Enter release year: ");
                    int? releaseYearInput = Convert.ToInt32(WriteInputColor.Color("DarkYellow"));
                    movie.ReleaseYear = releaseYearInput;
                    inputIsValid = true; 
                }
                catch (FormatException e)
                {
                    PrintStringToColor.Color("Invalid input format. Please enter a valid integer.\nA valid option is when the date has 4 digits ", "red");
                }
                catch (OverflowException e)
                {
                    PrintStringToColor.Color("Input value is too large or too small. Please enter a valid integer.\nA valid option is when the date has 4 digits", "red");
                }
            }



            Console.Write("Enter genres (comma-separated, or press Enter for none): ");
            string? genresInput = WriteInputColor.Color("DarkYellow");
            movie.Genre = string.IsNullOrEmpty(genresInput)
                ? null
                : new List<string>(genresInput.Split(','));

            Console.Write("Enter director: ");
            string Director = WriteInputColor.Color("DarkYellow");
            movie.Director = Director;

            Console.Write("Enter writers (comma-separated, or press Enter for none): ");
            string? writersInput = WriteInputColor.Color("DarkYellow");
            movie.Writers = string.IsNullOrEmpty(writersInput)
                ?null
                : new List<string>(writersInput.Split(','));

            Console.Write("Enter plot: ");
            string? plot = WriteInputColor.Color("DarkYellow");
            movie.Plot = plot;

            Console.Write("Enter rating: ");
            string ratingInputString = WriteInputColor.Color("DarkYellow");
            double? ratingInput = string.IsNullOrEmpty(ratingInputString) 
                ? null 
                : Convert.ToDouble(ratingInputString);
            movie.Rating = ratingInput;

            Console.Write("Enter runtime in minutes: ");
            int? runtimeInput = Convert.ToInt32( WriteInputColor.Color("DarkYellow"));
            movie.RuntimeMinutes = runtimeInput;

            Console.Write("Enter language: ");
            string? Language = WriteInputColor.Color("DarkYellow");
            movie.Language = Language;

            Console.Write("Enter country: ");
            string Country = WriteInputColor.Color("DarkYellow");
            movie.Country = Country;

            Console.Write("Enter Awards (comma-separated, or press Enter for none): ");
            string? AwardsInput = WriteInputColor.Color("DarkYellow");
            movie.Awards = string.IsNullOrEmpty(AwardsInput)
                ?null
                : new List<string>(AwardsInput.Split(','));

            MovieOptions Option = new MovieOptions();
            if (Option.LoadMoviesFromJson() == true)
            {
                if (Option.AddMovie(movie) != true)
                {
                    PrintStringToColor.Color("\nMovie already exits\n","red");
                }
                else
                {
                    PrintStringToColor.Color($"\n+ {movie.MovieTitle}  has been added\n","green");
                    Option.SaveMoviesToJson();
                }

            Console.WriteLine("Press ENTER to continue");
            string Enter = Console.ReadLine();

            }
            else
            {
                PrintStringToColor.Color("File not found. No movies loaded.\n", "red");
                Console.WriteLine("Press ENTER to continue");
                string enter = Console.ReadLine();
            }
        }   

        public static void RemoveMoviePresentation()
        {
            Console.WriteLine(@"
         ______                                ___  ___           _      
         | ___ \                               |  \/  |          (_)     
 ______  | |_/ /___ _ __ ___   _____   _____   | .  . | _____   ___  ___ 
|______| |    // _ \ '_ ` _ \ / _ \ \ / / _ \  | |\/| |/ _ \ \ / / |/ _ \
         | |\ \  __/ | | | | | (_) \ V /  __/  | |  | | (_) \ V /| |  __/
         \_| \_\___|_| |_| |_|\___/ \_/ \___|  \_|  |_/\___/ \_/ |_|\___|
                                                                         
                                                                     ");

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.Write("\n\nTitle of the movie You want to remove: ");
            string MovieTitle = WriteInputColor.Color("DarkYellow");
            Console.Write("\nDirector of the movie You want to remove: ");
            string MovieDirector = WriteInputColor.Color("DarkYellow");
            MovieOptions Options = new MovieOptions();
            if (Options.LoadMoviesFromJson() == true)
            {
                if (Options.RemoveMovie(MovieTitle,MovieDirector) == false)
                {
                    PrintStringToColor.Color("\nMovie doesn't exist", "red");

                }
                else
                {
                    Options.SaveMoviesToJson();
                    PrintStringToColor.Color($"\n- {MovieTitle} has been removed\n", "red");
                }
            Console.WriteLine("Press ENTER to continue");
            string Enter = Console.ReadLine();  
            }
            else
            {
            Console.WriteLine("File not found. No movies loaded.");
            Console.WriteLine("Press ENTER to continue");
            string enter = Console.ReadLine();
            }
        }
}
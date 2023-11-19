public static class MovieOptionPresentation
{
        public static void AddMoviePresentation()
        {
            Console.Clear();
            Helpers.PrintStringToColor(@"
          ___      _     _  ___  ___           _      
   _     / _ \    | |   | | |  \/  |          (_)     
 _| |_  / /_\ \ __| | __| | | .  . | _____   ___  ___ 
|_   _| |  _  |/ _` |/ _` | | |\/| |/ _ \ \ / / |/ _ \
  |_|   | | | | (_| | (_| | | |  | | (_) \ V /| |  __/
        \_| |_/\__,_|\__,_| \_|  |_/\___/ \_/ |_|\___|
                                                      ","Yellow");
            Movie movie = new Movie();
            Console.WriteLine("\n\n");
            Helpers.CharLine('-' ,80);
            Console.Write("Enter movie title: ");
            movie.MovieTitle = Helpers.Color("DarkYellow");

            bool inputIsValid = false;
            while (!inputIsValid)
            {
                try
                {
                    Console.Write("Enter release year: ");
                    int? releaseYearInput = Convert.ToInt32(Helpers.Color("DarkYellow"));
                    movie.ReleaseYear = releaseYearInput;
                    inputIsValid = true; 
                }
                catch (FormatException e)
                {
                    Helpers.PrintStringToColor("Invalid input format. Please enter a valid integer.\nA valid option is when the date has 4 digits ", "red");
                }
                catch (OverflowException e)
                {
                    Helpers.PrintStringToColor("Input value is too large or too small. Please enter a valid integer.\nA valid option is when the date has 4 digits", "red");
                }
            }



            Console.Write("Enter genres (comma-separated, or press Enter for none): ");
            string? genresInput = Helpers.Color("DarkYellow");
            movie.Genre = string.IsNullOrEmpty(genresInput)
                ? null
                : new List<string>(genresInput.Split(','));

            Console.Write("Enter director: ");
            string Director = Helpers.Color("DarkYellow");
            movie.Director = Director;

            Console.Write("Enter writers (comma-separated, or press Enter for none): ");
            string? writersInput = Helpers.Color("DarkYellow");
            movie.Writers = string.IsNullOrEmpty(writersInput)
                ?null
                : new List<string>(writersInput.Split(','));

            Console.Write("Enter plot: ");
            string? plot = Helpers.Color("DarkYellow");
            movie.Plot = plot;

            Console.Write("Enter rating: ");
            string ratingInputString = Helpers.Color("DarkYellow");
            double? ratingInput = string.IsNullOrEmpty(ratingInputString) 
                ? null 
                : Convert.ToDouble(ratingInputString);
            movie.Rating = ratingInput;

            Console.Write("Enter runtime in minutes: ");
            int? runtimeInput = Convert.ToInt32( Helpers.Color("DarkYellow"));
            movie.RuntimeMinutes = runtimeInput;

            Console.Write("Enter language: ");
            string? Language = Helpers.Color("DarkYellow");
            movie.Language = Language;

            Console.Write("Enter country: ");
            string Country = Helpers.Color("DarkYellow");
            movie.Country = Country;

            Console.Write("Enter Awards (comma-separated, or press Enter for none): ");
            string? AwardsInput = Helpers.Color("DarkYellow");
            movie.Awards = string.IsNullOrEmpty(AwardsInput)
                ?null
                : new List<string>(AwardsInput.Split(','));


            MoviesAccess acces = new MoviesAccess();
            if (acces.LoadFromJson() == true)
            {
                MovieOptions Option = new MovieOptions(acces.GetItemList());
                if (Option.AddMovie(movie) != true)
                {
                    Helpers.PrintStringToColor("\nMovie already exits\n","red");
                }
                else
                {
                    Helpers.PrintStringToColor($"\n+ {movie.MovieTitle}  has been added\n","green");
                    acces.SaveToJson();
                }

            Console.WriteLine("Press ENTER to continue");
            string Enter = Console.ReadLine();

            }
            else
            {
                Helpers.PrintStringToColor("File not found. No movies loaded.\n", "red");
                Console.WriteLine("Press ENTER to continue");
                string enter = Console.ReadLine();
            }
        }   

        
        
        
//----------------------------------------------------------------------------------------------------------------------        
        
        
        
        
        public static void RemoveMoviePresentation()
        {
            
            
            Console.Clear();
            string HeaderX = @"
         ______                                ___  ___           _      
         | ___ \                               |  \/  |          (_)     
 ______  | |_/ /___ _ __ ___   _____   _____   | .  . | _____   ___  ___ 
|______| |    // _ \ '_ ` _ \ / _ \ \ / / _ \  | |\/| |/ _ \ \ / / |/ _ \
         | |\ \  __/ | | | | | (_) \ V /  __/  | |  | | (_) \ V /| |  __/
         \_| \_\___|_| |_| |_|\___/ \_/ \___|  \_|  |_/\___/ \_/ |_|\___|
                                                                         
                                                                     ";

            Console.WriteLine("Select the movie you want to remove:");
            DeleteMovieOutTabel2.MovieDeletor(HeaderX);
            
            // Helpers.StringLine(80);
            //
            // Console.Write("\n\nTitle of the movie You want to remove: ");
            // string MovieTitle = WriteInputColor.Color("DarkYellow");
            //
            // Console.Write("\nDirector of the movie You want to remove: ");
            // string MovieDirector = WriteInputColor.Color("DarkYellow");
            //
            // MoviesAcces acces = new MoviesAcces();
            // if (acces.LoadMoviesFromJson() == true)
            // {
            //     MovieOptions Option = new MovieOptions(acces.movies);
            //     if (Option.RemoveMovie(MovieTitle,MovieDirector) == false)
            //     {
            //         PrintStringToColor.Color("\nMovie doesn't exist", "red");
            //
            //     }
            //     else
            //     {
            //         acces.SaveMoviesToJson();
            //         PrintStringToColor.Color($"\n- {MovieTitle} has been removed\n", "red");
            //     }
            // Console.WriteLine("Press ENTER to continue");
            // string Enter = Console.ReadLine();  
            // }
            // else
            // {
            // Console.WriteLine("File not found. No movies loaded.");
            // Console.WriteLine("Press ENTER to continue");
            // string enter = Console.ReadLine();
            // }
        }
    public static void EditMoviePresentation()
    {
    MoviesAccess access = new ();
    EditObjOutTabel.Editor("Movie", access);
    }
}
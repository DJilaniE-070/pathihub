using System.Net;
using Newtonsoft.Json.Linq;
using PathiHub;

public static class MovieOptionPresentation
{       

        public static void AddMoviePresentationWebbOption()
        {
        string Header = 
@"
___  ___           _       ______                                 
|  \/  |          (_)      | ___ \                                
| .  . | _____   ___  ___  | |_/ /_ __ _____      _____  ___ _ __ 
| |\/| |/ _ \ \ / / |/ _ \ | ___ \ '__/ _ \ \ /\ / / __|/ _ \ '__|
| |  | | (_) \ V /| |  __/ | |_/ / | | (_) \ V  V /\__ \  __/ |   
\_|  |_/\___/ \_/ |_|\___| \____/|_|  \___/ \_/\_/ |___/\___|_|   
                                                                  
                                                                  ";
        Helpers.PrintStringToColor(Header,"yellow");       
        Helpers.CharLine('-',80);
                                        
        if (!MovieOptionsLogic.CheckWifi())
        {
            Helpers.PrintStringToColor("No internet connection detected. Press enter to try again, press 'M' to enter manual mode without Network access, Backspace to return to the ManagerMenu or Esc to return to the MainMenu", "Red");
            ConsoleKeyInfo key = Console.ReadKey();
            
            if (key.Key == ConsoleKey.M)
            {
                // Manual mode without WiFi access
                AddMoviePresentation();
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                AddMoviePresentationWebbOption(); 
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                ManagerMenu.Start();
            }
            // Dit werkt nog niet ik kan dit niet gebruiken kan niet naar main menu en uitloggen soort van
            // else if (key.Key == ConsoleKey.Escape)
            // {
                
            //     System.Environment.Exit(0);
            //     Menu.Start();
            //     return;
            // }
            else
            {
                Helpers.PrintStringToColor("Invalid option try again","red");
                Thread.Sleep(500);
                Console.Clear();
                AddMoviePresentationWebbOption();
            }            

        }
        else
        {
            Helpers.PrintStringToColor("Press enter to continue, press 'M' to enter manual mode without Network access, Backspace to return to the ManagerMenu or Esc to return to the MainMenu\n", "Green");
            ConsoleKeyInfo key = Console.ReadKey();
                
            if (key.Key == ConsoleKey.M)
            {
                // Manual mode without WiFi access
                AddMoviePresentation();
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                OMDBAddMovie.AddMoviePresentationWebb(Header);

            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                ManagerMenu.Start();
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                Menu.Start();
                return;
            }
            else
            {
                Helpers.PrintStringToColor("\nInvalid option try again","red");
                Thread.Sleep(500);
                Console.Clear();
                AddMoviePresentationWebbOption();
            }
            
        }
        }
        
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
                    int releaseYearInput = Convert.ToInt32(Helpers.Color("DarkYellow"));
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
                ? new List<string> { "X" } 
                : new List<string>(genresInput.Split(','));

            Console.Write("Enter director: ");
            string? Director = Helpers.Color("DarkYellow");
            movie.Director = string.IsNullOrEmpty(Director)
                ? "X" 
                : Director;
            

            Console.Write("Enter writers (comma-separated, or press Enter for none): ");
            string? writersInput = Helpers.Color("DarkYellow");
            movie.Writers = string.IsNullOrEmpty(writersInput)
                ?  new List<string> { "X" }  
                : new List<string>(writersInput.Split(','));

            Console.Write("Enter plot: ");
            string? plot = Helpers.Color("DarkYellow");
            movie.Plot = string.IsNullOrEmpty(plot) 
                ?"X"
                :movie.Plot = plot;       


            Console.Write("Enter rating: ");
            string? ratingInputString = Helpers.Color("DarkYellow");
            movie.Rating = string.IsNullOrEmpty(ratingInputString) 
                ? 0.0
                : Convert.ToDouble(ratingInputString);

            Console.Write("Enter runtime in minutes: ");
            string runtimeInput = Helpers.Color("DarkYellow");
            movie.RuntimeMinutes = string.IsNullOrEmpty(runtimeInput)
                ? 0
                : Convert.ToInt32(runtimeInput);
            
            Console.Write("Enter language: ");
            string? Language = Helpers.Color("DarkYellow");
            movie.Language = string.IsNullOrEmpty(Language)
            ?"X"
            :Language;
            
            Console.Write("Enter country: ");
            string Country = Helpers.Color("DarkYellow");
            movie.Country = string.IsNullOrEmpty(Country)
            ?"X"
            :Country;

            Console.Write("Enter Awards (comma-separated, or press Enter for none): ");
            string? AwardsInput = Helpers.Color("DarkYellow");
            movie.Awards = string.IsNullOrEmpty(AwardsInput)
                ? new List<string> { "X" } 
                : new List<string>(AwardsInput.Split(','));
            
            Console.Write("Enter the auditorium (1,2,3): ");
            int auditorium = Convert.ToInt32( Helpers.Color("DarkYellow"));
            movie.Auditorium = auditorium;


            MoviesAccess acces = new MoviesAccess();
            if (acces.LoadFromJson() == true)
            {
                MovieOptionsLogic Option = new();
                Option.InitializeMovies(acces.GetItemList());
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
                Console.ReadLine();

            }
            else
            {
                Helpers.PrintStringToColor("File not found. No movies loaded.\n", "red");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
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
    List<string> ColomnNames = new(){"MovieTitle", "ReleaseYear",
    "Director", "Genre", "Rating"};
    string HeaderX = @"

___  ___           _        _____       _        _                  
|  \/  |          (_)      /  __ \     | |      | |                 
| .  . | _____   ___  ___  | /  \/ __ _| |_ __ _| | ___   __ _  
| |\/| |/ _ \ \ / / |/ _ \ | |    / _` | __/ _` | |/ _ \ / _` |
| |  | | (_) \ V /| |  __/ | \__/\ (_| | || (_| | | (_) | (_| |
\_|  |_/\___/ \_/ |_|\___|  \____/\__,_|\__\__,_|_|\___/ \__, |
                                                          __/ |     
                                                         |___/     
";

    PerformActionToTabel.Editor(HeaderX, "Movie", ColomnNames);
    }

    public static void ShowMovies()
    {
    string HeaderX = @"

___  ___           _        _____       _        _                  
|  \/  |          (_)      /  __ \     | |      | |                 
| .  . | _____   ___  ___  | /  \/ __ _| |_ __ _| | ___   __ _  
| |\/| |/ _ \ \ / / |/ _ \ | |    / _` | __/ _` | |/ _ \ / _` |
| |  | | (_) \ V /| |  __/ | \__/\ (_| | || (_| | | (_) | (_| |
\_|  |_/\___/ \_/ |_|\___|  \____/\__,_|\__\__,_|_|\___/ \__, |
                                                          __/ |     
                                                         |___/     
";
    MoviesAccess access = new();
    List<string> ColomnNames = new(){"MovieTitle", "ReleaseYear",
    "Director", "Genre", "Rating"};
    if(access.LoadFromJson()!= false)
    {
    List<Movie> movies = access.GetItemList();
    ObjCatalogePrinter.TabelPrinter(HeaderX, movies, ColomnNames);
    }
    }
}
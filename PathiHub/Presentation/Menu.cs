using System.Threading;
using System.Text;
using PathiHub.Presentation;

public static class Menu 
{
    // dit is het scherm is word puur gebruikt als eerste scherm
    //goede versie
    public static void Start()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "[1] Our movie selection", "[2] Our Snacks selection", "[3] Login/Register" };
        
        PromotionMovieAccess promotedMovies = new();
        
        
        
        List<string> List_Of_Movie_Titles = new List<string>();
        List<Movie> List_Of_Movie_Discriptions = new List<Movie>();
        
        if (promotedMovies.LoadFromJson())
        {
            List<Movie> promoted_movies_list = promotedMovies.GetItemList();
            foreach (var movieTitle in promoted_movies_list)
            {
                List_Of_Movie_Titles.Add(movieTitle.MovieTitle);
                List_Of_Movie_Discriptions.Add(movieTitle);
                // var firstitem = movieTitle.MovieTitle;
                //
                // var seconditem = movieTitle.MovieTitle[1];
                // // string thrirditem = List_Of_Movie_Titles[2];
                // Console.WriteLine(firstitem);
                //
                // Console.WriteLine(List_Of_Movie_Titles.Count);
                // Console.WriteLine($"the first item = {firstitem}, the second item = {seconditem}");
                
            }

        }
        //Correct Indexes for the movie names
        string First_Promoted_Movie = List_Of_Movie_Titles[0];
        string Second_Promoted_Movie = List_Of_Movie_Titles[1];
        string Third_Promoted_Movie = List_Of_Movie_Titles[2];
        
        //correct Indexes For the movie discriptions
        Movie FirstDiscription = List_Of_Movie_Discriptions[0];
        Movie SecondDiscription = List_Of_Movie_Discriptions[1];
        Movie ThirdDiscription = List_Of_Movie_Discriptions[2];
        

        do
        {
            Console.Clear();
            // promotie menu start
            
            Helpers.PrintStringToColor(
            @"
______     _   _     _   _   _       _     
| ___ \   | | | |   (_) | | | |     | |    
| |_/ /_ _| |_| |__  _  | |_| |_   _| |__  
|  __/ _` | __| '_ \| | |  _  | | | | '_ \ 
| | | (_| | |_| | | | | | | | | |_| | |_) |
\_|  \__,_|\__|_| |_|_| \_| |_/\__,_|_.__/ 
                                          ","DarkYellow");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();

            //print elke promoted movie van list
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"                           {First_Promoted_Movie}");
            Console.WriteLine("╭━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╮");
            Console.ResetColor();
            DiscriptionPrinter.DrawBox(FirstDiscription);
            // Console.WriteLine("In a futuristic world, Alice, a skilled adventurer, and her loyal sidekick Bob, \nembark on a thrilling journey to save their city from the evil plans of Eve, \na cunning antagonist. With high-tech gadgets and unyielding determination, \nthey must overcome various challenges and foes to restore peace to their homeland.");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            Console.WriteLine($"                             {Second_Promoted_Movie}");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════");
            Console.ResetColor();
            DiscriptionPrinter.DrawBox(SecondDiscription);
            // Console.WriteLine("In the vast expanse of the galaxy, Chris, a brave spaceman, and his alien friend Zara\n embark on a quest to forge alliances between planets and civilizations. \nTheir journey is fraught with intergalactic challenges and unexpected friendships, \ntesting their courage and resolve to bring peace to the universe.");
 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"                              {Third_Promoted_Movie}");
            Console.WriteLine("♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦");
            Console.ResetColor();
            DiscriptionPrinter.DrawBox(ThirdDiscription);
            // Console.WriteLine("In a world threatened by an imminent cosmic catastrophe, Earth's mightiest heroes, \nThe Avengers, assemble to confront a powerful enemy set on destroying the planet. \nAs they unite their unique powers, the team faces internal conflicts, \nunexpected alliances, and a race against time to save humanity from impending doom. \nGet ready for an epic battle that transcends individual abilities, \nproving that together, they are unstoppable.");

            //promotie menu einde
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Please select an option (using the arrow keys and press Enter):");

            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(menuOptions[i]);
                Console.ResetColor();
            }

            Console.WriteLine("--------------------------------------------------------------------------------");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedIndex > 0)
                    {
                        selectedIndex--;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (selectedIndex < menuOptions.Length - 1)
                    {
                        selectedIndex++;
                    }

                    break;
                
                case ConsoleKey.Enter:
                    Console.Clear();
                    Console.Write("Loading");

                    // loading animatie start
                    // for (int i = 0; i < 4; i++)
                    // {
                    //     Thread.Sleep(500); // Wacht 500 milliseconden (0,5 seconden)
                    //     Console.Write(".");
                        
                    // }
                    // Console.WriteLine();
                    // Console.WriteLine("Loading Completed.");
                    // Thread.Sleep(1000);
                    // loading animatie eind

                    PerformAction(menuOptions[selectedIndex]);
                    exit = true;
                    break;
            }

        } while (!exit);

        Console.CursorVisible = true;
    }

    static void PerformAction(string option)
    {
        Console.WriteLine("Selected: " + option);
        switch (option)
        {
            case "[3] Login/Register":
                Thread.Sleep(1500);
                LoginORRegister.Start();
                break;

            case "[1] Our movie selection":
                Thread.Sleep(1500);
                Console.Clear();
                MovieOrSchedule.Start();
                break;
            case "[2] Our Snacks selection":
                Thread.Sleep(1500);
                SnacksMenu snack = new SnacksMenu();
                snack.Start();
                break;
        }
    }
}
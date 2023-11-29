public static class GuestLogin 
{
    
    public static void Start()
    {
        {
            Console.CursorVisible = false;
            int selectedIndex = 0;
            bool exit = false;

            string[] menuOptions = { "Our movie selection", "Our Menu selection" };

            do
            {
                Console.Clear();

                Console.WriteLine(@" 
 _____                 _     _                 _       
|  __ \               | |   | |               (_)      
| |  \/_   _  ___  ___| |_  | |     ___   __ _ _ _ __  
| | __| | | |/ _ \/ __| __| | |    / _ \ / _` | | '_ \ 
| |_\ \ |_| |  __/\__ \ |_  | |___| (_) | (_| | | | | |
 \____/\__,_|\___||___/\__| \_____/\___/ \__, |_|_| |_|
                                          __/ |        
                                         |___/          
                                                                                                        
                                                     
");

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
                case "Our movie selection":
                    Thread.Sleep(1500);
                    Console.Clear();
                    MoviesAccess movies = new();
                    MovieCatalogePrinter.TabelPrinter(movies);
                    break;

                case "Our Menu selection":
                    Thread.Sleep(1500);
                    // MovieOverview overview = new();
                    // MoviesAcces movies = new();
                    MovieOverview.GetMovieCataloge();
                    break;


            }
        }
    }
}


 

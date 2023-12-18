public static class MovieOrSchedule
{
    public static void Start()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;
        string[] menuOptions = { "[1] Our movie selection", "[2] Our Schedule selection", };

        do
        {
        Console.Clear();
        Helpers.PathiHubPrint();
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
                case ConsoleKey.Backspace:
                Helpers.BackToYourMenu();
                Environment.Exit(0);
                break;
                case ConsoleKey.Escape:
                Helpers.MainMenu();
                Environment.Exit(0);
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

                case "[1] Our movie selection":
                    Thread.Sleep(1500);
                    Console.Clear();
                    
                    MovieCatalogePrinter.TabelPrinter();
                    break;
                case "[2] Our Schedule selection":
                    ChooseFromSchedule schedule = new();
                    schedule.start();
                    break;


            }
        }
}
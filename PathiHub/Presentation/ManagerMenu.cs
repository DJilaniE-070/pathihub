using System;

public static class ManagerMenu
{
    public static void StartMenu()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "[1] Film options", "[2] Reserve movie", "[3] Reservation options", "[4] Financial options", "[5] Snacks options", "[6] Exit" };

        do
        {
            Console.Clear();

            Console.WriteLine(@"
___  ___                                   ___  ___                 
|  \/  |                                   |  \/  |                 
| .  . | __ _ _ __   __ _  __ _  ___ _ __  | .  . | ___ _ __  _   _ 
| |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__| | |\/| |/ _ \ '_ \| | | |
| |  | | (_| | | | | (_| | (_| |  __/ |    | |  | |  __/ | | | |_| |
\_|  |_/\__,_|_| |_|\__,_|\__, |\___|_|    \_|  |_/\___|_| |_|\__,_|
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
        
        switch (option)
        {
            case "[1] Film options":
                FilmOptions();
                break;
            
            case "[2] Reserve movie":
                Thread.Sleep(1500);
                OrderFilm();
                break;
            
            case "[3] Reservation options":
                Thread.Sleep(1500);
                ReservationsOptions();
                break;
            
            case "[4] Financial options":
                Thread.Sleep(1500);
                FinancialOptions();
                break;
            
            case "[5] Snacks options":
                Thread.Sleep(1500);
                Snacks();
                break;
            
            case "[6] Exit":
                Thread.Sleep(1500);
                Console.WriteLine("Thank you for using our programme.");
                break;
            
        }
    }

    
static void FilmOptions()
{
    string[] menuOptions = { "Add a movie", "Remove a movie", "Return to Manager menu" };
    int selectedIndex = 0;
    bool exit = false;

    Console.CursorVisible = false;

    do
    {
        Console.Clear();
        Console.WriteLine(@"
___  ___           _        _____       _   _                 
|  \/  |          (_)      |  _  |     | | (_)                
| .  . | _____   ___  ___  | | | |_ __ | |_ _  ___  _ __  ___ 
| |\/| |/ _ \ \ / / |/ _ \ | | | | '_ \| __| |/ _ \| '_ \/ __|
| |  | | (_) \ V /| |  __/ \ \_/ / |_) | |_| | (_) | | | \__ \
\_|  |_/\___/ \_/ |_|\___|  \___/| .__/ \__|_|\___/|_| |_|___/
                                 | |                          ");

        Console.WriteLine("--------------------------------------------------------------------------------");
        for (int i = 0; i < menuOptions.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine($"[{(i + 1)}] {menuOptions[i]}");
            Console.ResetColor();
        }
        Console.WriteLine("--------------------------------------------------------------------------------");

        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

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
                int option = selectedIndex + 1;
                if (option == 1)
                {
                    MovieOptionPresentation.AddMoviePresentation();
                }
                else if (option == 2)
                {
                    MovieOptionPresentation.RemoveMoviePresentation();
                }
                else if (option == 3)
                {
                    exit = true;
                    ManagerMenu.StartMenu();
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }
                break;
        }

    } while (!exit);

    Console.CursorVisible = true;
}
        static void OrderFilm()
        {
            // Moet nog geimplementeerd worden.
            Console.WriteLine("Test completed. Still function still needs to be implemented (Order Film)");
        }

        static void ReservationsOptions()
        {
            Console.WriteLine("Test completed. Still function still needs to be implemented");
        }

        static void FinancialOptions()
        {
            Console.WriteLine("Test completed. Still function still needs to be implemented Financial option");
        }

        static void Snacks()
        {
            Console.WriteLine("Test completed ");
        }
}
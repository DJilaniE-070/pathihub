using System;

public static class ManagerMenu
{
    public static void Start()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "[1] Film options", "[2] Reserve a movie", "[3] Reservation options", "[4] Financial options", "[5] Snacks options", "[6] Exit" };

        do
        {
            Console.Clear();

            PrintStringToColor.Color(@"
___  ___                                   ___  ___                 
|  \/  |                                   |  \/  |                 
| .  . | __ _ _ __   __ _  __ _  ___ _ __  | .  . | ___ _ __  _   _ 
| |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__| | |\/| |/ _ \ '_ \| | | |
| |  | | (_| | | | | (_| | (_| |  __/ |    | |  | |  __/ | | | |_| |
\_|  |_/\__,_|_| |_|\__,_|\__, |\___|_|    \_|  |_/\___|_| |_|\__,_|
                           __/ |                                    
                          |___/                                     
                                                     
","yellow");

            Helpers.StringLine(80);
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
            Helpers.StringLine(80);

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
            
            case "[2] Reserve a movie":
                Thread.Sleep(1500);
                ReserveAMovie();
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
        PrintStringToColor.Color(@"
___  ___           _        _____       _   _                 
|  \/  |          (_)      |  _  |     | | (_)                
| .  . | _____   ___  ___  | | | |_ __ | |_ _  ___  _ __  ___ 
| |\/| |/ _ \ \ / / |/ _ \ | | | | '_ \| __| |/ _ \| '_ \/ __|
| |  | | (_) \ V /| |  __/ \ \_/ / |_) | |_| | (_) | | | \__ \
\_|  |_/\___/ \_/ |_|\___|  \___/| .__/ \__|_|\___/|_| |_|___/
                                 | |                          ","Yellow");

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
                    ManagerMenu.Start();
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

static void ReservationsOptions()
{
    string[] menuOptions = { "Make a Reservation", "Remove a reservation", "Return to Manager menu" };
    int selectedIndex = 0;
    bool exit = false;

    Console.CursorVisible = false;

    do
    {
        Console.Clear();
        PrintStringToColor.Color(@"
______                               _   _               _____       _   _                 
| ___ \                             | | (_)             |  _  |     | | (_)                
| |_/ /___  ___  ___ _ ____   ____ _| |_ _  ___  _ __   | | | |_ __ | |_ _  ___  _ __  ___ 
|    // _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \  | | | | '_ \| __| |/ _ \| '_ \/ __|
| |\ \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | | \ \_/ / |_) | |_| | (_) | | | \__ \
\_| \_\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|  \___/| .__/ \__|_|\___/|_| |_|___/
                                                              | |                          
                                                              |_|                          ","yellow");

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
                    ReservationPresentation.AddReservation();
                }
                else if (option == 2)
                {
                    ReservationPresentation.RemoveMoviePresentation();
                }
                else if (option == 3)
                {
                    exit = true;
                    ManagerMenu.Start();
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

        static void ReserveAMovie()
        {
            Thread.Sleep(1500);
            ReservationPresentation.AddReservation();
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
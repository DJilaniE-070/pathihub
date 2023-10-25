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
        Console.WriteLine("Selected: " + option);
        switch (option)
        {
            case "[1] Film options":
                Thread.Sleep(1500);
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
                break;
            
        }
    }

    
        static void FilmOptions()
        {   
            while (true)
            {
            Thread.Sleep(1500);
            Console.WriteLine("\n\n");
            Console.WriteLine("[1] Add a movie");
            Console.WriteLine("[2] Remove a movie");
            Console.WriteLine("[3] Return to Manager menu");
            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                MovieOptionPresentation.AddMoviePresentation();
            }
            else if (option == 2)
            {
                MovieOptionPresentation.RemoveMovie();
            }
            else if (option == 3)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
            }
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
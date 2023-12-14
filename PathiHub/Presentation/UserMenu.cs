using System;

public static class UserMenu
{
    public static void Start()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "[1]. Make a reservation", "[2]. Check reservation", "[3]. Cancel reservation", "[4] Exit" };

        do
        {
            Console.Clear();
            Helpers.PrintStringToColor(@"
 _   _                   ___  ___                    
| | | |                  |  \/  |                    
| | | | ___   ___  _ __  | .  . |  ___  _ __   _   _ 
| | | |/ __| / _ \| '__| | |\/| | / _ \| '_ \ | | | |
| |_| |\__ \|  __/| |    | |  | ||  __/| | | || |_| |
 \___/ |___/ \___||_|    \_|  |_/ \___||_| |_| \__,_|
                                                     
                                                     
", "yellow");

            Helpers.CharLine('-' ,80);
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
            Helpers.CharLine('-' ,80);;

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
                    // ReserveSeat();
                    PerformAction(menuOptions[selectedIndex]);
                    Console.Clear();
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
            case "[1]. Make a reservation":
                MoviesAccess movies = new();
                MovieCatalogePrinter.TabelPrinter(movies);
                break;
            
            case "[2]. Check reservation":
                Thread.Sleep(1500);
                CheckReservation();
                break;
              
            case "[3]. Cancel reservation":
                CancelReservation();
                break;
        }
    }

    static void ReserveSeat()
    {
        string[] Options = { "[1] Auditorium 1", "[2] Auditorium 2", "[3] Auditorium 3" };
        ConsoleKeyInfo key;
        int CursorIndex = 0; 
        Console.CursorVisible = false; 
        for (int i = 0; i < Options.Length; i++)
        {
            if (i == CursorIndex)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.WriteLine(Options[i]);
            Console.ResetColor();
        }
        do
        {
            key = Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("Please select an option (use the arrow keys and press Enter):");

            for (int i = 0; i < Options.Length; i++)
            {
                if (i == CursorIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine(Options[i]);
                Console.ResetColor();
            }

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (CursorIndex > 0)
                    {
                        CursorIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CursorIndex < Options.Length - 1)
                    {
                        CursorIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    SeatMap seatmap = new SeatMap(CursorIndex + 1);
                    break;
            }
        } while (key.Key != ConsoleKey.Escape);
        Console.CursorVisible = true;
    }

    static void CheckReservation()
    {
        Console.WriteLine("Check reservation");
        Console.WriteLine("Here comes the implementations in a later sprint");
    }

    static void CancelReservation()
    {
        Console.WriteLine("Cancel reservation");
        Console.WriteLine("Here comes the implementations in a later sprint");
    }
}
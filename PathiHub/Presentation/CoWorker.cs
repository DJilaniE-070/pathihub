using System;

public static class CoWorker
{
    public static void Start()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "[1] Show reservations", "[2] Change reservations", "[3] Reserve seat for customer", "[4] Exit"};

        do
        {
            Console.Clear();
            Helpers.PrintStringToColor(@"
 _____         _    _               _                 ___  ___                    
/  __ \       | |  | |             | |                |  \/  |                    
| /  \/  ___  | |  | |  ___   _ __ | | __  ___  _ __  | .  . |  ___  _ __   _   _ 
| |     / _ \ | |/\| | / _ \ | '__|| |/ / / _ \| '__| | |\/| | / _ \| '_ \ | | | |
| \__/\| (_) |\  /\  /| (_) || |   |   < |  __/| |    | |  | ||  __/| | | || |_| |
 \____/ \___/  \/  \/  \___/ |_|   |_|\_\ \___||_|    \_|  |_/ \___||_| |_| \__,_|
                                                                                  
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
            Helpers.CharLine('-' ,80);

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
                case ConsoleKey.Escape:
                    Helpers.MainMenu();
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
            case "[1] Show reservations":
            ReservationPresentation.ShowReservations();
                break;
            
            case "[2] Remove reservation":
                ReservationPresentation.RemoveMoviePresentation();
                break;
            
            case "[3] Reserve seat for customer":
                MovieOrSchedule.Start();
                break;
            
            case "[4] Exit":
                Thread.Sleep(1500);
                Helpers.MainMenu();
                break;
        }
    }
}
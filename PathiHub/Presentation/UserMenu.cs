using System;

public static class UserMenu
{
    public static void Start()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "[1] Make a reservation", "[2] Check reservation", "[3] Cancel reservation", "[4] Exit" };

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
            case "[1] Make a reservation":
                MovieOrSchedule.Start();
                break;
            case "[2] Check reservation":
                Thread.Sleep(1500);
                CheckReservation();
                Helpers.BackToYourMenu();
                break;
            case "[3] Cancel reservation":
                ReservationPresentation.RemoveMoviePresentation();
                break;
            case "[4] Exit":
                Thread.Sleep(1500);
                Helpers.MainMenu();
                break;
        }
    }

    static void CheckReservation()
    {
        ReservationAccess access = new();
        List<string> ColomnNames = new() {"FullName", "Auditorium", "SeatNames", "Date", "Time", "Price", "ReservationCode"};
        if(access.LoadFromJson()!= false)
        {
            List<Reservation> reservations = access.GetItemList();
            List<Reservation> sortedReservations = reservations
                .Where(r => r.Email == Helpers.CurrentAccount.EmailAddress)
                .OrderBy(r => r.FullName)
                .ToList(); 
            ObjCatalogePrinter.TabelPrinter("Reservation", sortedReservations, ColomnNames);
        }
        else
        {
            Console.WriteLine("No reservations found");
        }
    }

}

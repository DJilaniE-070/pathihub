using System;

public static class CoWorker
{
    public static void Start()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "[1] Show reservations", "[2] Change reservations", "[3] Reserve seat for customer", "[4] Exit Co Worker Menu"};

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
            case "[1] Show reservations":
                OverviewAllReservations();
                break;
            
            case "[2] Change reservations":
                ChangeReservations();
                break;
            
            case "[3] Reserve seat for customer":
                ReserveSeatCustomer();
                break;
            
            case "[5] Exit Co Worker Menu":
            Thread.Sleep(1500)
                break; 
        }
    }

    static void OverviewAllReservations()
    {
    string HeaderX = @"
 _____  _                       ______                                       _    _                    
/  ___|| |                      | ___ \                                     | |  (_)                   
\ `--. | |__    ___  __      __ | |_/ /  ___  ___   ___  _ __ __   __  __ _ | |_  _   ___   _ __   ___ 
 `--. \| '_ \  / _ \ \ \ /\ / / |    /  / _ \/ __| / _ \| '__|\ \ / / / _` || __|| | / _ \ | '_ \ / __|
/\__/ /| | | || (_) | \ V  V /  | |\ \ |  __/\__ \|  __/| |    \ V / | (_| || |_ | || (_) || | | |\__ \
\____/ |_| |_| \___/   \_/\_/   \_| \_| \___||___/ \___||_|     \_/   \__,_| \__||_| \___/ |_| |_||___/
                                                                                                       
                                                                                                       
";
    ReservationAccess access = new();
    List<string> ColomnNames = new(){"FullName", "ReservationCode", "Email", "Date", "Price"};
    if(access.LoadFromJson()!= false)
    {
    List<Reservation> reservations = access.GetItemList();
    ObjCatalogePrinter.TabelPrinter(HeaderX, reservations, ColomnNames);
    }
    }

    static void ChangeReservations()
    {
        List<string> ColomnNames = new(){"FullName", "ReservationCode", "Email", "Date", "Price"};
        string HeaderX = @"
 _____  _                                 ______                                       _    _                    
/  __ \| |                                | ___ \                                     | |  (_)                   
| /  \/| |__    __ _  _ __    __ _   ___  | |_/ /  ___  ___   ___  _ __ __   __  __ _ | |_  _   ___   _ __   ___ 
| |    | '_ \  / _` || '_ \  / _` | / _ \ |    /  / _ \/ __| / _ \| '__|\ \ / / / _` || __|| | / _ \ | '_ \ / __|
| \__/\| | | || (_| || | | || (_| ||  __/ | |\ \ |  __/\__ \|  __/| |    \ V / | (_| || |_ | || (_) || | | |\__ \
 \____/|_| |_| \__,_||_| |_| \__, | \___| \_| \_| \___||___/ \___||_|     \_/   \__,_| \__||_| \___/ |_| |_||___/
                              __/ |                                                                              
                             |___/                                                                               
";
        PerformActionToTabel.Editor(HeaderX,"Reservation", ColomnNames);
    }

    static void ReserveSeatCustomer()
    {
        Console.WriteLine("Reservate a seat for a customer");
    }
}
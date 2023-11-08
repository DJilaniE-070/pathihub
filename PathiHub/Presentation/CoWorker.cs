using System;

public static class CoWorker
{
    public static void CoWorkerStart()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "[1] Overview all reservations", "[2] Change reservations", "[3] reserve seat for customer","[4] Insight total orders", "[5] Exit Co Worker Menu"};

        do
        {
            Console.Clear();

            Console.WriteLine(@"
    _____           _    _               _                  ___  ___                    
    /  __ \         | |  | |             | |                 |  \/  |                    
    | /  \/  ___    | |  | |  ___   _ __ | | __  ___  _ __   | .  . |  ___  _ __   _   _ 
    | |     / _ \   | |/\| | / _ \ | '__|| |/ / / _ \| '__|  | |\/| | / _ \| '_ \ | | | |
    | \__/\| (_) |  \  /\  /| (_) || |   |   < |  __/| |     | |  | ||  __/| | | || |_| |
    \____/ \___/    \/  \/  \___/ |_|   |_|\_\ \___||_|     \_|  |_/ \___||_| |_| \__,_|
                                                                                        
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
            case "[1] Overview all reservations":
                Thread.Sleep(1500);
                OverviewAllReservations();
                break;
            
            case "[2] Change reservations":
                Thread.Sleep(1500);
                ChangeReservations();
                break;
            
            case "[3] reserve seat for customer":
                Thread.Sleep(1500);
                ReserveSeatCustomer();
                break;
            
            case "[4] Insight total orders":
                Thread.Sleep(1500);
                InsightTotalOrders();
                break;
            
            case "[5] Exit Co Worker Menu":
                break; 
        }
    }

    static void OverviewAllReservations()
    {
        Console.WriteLine("Overview of all reservations");
    }

    static void ChangeReservations()
    {
        Console.WriteLine("Change reservations");
    }

    static void ReserveSeatCustomer()
    {
        Console.WriteLine("Reservate a seat for a customer");
    }

    static void InsightTotalOrders()
    {
        Console.WriteLine("Insight of total orders");
    }
}
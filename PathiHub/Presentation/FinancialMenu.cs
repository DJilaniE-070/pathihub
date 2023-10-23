using System;
public static class FinancialMenu
{
    public static void Financieel_Start()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "[1] Check total reservations", "[2] Check total revenue", "[3] Exit" };

        do
        {
            Console.Clear();

            Console.WriteLine(@"
______  _                             _         _  ___  ___                    
|  ___|(_)                           (_)       | | |  \/  |                    
| |_    _  _ __    __ _  _ __    ___  _   __ _ | | | .  . |  ___  _ __   _   _ 
|  _|  | || '_ \  / _` || '_ \  / __|| | / _` || | | |\/| | / _ \| '_ \ | | | |
| |    | || | | || (_| || | | || (__ | || (_| || | | |  | ||  __/| | | || |_| |
\_|    |_||_| |_| \__,_||_| |_| \___||_| \__,_||_| \_|  |_/ \___||_| |_| \__,_|
                                                                        
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
            case "[1] Check total reservations":
                Thread.Sleep(1500);
                Console.WriteLine(FinancialLogic.TotalReservations);
                break;
            
            case "[2] Check total revenue":
                Thread.Sleep(1500);
                Console.WriteLine(FinancialLogic.TotalRevenue);
                break;
            
                    
            case "[3] Exit":
                break;
            
        }
    }

   
}

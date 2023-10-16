using System;

public static class UserMenu
{
    public static void Start()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "[1]. Make a reservation", "[2]. Check reservation", "[3]. Cancel reservation","[4] Exit" };

        do
        {
            Console.Clear();

            Console.WriteLine(@"
 _   _                   ___  ___                    
| | | |                  |  \/  |                    
| | | | ___   ___  _ __  | .  . |  ___  _ __   _   _ 
| | | |/ __| / _ \| '__| | |\/| | / _ \| '_ \ | | | |
| |_| |\__ \|  __/| |    | |  | ||  __/| | | || |_| |
 \___/ |___/ \___||_|    \_|  |_/ \___||_| |_| \__,_|
                                                     
                                                     
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
            case "[1]. Make a reservation":
                Thread.Sleep(1500);
                ReserveSeat();
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
        Console.WriteLine("Reserve a seat");
        Console.WriteLine("Here comes the implementations in a later sprint");
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
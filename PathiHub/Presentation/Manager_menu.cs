using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

public static class Manager_menu
{
    public static void Start_Menu()
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
                Film_options();
                break;
            
            case "[2] Reserve movie":
                Thread.Sleep(1500);
                Order_film();
                break;
            
            case "[3] Reservation options":
                Thread.Sleep(1500);
                Reservations_options();
                break;
            
            case "[4] Financial options":
                Thread.Sleep(1500);
                Financial_options();
                break;
            
            case "[5] Snacks options":
                Thread.Sleep(1500);
                Snacks();
                break;
            
            case "[6] Exit":
                break;
            
        }
    }

    static void Film_options()
    {
        // Moet nog geimplementeerd worden.
        Console.WriteLine("Test completed. Still function still needs to be implemented(Order Film Options)");
    }
    
    static void Order_film()
    {
        // Moet nog geimplementeerd worden.
        Console.WriteLine("Test completed. Still function still needs to be implemented (Order Film)");
    }

    static void Reservations_options()
    {
        Console.WriteLine("Test completed. Still function still needs to be implemented");
        Console.WriteLine("[1] Add reservations");
        Console.WriteLine("[2] Remove reservation");
        Console.WriteLine("[3] Display reservations");

        Console.WriteLine("Enter option: ");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                Console.WriteLine("Should be implemented to add reservation");
                Add_Reservation();
                break;
            case 2:
                Console.WriteLine("Should be implemented to remove reservation");
                Remove_Reservation();
                break;
            case 3:
                Console.WriteLine("Should be implemented to display reservations");
                Display_Reservations();
                break;
        }
    }

    static void Add_Reservation()
    {
        Console.WriteLine("Test completed add reservation");

    }

    static void Remove_Reservation()
    {
        Console.WriteLine("Test completed remove reservation");
    }

    static void Display_Reservations()
    {
        Console.WriteLine("Test completed display reservations");
    }

    static void Financial_options()
    {
        Console.WriteLine("Test completed. Still function still needs to be implemented Financial option");
    }

    static void Snacks()
    {
        Console.WriteLine("Test completed");
    }
}
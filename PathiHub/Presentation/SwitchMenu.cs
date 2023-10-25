public static class SwitchMenu
{
    public static void start()
    {
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "Login as Guest", " Login as User", " Creating an account"};

        do
        {
            Console.Clear();

            Console.WriteLine(@" 
______     _   _     _ _   _       _      
| ___ \   | | | |   (_) | | |     | |     
| |_/ /_ _| |_| |__  _| |_| |_   _| |__   
|  __/ _` | __| '_ \| |  _  | | | | '_ \  
| | | (_| | |_| | | | | | | | |_| | |_) | 
\_|  \__,_|\__|_| |_|_\_| |_/\__,_|_.__/  
                                          
                                                                            
                                                     
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
            case "Login as Guest":
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
                Thread.Sleep(1500);
                Console.WriteLine("Thank you for using our programme.");
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
    }

    static void Financial_options()
    {
        Console.WriteLine("Test completed. Still function still needs to be implemented Financial option");
    }

    static void Snacks()
    {
        Console.WriteLine("Test completed ");
    }
}
    }

 
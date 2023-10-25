public static class SwitchMenu
{
    public static void Start()
    {
        {
            Console.CursorVisible = false;
            int selectedIndex = 0;
            bool exit = false;

            string[] menuOptions = { "Login as Guest", "Login as User", "Creating an account" };

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
                    Console.WriteLine("must be created!");
                    break;

                case "Login as User":
                    Thread.Sleep(1500);
                    UserLogin.Start();
                    break;

                case "Creating an account":
                    Thread.Sleep(1500);
                    Console.WriteLine(" Must be implemented");
                    break;

            }
        }
    }
}


 
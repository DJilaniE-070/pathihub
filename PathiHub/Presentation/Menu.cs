using PathiHub.Presentation;

public static class Menu 
{
    // dit is het scherm is word puur gebruikt als eerste scherm
    public static void Start()
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "Login as a guest", "Login as an user", "Creating an account" };

        do
        {
            Console.Clear();

            // promotie menu start
            
            Helpers.PrintStringToColor(
            @"
______     _   _     _   _   _       _     
| ___ \   | | | |   (_) | | | |     | |    
| |_/ /_ _| |_| |__  _  | |_| |_   _| |__  
|  __/ _` | __| '_ \| | |  _  | | | | '_ \ 
| | | (_| | |_| | | | | | | | | |_| | |_) |
\_|  \__,_|\__|_| |_|_| \_| |_/\__,_|_.__/ 
                                          ","DarkYellow");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("featured movies:");
            Console.WriteLine();

            //print elke promoted movie van list
            Console.WriteLine("The Avengers");
            Console.WriteLine("Movie test 2");
            Console.WriteLine("Five Guys 3");
            Console.WriteLine();

            //promotie menu einde

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
                    Console.Write("Loading");

                    // loading animatie start
                    for (int i = 0; i < 4; i++)
                    {
                        Thread.Sleep(500); // Wacht 500 milliseconden (0,5 seconden)
                        Console.Write(".");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Loading Completed.");
                    Thread.Sleep(1000);
                    // loading animatie eind

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
            case "Login as a guest":
                Thread.Sleep(1500);
                GuestLogin.Start();
                break;

            case "Login as an user":
                Thread.Sleep(1500);
                GlobalLogin.Start();
                break;

            case "Creating an account":
                Thread.Sleep(1500);
                UserRegistration.RegisterUser();
                break;
        }
    }
}
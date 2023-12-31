using PathiHub.Presentation;

public static class LoginORRegister
{
    
    public static void Start()
    {
        {
            Console.CursorVisible = false;
            int selectedIndex = 0;
            bool exit = false;

            string[] menuOptions = { "Login as an user", "Creating an account" };

            do
            {
                Console.Clear();

                Helpers.PrintStringToColor(@" 
 _                 _           _______           _     _            
| |               (_)         / / ___ \         (_)   | |           
| |     ___   __ _ _ _ __    / /| |_/ /___  __ _ _ ___| |_ ___ _ __ 
| |    / _ \ / _` | | '_ \  / / |    // _ \/ _` | / __| __/ _ \ '__|
| |___| (_) | (_| | | | | |/ /  | |\ \  __/ (_| | \__ \ ||  __/ |   
\_____/\___/ \__, |_|_| |_/_/   \_| \_\___|\__, |_|___/\__\___|_|   
              __/ |                         __/ |                   
             |___/                         |___/                   ","yellow");

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
}


 

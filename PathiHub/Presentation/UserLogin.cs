static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        Console.WriteLine(@" 
 _____ _       _           _   _                 _        ______                
|  __ \ |     | |         | | | |               (_)       | ___ \               
| |  \/ | ___ | |__   __ _| | | |     ___   __ _ _ _ __   | |_/ /_ _  __ _  ___ 
| | __| |/ _ \| '_ \ / _` | | | |    / _ \ / _` | | '_ \  |  __/ _` |/ _` |/ _ \
| |_\ \ | (_) | |_) | (_| | | | |___| (_) | (_| | | | | | | | | (_| | (_| |  __/
 \____/_|\___/|_.__/ \__,_|_| \_____/\___/ \__, |_|_| |_| \_|  \__,_|\__, |\___|
                                            __/ |                     __/ |     
                                           |___/                     |___/      
");
        
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("Welcome to the Global login page.");
        Console.WriteLine("Within this page you can login in to your account off choice.\n");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Options include:\n");
        Console.ResetColor();
        Console.WriteLine("• Managers,\n• Co-Workers,\n• Recurring Users with an account,\n• Financial workers.");
        Console.WriteLine("--------------------------------------------------------------------------------");
        Thread.Sleep(300);
        Console.WriteLine("Please enter your email address:");
        string email = WriteInputColor.Color("darkyellow");
        Console.WriteLine("Please enter your password");    
        string password = WriteInputColor.Color("darkyellow");
        AccountModel acc = accountsLogic.CheckLogin(email, password);
        if (acc != null)
        {
            Console.WriteLine("Welcome back " + acc.FullName);
            Console.WriteLine("Your email number is " + acc.EmailAddress);
            Console.WriteLine("Your role is " + acc.FullName);

            switch (acc.Role) //TODO: fix roles based on class types.
            {
                case "Manager":
                    Console.Clear();
                    ManagerMenu.Start();
                    Console.WriteLine(acc.GetType());
                    break;
                case "Financial Manager":
                    Console.Clear();
                    FinancialMenu.Start();
                    Console.WriteLine("Financial Manager Menu");
                    break;
                case "Coworker":
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("You're username and password are correct.");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Console.WriteLine("You will be redirected to the Co-Worker menu.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    CoWorker.Start();
                    break;
                
                
                case "User":
                    Console.Clear();
                    UserMenu.Start();
                    break;
                case "Customer":
                    Console.Clear();
                    // CustomerMenu.CustomerStart();
                    Console.WriteLine("Customer Menu");
                    break;
                default:
                    break;
                
            }

            //Write some code to go back to the menu
            //Menu.Start();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No account found with that email and password");
            Console.ResetColor();
            Thread.Sleep(1500);
            Console.WriteLine("You will be redirected ");
            Thread.Sleep(1500);
            Console.Clear();
            UserLogin.Start();
            
        }
    }
}
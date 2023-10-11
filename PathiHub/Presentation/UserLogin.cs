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
        Console.WriteLine("Welcome to the Global login page");
        Console.WriteLine("--------------------------------------------------------------------------------");
        Thread.Sleep(300);
        Console.WriteLine("Please enter your email address:");
        string email = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string password = Console.ReadLine();
        AccountModel acc = accountsLogic.CheckLogin(email, password);
        if (acc != null)
        {
            Console.WriteLine("Welcome back " + acc.FullName);
            Console.WriteLine("Your email number is " + acc.EmailAddress);
            Console.WriteLine("Your role is " + acc.FullName);

            switch (acc.Role)
            {
                case "Manager":
                    Console.Clear();
                    Manager_menu.Managerstart();
                    Console.WriteLine(acc.GetType());
                    break;
                case "Financial Manager":
                    Console.Clear();
                    FinancialMenu.Financieel_Start();
                    Console.WriteLine("Financial Manager Menu");
                    break;
                case "Coworker":
                    // CoworkerMenu.Start();
                    Console.WriteLine("Coworker Menu");
                    break;
                default:
                    break;
            }

            //Write some code to go back to the menu
            //Menu.Start();
        }
        else
        {
            Console.WriteLine("No account found with that email and password");
            Thread.Sleep(1500);
            Console.WriteLine("You will be redirected ");
            Thread.Sleep(1500);
            Console.Clear();
            UserLogin.Start();
            
        }
    }
}
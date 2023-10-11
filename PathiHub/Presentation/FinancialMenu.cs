public class FinancialMenu
{
    public static void Financieel_Start()
    {
        Console.WriteLine(@"
______  _                             _         _  ___  ___                    
|  ___|(_)                           (_)       | | |  \/  |                    
| |_    _  _ __    __ _  _ __    ___  _   __ _ | | | .  . |  ___  _ __   _   _ 
|  _|  | || '_ \  / _` || '_ \  / __|| | / _` || | | |\/| | / _ \| '_ \ | | | |
| |    | || | | || (_| || | | || (__ | || (_| || | | |  | ||  __/| | | || |_| |
\_|    |_||_| |_| \__,_||_| |_| \___||_| \__,_||_| \_|  |_/ \___||_| |_| \__,_|
                                                                        
                                                                       ");
        Console.WriteLine("--------------------------------------------------------------------------------");
        bool exit = false;
        while (exit == false)
        {
            Console.WriteLine("[1] Check total reservations ");
            Console.WriteLine("[2] Check total revenue");
            Console.WriteLine("[3] Exit");
            Console.WriteLine("--------------------------------------------------------------------------------");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine(FinancialLogic.TotalReservations);
                    break;
                case "2":
                    Console.WriteLine(FinancialLogic.TotalRevenue);
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
    }
}

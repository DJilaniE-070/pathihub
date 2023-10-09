public class FinancialMenu
{
    public bool exit = false;

    public FinancialMenu()
    {
    Console.WriteLine(@"
______ _                        _           _  ___  ___                 
|  ___(_)                      (_)         | | |  \/  |                 
| |_   _ _ __   __ _ _ __   ___ _  ___  ___| | | .  . | ___ _ __  _   _ 
|  _| | | '_ \ / _` | '_ \ / __| |/ _ \/ _ \ | | |\/| |/ _ \ '_ \| | | |
| |   | | | | | (_| | | | | (__| |  __/  __/ | | |  | |  __/ | | | |_| |
\_|   |_|_| |_|\__,_|_| |_|\___|_|\___|\___|_| \_|  |_/\___|_| |_|\__,_|
                                                                        
                                                                       ");
    }

    public void WriteFinancial()
    {
        while (exit == false)
        {
            Console.WriteLine("[1] Bekijk aantal reserveringen");
            Console.WriteLine("[2] Bekijk opbrengsten reserveringen");
            Console.WriteLine("[3] Exit");
            string input =  Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine(FinancialLogic.AantalReserveringen);
                    break;
                case "2":
                    Console.WriteLine(FinancialLogic.AlleOpbrengsten);
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

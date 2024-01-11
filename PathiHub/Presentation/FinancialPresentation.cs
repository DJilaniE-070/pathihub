public static class FinancialPresentation
{
    public static void start()
    {
        Helpers.PrintStringToColor( @"
______                               _   _                 
| ___ \                             | | (_)                
| |_/ /___  ___  ___ _ ____   ____ _| |_ _  ___  _ __  ___ 
|    // _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \/ __|
| |\ \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | \__ \
\_| \_\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|___/

","yellow");
        FinancialLogic logic = new();
        logic.start();
        Console.WriteLine("============================================");
        Console.WriteLine("|              Overview                    |");
        Console.WriteLine("|------------------------------------------|");
        Console.WriteLine($"| Total Sum of Prices (With Tax): €{logic.totalSum,-7:F2} |");
        Console.WriteLine("|------------------------------------------|");
        Console.WriteLine($"| Total Without Tax: €{logic.totalWithoutTax,-20:F2} |");
        Console.WriteLine("|------------------------------------------|");
        Console.WriteLine($"| {logic.taxRate * 100}% of Total: €{logic.Tax,-26:F2} |");
        Console.WriteLine("============================================");
        Helpers.PrintStringToColor("Press ENTER to return to Your menu","yellow");
        Helpers.Color("Yellow");
        Helpers.BackToYourMenu();
    }
}
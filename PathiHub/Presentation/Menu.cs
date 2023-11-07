public static class Menu
{
    // dit is het scherm is word puur gebruikt als eerste scherm
    public static void Start()
    {
        PrintStringToColor.Color(
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

        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("Press enter to continue");
        
        
        

        ConsoleKeyInfo keyPressed = Console.ReadKey();
        if (keyPressed.Key == ConsoleKey.Enter)
        {
            
            Console.Write("Loading");
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(500); // Wacht 500 milliseconden (0,5 seconden)
                Console.Write(".");
            }
            Console.WriteLine();
            Console.WriteLine("Loading Completed.");
            Thread.Sleep(1000);
            
            Console.Clear();
            SwitchMenu.Start();
        }
        
        else
        {
            Thread.Sleep(500);
            Console.WriteLine(" : is an invalid key. Please try again.");
            Thread.Sleep(1500);
            Console.WriteLine("Please press the enter key to continue");
            Thread.Sleep(2000);
            Console.Clear();
            Menu.Start();


        }
    }
}



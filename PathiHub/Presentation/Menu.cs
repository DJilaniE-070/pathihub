static class Menu
{
    // dit is het scherm is word puur gebruikt als eerste scherm
    static public void Start()
    {


        Console.WriteLine(@"
 ____          __    __              __  __           __        
/\  _`\       /\ \__/\ \      __    /\ \/\ \         /\ \       
\ \ \L\ \ __  \ \ ,_\ \ \___ /\_\   \ \ \_\ \  __  __\ \ \____  
 \ \ ,__/'__`\ \ \ \/\ \  _ `\/\ \   \ \  _  \/\ \/\ \\ \ '__`\ 
  \ \ \/\ \L\.\_\ \ \_\ \ \ \ \ \ \   \ \ \ \ \ \ \_\ \\ \ \L\ \
   \ \_\ \__/.\_\\ \__\\ \_\ \_\ \_\   \ \_\ \_\ \____/ \ \_,__/
    \/_/\/__/\/_/ \/__/ \/_/\/_/\/_/    \/_/\/_/\/___/   \/___/ ");

        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("featured films:");
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
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500); // Wacht 500 milliseconden (0,5 seconden)
                Console.Write(".");
            }
            Console.WriteLine();
            Console.WriteLine("Loading Completed.");
            Thread.Sleep(1000);
            
            Console.Clear();
            UserLogin.Start();
        }
        
        else
        {
            Console.WriteLine("Invalid key. Please try again.");


        }
    }
}

    
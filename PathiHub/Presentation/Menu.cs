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
        Console.WriteLine("Uitgelichte films:");
        Console.WriteLine();
        
        
        //print elke promoted movie van list
        Console.WriteLine("The Avengers");
        Console.WriteLine("Movie test 2");
        Console.WriteLine("Five Guys 3");
        
        Thread.Sleep(5000);
        UserLogin.Start();
        
        }
    }

    
public class PromotionsMenu
{
    public bool exit = false;

    public PromotionsMenu()
    {
        //voeg promotie films aan lijst PromotedMovie
        //print de beginscherm
        WriteMenu();
    }

    public void WriteMenu()
    {
        Console.WriteLine(@"
 ____          __    __              __  __           __        
/\  _`\       /\ \__/\ \      __    /\ \/\ \         /\ \       
\ \ \L\ \ __  \ \ ,_\ \ \___ /\_\   \ \ \_\ \  __  __\ \ \____  
 \ \ ,__/'__`\ \ \ \/\ \  _ `\/\ \   \ \  _  \/\ \/\ \\ \ '__`\ 
  \ \ \/\ \L\.\_\ \ \_\ \ \ \ \ \ \   \ \ \ \ \ \ \_\ \\ \ \L\ \
   \ \_\ \__/.\_\\ \__\\ \_\ \_\ \_\   \ \_\ \_\ \____/ \ \_,__/
    \/_/\/__/\/_/ \/__/ \/_/\/_/\/_/    \/_/\/_/\/___/   \/___/ ");
        Console.WriteLine();
        Console.WriteLine("Uitgelichte films:");
        Console.WriteLine();
        //print elke promoted movie van list
        Console.WriteLine("The Avengers");
        Console.WriteLine("Movie test 2");
        Console.WriteLine("Five Guys 3");
        //input loop
        while (exit == false)
        {
            Console.WriteLine();
            Console.WriteLine("[1] Ga verder als gast");
            Console.WriteLine("[2] Maak een nieuwe account");
            Console.WriteLine("[3] Login");
            Console.WriteLine("[4] Exit");
            string input =  Console.ReadLine();
            switch (input)
            {
                case "1":
                    //GuestMenu();
                    break;
                case "2":
                    //CreateAccount();
                    break;
                case "3":
                    //Login();
                    break;
                case "4":
                    exit = true;
                    break;
                default: 
                    Console.WriteLine("Invalid");
                    break;
            }
        }
    }
}

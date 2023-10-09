namespace PathiHub.Presentation;

public class UserMenu
{
    static void Start()
    {
        int choice;
        bool exit = false;
        
        do
        {
            Console.WriteLine(@"
 _   _                   ___  ___                    
| | | |                  |  \/  |                    
| | | | ___   ___  _ __  | .  . |  ___  _ __   _   _ 
| | | |/ __| / _ \| '__| | |\/| | / _ \| '_ \ | | | |
| |_| |\__ \|  __/| |    | |  | ||  __/| | | || |_| |
 \___/ |___/ \___||_|    \_|  |_/ \___||_| |_| \__,_|
                                                     
                                                     
");
            
            
            Console.WriteLine("[1]. Reserve a seat");
            Console.WriteLine("[2]. Check reservation");
            Console.WriteLine("[3]. Cancel reservation");
            Console.WriteLine("[4]. Exit");
            Console.WriteLine("Please enter your choice (1-4):");
            
            // Get user input
            // Assuming the input is an integer between 1 and 4
            choice = Convert.ToInt32(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    ReserveSeat();
                    Console.WriteLine("needs to be implemented");
                    break;
                case 2:
                    CheckReservation();
                    Console.WriteLine("needs to be implemented");
                    break;
                case 3:
                    CancelReservation();
                    Console.WriteLine("needs to be implemented");
                    break;
                case 4:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            
            Console.WriteLine();
        } while (!exit);
        
        Console.WriteLine("Thank you for using the Cinema Reservation System. Goodbye!");

        
        static void ReserveSeat()
        {
            Console.WriteLine("Reserve a seat");
            Console.WriteLine("Here comes the implementations in a later sprint");
        }

       
        static void CheckReservation()
        {
            
            Console.WriteLine("Check reservation");
            Console.WriteLine("Here comes the implementations in a later sprint");
        }

        
        static void CancelReservation()
        {
            
            Console.WriteLine("Cancel reservation");
            Console.WriteLine("Here comes the implementations in a later sprint");
        }
    }
}

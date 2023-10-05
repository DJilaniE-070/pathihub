
using System;
class Program
{
    static void Main()
    {
        int choice;
            
        
        do
        {
            Console.WriteLine(@"
___  ___                                   ___  ___                 
|  \/  |                                   |  \/  |                 
| .  . | __ _ _ __   __ _  __ _  ___ _ __  | .  . | ___ _ __  _   _ 
| |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__| | |\/| |/ _ \ '_ \| | | |
| |  | | (_| | | | | (_| | (_| |  __/ |    | |  | |  __/ | | | |_| |
\_|  |_/\__,_|_| |_|\__,_|\__, |\___|_|    \_|  |_/\___|_| |_|\__,_|
                           __/ |                                    
                          |___/                                     
                                                     
"); 
            
            
            Console.WriteLine("1. Film opties");
            Console.WriteLine("2. Film reserveren");
            Console.WriteLine("3. Reservering opties");
            Console.WriteLine("4. Financiele opties");
            Console.WriteLine("5. Snacks opties");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Please enter your choice (1-6):");
            
            choice = Convert.ToInt32(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    Film_options();
                    break;
                case 2:
                    Order_film();
                    break;
                case 3:
                    Reservations_options();
                    break;
                case 4:
                    Financial_options();
                    break;
                case 5:
                    Snacks();
                    break;                                        
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            
            Console.WriteLine();
        } while (!exit);
        
        Console.WriteLine("Thank you for using the Cinema Reservation System. Goodbye!");

        
        static void Film_options()
        {
            Console.WriteLine("Film options");
        }

       
        static void Order_film()
        {
            
            Console.WriteLine("Order a movie");
        }

        
        static void Reservations_options()
        {
            
            Console.WriteLine("Reservation options");
        }
        static void Financial_options()
        {
            
            Console.WriteLine("Financial options");
        }
        static void Snacks()
        {
            
            Console.WriteLine("Snacks options");
        }                
    }
}

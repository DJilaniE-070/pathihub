
using System;

public class Manager_menu
{
    public static void Managerstart()
    {
        int choice;
        bool exit = false;
        
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
            
            
            Console.WriteLine("[1] Film options");
            Console.WriteLine("[2] Reserve movie");
            Console.WriteLine("[3] Reservation options");
            Console.WriteLine("[4] Financial options");
            Console.WriteLine("[5] Snacks options");
            Console.WriteLine("[6] Exit");
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
            while (true)
            {
            Console.WriteLine("\n\n");
            Console.WriteLine("[1] Add a movie");
            Console.WriteLine("[2] Remove a movie");
            Console.WriteLine("[3] Return to Manager menu");
            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                Movie_option_presentation.Add_movie_presentation();
            }
            else if (option == 2)
            {
                Movie_option_presentation.Remove_movie();
            }
            else if (option == 3)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
            }
        }
        

       
        static void Order_film()
        {
            
            Console.WriteLine("Order a movie");
        }

        static void Reservations_options()
        {
            
            Console.WriteLine("Reservations options: ");
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

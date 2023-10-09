class Program
{
    static void Main()
    {
        int choice;
        bool exit = false;

        do
        {
            Console.WriteLine(@"
    _____           _    _               _                  ___  ___                    
    /  __ \         | |  | |             | |                 |  \/  |                    
    | /  \/  ___    | |  | |  ___   _ __ | | __  ___  _ __   | .  . |  ___  _ __   _   _ 
    | |     / _ \   | |/\| | / _ \ | '__|| |/ / / _ \| '__|  | |\/| | / _ \| '_ \ | | | |
    | \__/\| (_) |  \  /\  /| (_) || |   |   < |  __/| |     | |  | ||  __/| | | || |_| |
    \____/ \___/    \/  \/  \___/ |_|   |_|\_\ \___||_|     \_|  |_/ \___||_| |_| \__,_|
                                                                                        
    ");

            Console.WriteLine("[1] Overview all reservations");
            Console.WriteLine("[2] Change reservations");
            Console.WriteLine("[3] Reservate seat for customer");
            Console.WriteLine("[4] Insight total orders");
            Console.WriteLine("[5] Exit Co Worker Menu");
            Console.WriteLine("Enter choice: ");
            
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    OverviewAllReservations();
                    break;

                case 2:
                    ChangeReservations();
                    break;

                case 3:
                    ReservateSeatCustomer();
                    break;

                case 4:
                    InsightTotalOrders();
                    break;
                
                case 5:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            Console.WriteLine();
        }

        while (!exit);
        {
            Console.WriteLine("Thank you for using the Cinema CoWorker System. Bye");
        }

        static void OverviewAllReservations()
        {
            Console.WriteLine("Overview of all reservations");
        }

        static void ChangeReservations()
        {
            Console.WriteLine("Change reservations");
        }

        static void ReservateSeatCustomer()
        {
            Console.WriteLine("Reservate a seat for a customer");
        }

        static void InsightTotalOrders()
        {
            Console.WriteLine("Insight of total orders");
        }
    }
}

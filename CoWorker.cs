class CoWorker
{
    public void Main()
    {
Console.WriteLine(@"
 _____           _    _               _                  ___  ___                    
/  __ \         | |  | |             | |                 |  \/  |                    
| /  \/  ___    | |  | |  ___   _ __ | | __  ___  _ __   | .  . |  ___  _ __   _   _ 
| |     / _ \   | |/\| | / _ \ | '__|| |/ / / _ \| '__|  | |\/| | / _ \| '_ \ | | | |
| \__/\| (_) |  \  /\  /| (_) || |   |   < |  __/| |     | |  | ||  __/| | | || |_| |
 \____/ \___/    \/  \/  \___/ |_|   |_|\_\ \___||_|     \_|  |_/ \___||_| |_| \__,_|
                                                                                     
");
        while (true)
        {
            Console.WriteLine("[1] Overview all reservations");
            Console.WriteLine("[2] Change reservations");
            Console.WriteLine("[3] Reservate seat for customer");
            Console.WriteLine("[4] Insight total orders");
            Console.WriteLine("Enter choice: ");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

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

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }
    }

    public void OverviewAllReservations()
    {
        Console.WriteLine("Overview of all reservations");
    }

    public void ChangeReservations()
    {
        Console.WriteLine("Change reservations");
    }

    public void ReservateSeatCustomer()
    {
        Console.WriteLine("Reservate a seat for a customer");
    }

    public void InsightTotalOrders()
    {
        Console.WriteLine("Insight of total orders");
    }
}

class Program
{
    static void Main()
    {
        CoWorker coWorker = new CoWorker();
        coWorker.Main();
    }
}
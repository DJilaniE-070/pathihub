public static class ReservationPresentation
{
    public static void AddReservation()
    {
        Console.Clear();
        Console.WriteLine(@"
______                               _   _                     
| ___ \                             | | (_)                _   
| |_/ /___  ___  ___ _ ____   ____ _| |_ _  ___  _ __    _| |_ 
|    // _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \  |_   _|
| |\ \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | |   |_|  
\_| \_\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|        
                                                               
                                                               ");

        Console.WriteLine("\n\n\n");

        Reservation reservation = new Reservation();
        
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.Write("Enter Your Full name (First and LastName): ");
        reservation.FullName = Helpers.Color("DarkYellow");

        Console.Write("Enter your Email: ");
        reservation.Email = Helpers.Color("DarkYellow");


        Console.Write("Enter wich Auditorium:  ");
        reservation.Auditorium = Helpers.Color("DarkYellow");


        Console.Write("Enter SeatNumber: ");
        reservation.SeatName = Helpers.Color("DarkYellow");
        
        Console.Write("Enter name of the Movie ");
        reservation.movie = Helpers.Color("DarkYellow");

        Console.Write("Price of the Movie ");
        reservation.Price = Convert.ToInt32(Helpers.Color("DarkYellow"));

        Console.Write("Enter CinemaLocation ");
        reservation.movie = Helpers.Color("DarkYellow");

        // Random ran = new Random();
        //
        // string b = "abcdefghijklmnopqrstuvwxyz0123456789";
        // string sc = "!@#$%^&*~";
        //
        // int length = 6;
        //
        // string random = "";
        //
        // for(int i =0; i<length; i++)
        // {
        //     int a = ran.Next(b.Length); //string.Lenght gets the size of string
        //     random = random + b.ElementAt(a);
        // }
        //
        // for(int j =0; j<2; j++)
        // {
        //     int sz = ran.Next(sc.Length); 
        //     random = random + sc.ElementAt(sz);
        // }
        
        // generate a unique code
        //TODO: This is broken
        string random = Guid.NewGuid().ToString();

        while (MakeReservation.CheckUniqueCode(random))
        {
            random = Guid.NewGuid().ToString().Substring(0, 6);
        }

        reservation.ReservationCode = random;

        Console.WriteLine("Your unique reservation code is: {0}", random);

       ReservationAccess reservations = new ReservationAccess();
        if (reservations.LoadFromJson() == true)
        {
            MakeReservation Option = new MakeReservation(reservations.GetItemList());
            if (Option.AddReservation(reservation) != true)
            {
                Helpers.PrintStringToColor("\nMovie already exits\n","red");
            }
            else
            {
                Helpers.PrintStringToColor($"\n+ {reservation.ReservationCode} for {reservation.FullName}  has been added\n","green");
                reservations.SaveToJson();
            }

        Console.WriteLine("Press ENTER to continue");
        string Enter = Console.ReadLine();

        }
        else
        {
            Helpers.PrintStringToColor("File not found. No movies loaded.\n", "red");
            Console.WriteLine("Press ENTER to continue");
            string enter = Console.ReadLine();
        }
    }   

        public static void RemoveMoviePresentation()
        {
            Console.WriteLine(@"
______                               ______                               _   _                      
| ___ \                              | ___ \                             | | (_)                     
| |_/ /___ _ __ ___   _____   _____  | |_/ /___  ___  ___ _ ____   ____ _| |_ _  ___  _ __    ______ 
|    // _ \ '_ ` _ \ / _ \ \ / / _ \ |    // _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \  |______|
| |\ \  __/ | | | | | (_) \ V /  __/ | |\ \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | |         
\_| \_\___|_| |_| |_|\___/ \_/ \___| \_| \_\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|        ");

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.Write("\n\nFullName on the ticket. You want to remove: ");
            string FullName = Helpers.Color("DarkYellow");
            Console.Write("\nName of the movie You want to remove: ");
            string movie = Helpers.Color("DarkYellow");
            Console.Write("\n Your email: ");
            string email = Helpers.Color("DarkYellow");
            ReservationAccess acces = new ReservationAccess();
            if (acces.LoadFromJson() == true)
            {
                MakeReservation Option = new MakeReservation(acces.GetItemList());
                if (Option.RemoveReservation(FullName,email, movie) == false)
                {
                    Helpers.PrintStringToColor("\nReservation doesn't exist", "red");

                }
                else
                {  
                    acces.SaveToJson();
                    Helpers.PrintStringToColor($"\n- Reservation for {FullName} has been removed\n", "red");
                }
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();  
            }
            else
            {
            Console.WriteLine("File not found. No movies loaded.");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            }
        }

    public static void EditReservationPresentation()
    {
        List<string> ColomnNames = new(){"FullName", "ReservationCode",
        "Email", "Date", "Price"};
        string HeaderX = @"
______                               _   _                 
| ___ \                             | | (_)                
| |_/ /___  ___  ___ _ ____   ____ _| |_ _  ___  _ __  ___ 
|    // _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \/ __|
| |\ \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | \__ \
\_| \_\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|___/

";
        PerformActionToTabel.Editor(HeaderX,"Reservation", ColomnNames);
    }
    public static void ShowReservations()
    {
    string HeaderX = @"
______                               _   _                 
| ___ \                             | | (_)                
| |_/ /___  ___  ___ _ ____   ____ _| |_ _  ___  _ __  ___ 
|    // _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \/ __|
| |\ \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | \__ \
\_| \_\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|___/

";
    ReservationAccess access = new();
    List<string> ColomnNames = new(){"FullName", "ReservationCode",
        "Email", "Date", "Price"};
    if(access.LoadFromJson()!= false)
    {
    List<Reservation> reservations = access.GetItemList();
    ObjCatalogePrinter.TabelPrinter(HeaderX, reservations, ColomnNames);
    }
    }
    }

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
        reservation.FullName = WriteInputColor.Color("DarkYellow");

        Console.Write("Enter your Email: ");
        reservation.Email = WriteInputColor.Color("DarkYellow");

        Console.Write("Enter wich Auditorium:  ");
        reservation.Auditorium = WriteInputColor.Color("DarkYellow");

        Console.Write("Enter SeatNumber: ");
        reservation.SeatName = WriteInputColor.Color("DarkYellow");
        
        Console.Write("Enter name of the Movie ");
        reservation.movie = WriteInputColor.Color("DarkYellow");

        Console.Write("Price of the Movie ");
        reservation.Price = Convert.ToInt32(WriteInputColor.Color("DarkYellow"));

        Console.Write("Enter CinemaLocation ");
        reservation.movie = WriteInputColor.Color("DarkYellow");

        Random ran = new Random();
    
        string b = "abcdefghijklmnopqrstuvwxyz0123456789";
        string sc = "!@#$%^&*~";

        int length = 6;

        string random = "";

        for(int i =0; i<length; i++)
                        {
                                    int a = ran.Next(b.Length); //string.Lenght gets the size of string
                                    random = random + b.ElementAt(a);
                        }
        for(int j =0; j<2; j++)
                        {
                                    int sz = ran.Next(sc.Length); 
                                    random = random + sc.ElementAt(sz);
                        }

        reservation.ReservationCode = random;

        Console.WriteLine("Your unique reservation code is: {0}", random);

       ReservationAcces reservations = new ReservationAcces();
        if (reservations.LoadReservationFromJson() == true)
        {
            MakeReservation Option = new MakeReservation(reservations.reservationlist);
            if (Option.AddReservation(reservation) != true)
            {
                PrintStringToColor.Color("\nMovie already exits\n","red");
            }
            else
            {
                PrintStringToColor.Color($"\n+ {reservation.ReservationCode} for {reservation.FullName}  has been added\n","green");
                reservations.SaveReservationToJson();
            }

        Console.WriteLine("Press ENTER to continue");
        string Enter = Console.ReadLine();

        }
        else
        {
            PrintStringToColor.Color("File not found. No movies loaded.\n", "red");
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
            string FullName = WriteInputColor.Color("DarkYellow");
            Console.Write("\nName of the movie You want to remove: ");
            string movie = WriteInputColor.Color("DarkYellow");
            Console.Write("\n Your email: ");
            string email = WriteInputColor.Color("DarkYellow");
            ReservationAcces acces = new ReservationAcces();
            if (acces.LoadReservationFromJson() == true)
            {
                MakeReservation Option = new MakeReservation(acces.reservationlist);
                if (Option.RemoveReservation(FullName,email, movie) == false)
                {
                    PrintStringToColor.Color("\nReservation doesn't exist", "red");

                }
                else
                {  
                    acces.SaveReservationToJson();
                    PrintStringToColor.Color($"\n- Reservation for {FullName} has been removed\n", "red");
                }
            Console.WriteLine("Press ENTER to continue");
            string Enter = Console.ReadLine();  
            }
            else
            {
            Console.WriteLine("File not found. No movies loaded.");
            Console.WriteLine("Press ENTER to continue");
            string enter = Console.ReadLine();
            }
        }
        public static void AllReservations()
        {
            Console.WriteLine(@"
 _____  _                         ___   _  _  ______                                       _    _                    
/  ___|| |                       / _ \ | || | | ___ \                                     | |  (_)                   
\ `--. | |__    ___  __      __ / /_\ \| || | | |_/ /  ___  ___   ___  _ __ __   __  __ _ | |_  _   ___   _ __   ___ 
 `--. \| '_ \  / _ \ \ \ /\ / / |  _  || || | |    /  / _ \/ __| / _ \| '__|\ \ / / / _` || __|| | / _ \ | '_ \ / __|
/\__/ /| | | || (_) | \ V  V /  | | | || || | | |\ \ |  __/\__ \|  __/| |    \ V / | (_| || |_ | || (_) || | | |\__ \
\____/ |_| |_| \___/   \_/\_/   \_| |_/|_||_| \_| \_| \___||___/ \___||_|     \_/   \__,_| \__||_| \___/ |_| |_||___/ ");
            Console.WriteLine("--------------------------------------------------------------------------------");

            List<Reservation> reservations = new List<Reservation>();

            Console.WriteLine("All reservations: ");

            foreach (var reservation in reservations)
            {
                Console.WriteLine($"Full name: {reservation.FullName}");
                Console.WriteLine($"Email: {reservation.Email}");
                Console.WriteLine($"Auditorium: {reservation.Auditorium}");
                Console.WriteLine($"Seat name: {reservation.SeatName}");
                Console.WriteLine($"Movie: {reservation.movie}");
                Console.WriteLine($"Date: {reservation.Date}");
                Console.WriteLine($"Price: {reservation.Price}");
                Console.WriteLine($"Reservation code: {reservation.ReservationCode}");
                Console.WriteLine($"Cinema location: {reservation.CinemaLocation}\n");
            }
        }
    }

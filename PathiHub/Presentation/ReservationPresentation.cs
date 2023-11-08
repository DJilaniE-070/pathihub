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
    }

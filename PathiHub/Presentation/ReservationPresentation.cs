public static class ReservationPresentation
{
    public static void AddReservationAutomatically()
    {
        Console.Clear();
        Helpers.PrintStringToColor(@"
______                               _   _                     
| ___ \                             | | (_)                _   
| |_/ /___  ___  ___ _ ____   ____ _| |_ _  ___  _ __    _| |_ 
|    // _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \  |_   _|
| |\ \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | |   |_|  
\_| \_\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|        
                                                               
                                                               ","Yellow");

        Console.WriteLine("\n\n\n");

        Reservation reservation = new Reservation();
        
        Console.WriteLine("--------------------------------------------------------------------------------");
        reservation.FullName = Helpers.CurrentAccount.FullName;
        // reservation.FullName = Helpers.Color("DarkYellow");

        // reservation.Email = Helpers.Color("DarkYellow");
        reservation.Email = Helpers.CurrentAccount.EmailAddress;

        // Auditorium
        // reservation.Auditorium = Helpers.Color("DarkYellow");
        reservation.Auditorium = MovieSchedule.Selectedauditorium.ToString();
        string[] parts = MovieSchedule.SelectedSchedule.Split('/');
            if (parts.Length == 3)
            {
                string day = parts[0];
                string time = parts[1];
                reservation.Date = day;
                reservation.Time = time;
            }
 
        // Seat
        // reservation.SeatName = Helpers.Color("DarkYellow");
        reservation.SeatNames = SeatMap.SelectedSeats;
        
        reservation.movie = MovieSchedule.SelectedMovie.MovieTitle;
        // reservation.movie = Helpers.Color("DarkYellow");

        reservation.Price = SeatMap.TotalPrice;
        // reservation.Price = Convert.ToInt32(Helpers.Color("DarkYellow"));
        
        // Cinema location;
        // reservation.CinemaLocation = Helpers.Color("DarkYellow");
        
        // generate a unique code
        //TODO: This is broken
        string random = Guid.NewGuid().ToString();

        while (!MakeReservation.CheckUniqueCode(random))
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
                Helpers.PrintStringToColor("\nReservation already exits\n","red");
            }
            else
            {
                Helpers.Ticketdisplay(reservation);
                Helpers.PrintStringToColor($"\n+ {reservation.ReservationCode} for {reservation.FullName}  has been added\n","green");
                reservations.SaveToJson();
                Email.start(reservation,Helpers.CurrentAccount);
                SeatMap.SelectedSeats.Clear();

            }

        Console.WriteLine("Press ENTER to continue");
        Helpers.Color("yellow");
        Helpers.BackToYourMenu();

        }
        else
        {
            Helpers.PrintStringToColor("File not found. No movies loaded.\n", "red");
            Console.WriteLine("Press ENTER to continue");
            Helpers.Color("yellow");
            Helpers.BackToYourMenu();
        }
    } 
    
    
    public static void AddReservation()
    {
        Console.Clear();
        Helpers.PrintStringToColor(@"
______                               _   _                     
| ___ \                             | | (_)                _   
| |_/ /___  ___  ___ _ ____   ____ _| |_ _  ___  _ __    _| |_ 
|    // _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \  |_   _|
| |\ \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | |   |_|  
\_| \_\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|        
                                                               
                                                               ","Yellow");

        Console.WriteLine("\n\n\n");

        Reservation reservation = new Reservation();
        
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("Getting your Full name (First and LastName): ");
        reservation.FullName = Helpers.Color("Yellow");
        // reservation.FullName = Helpers.Color("DarkYellow");

        Console.WriteLine("Getting your Email: ");
        // reservation.Email = Helpers.Color("DarkYellow");
        reservation.Email = Helpers.Color("Yellow");

        // Auditorium
        // reservation.Auditorium = Helpers.Color("DarkYellow");
        reservation.Auditorium = MovieSchedule.Selectedauditorium.ToString();
        
        // Seat
        // reservation.SeatName = Helpers.Color("DarkYellow");
        reservation.SeatNames = SeatMap.SelectedSeats;
        
        reservation.movie = MovieSchedule.SelectedMovie.MovieTitle;
        // reservation.movie = Helpers.Color("DarkYellow");
        string[] parts = MovieSchedule.SelectedSchedule.Split('/');
            if (parts.Length == 3)
            {
                string day = parts[0];
                string time = parts[1];
                reservation.Date = day;
                reservation.Time = time;
            }

        reservation.Price = SeatMap.TotalPrice;

        string random = Guid.NewGuid().ToString();

        while (!MakeReservation.CheckUniqueCode(random))
        {
            random = Guid.NewGuid().ToString().Substring(0, 6);
        }

        reservation.ReservationCode = random;


       ReservationAccess reservations = new ReservationAccess();
        if (reservations.LoadFromJson() == true)
        {
            MakeReservation Option = new MakeReservation(reservations.GetItemList());
            if (Option.AddReservation(reservation) != true)
            {
                Helpers.PrintStringToColor("\nReservation already exits\n","red");
            }
            else
            {
                Helpers.Ticketdisplay(reservation);
                Helpers.PrintStringToColor($"\n+ {reservation.ReservationCode} for {reservation.FullName}  has been added\n","green");
                reservations.SaveToJson();
                Email.manualstart(reservation, reservation.FullName, reservation.Email);
                SeatMap.SelectedSeats.Clear();

            }

        Console.WriteLine("Press ENTER to continue");
        Helpers.Color("yellow");
        Helpers.BackToYourMenu();

        }
        else
        {
            Helpers.PrintStringToColor("File not found. No movies loaded.\n", "red");
            Console.WriteLine("Press ENTER to continue");
           Helpers.Color("yellow");
            Helpers.BackToYourMenu();
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
            Helpers.Color("Yellow");  
            }
            else
            {
            Console.WriteLine("File not found. No movies loaded.");
            Console.WriteLine("Press ENTER to continue");
            Helpers.Color("Yellow");
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
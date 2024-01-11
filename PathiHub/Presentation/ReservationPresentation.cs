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
            string HeaderX = (@"
______                               ______                               _   _                      
| ___ \                              | ___ \                             | | (_)                     
| |_/ /___ _ __ ___   _____   _____  | |_/ /___  ___  ___ _ ____   ____ _| |_ _  ___  _ __    ______ 
|    // _ \ '_ ` _ \ / _ \ \ / / _ \ |    // _ \/ __|/ _ \ '__\ \ / / _` | __| |/ _ \| '_ \  |______|
| |\ \  __/ | | | | | (_) \ V /  __/ | |\ \  __/\__ \  __/ |   \ V / (_| | |_| | (_) | | | |         
\_| \_\___|_| |_| |_|\___/ \_/ \___| \_| \_\___||___/\___|_|    \_/ \__,_|\__|_|\___/|_| |_|        ");

        ReservationAccess access = new();
        List<string> ColomnNames = new() {"FullName", "Auditorium", "SeatNames", "Date", "Time", "Price", "ReservationCode"};
        if(access.LoadFromJson()!= false)
        {
            List<Reservation> reservations = access.GetItemList();
            Reservation reservation;
            if (Helpers.CurrentAccount.Role == "User")
            {
            List<Reservation> sortedReservations = reservations
                .Where(r => r.Email == Helpers.CurrentAccount.EmailAddress)
                .OrderBy(r => r.FullName)
                .ToList(); 
            reservation = (Reservation)ObjCatalogePrinter.TabelPrinter(HeaderX, sortedReservations, ColomnNames);

            }
            else
            {
            reservation = (Reservation)ObjCatalogePrinter.TabelPrinter(HeaderX, reservations, ColomnNames);
            }
            MakeReservation Option = new MakeReservation(reservations);

            if (!Option.RemoveReservation(reservation.FullName, reservation.Email, reservation.movie))
                {
                    Helpers.PrintStringToColor("\nReservation doesn't exist", "red");

                }
                else
                {  
                    int auditorium = Convert.ToInt32(reservation.Auditorium);
                    string time = $"{reservation.Date}/{reservation.Time}/Aud{reservation.Auditorium}";
                    ScheduleAcces scheduleAcces = new(auditorium);
                    if (scheduleAcces.LoadFromJson()!= false)
                    {
                    List<Schedule> WholeSchedule = scheduleAcces.GetItemList();
                    Schedule scheduleToModify = WholeSchedule.Find(s =>
                        s.MovieTitle == reservation.movie && s.Scheduled == time);
                    
                    foreach (string indexPair in reservation.SeatNames)
                    {
                        string[] indices = indexPair.Split(' ');
                        if (indices.Length == 2 && int.TryParse(indices[0], out int listIndexFromEnd) && int.TryParse(indices[1], out int elementIndex))
                        {
                            // Convert the list index from the end
                            int listIndex = scheduleToModify.StoredAuditorium.Count - listIndexFromEnd;

                            // Check if the list index and element index are valid
                            if (listIndex >= 0 && listIndex < scheduleToModify.StoredAuditorium.Count && elementIndex >= 0 && elementIndex < scheduleToModify.StoredAuditorium[listIndex].Count)
                            {
                                string currentValue = scheduleToModify.StoredAuditorium[listIndex][elementIndex];
                                if (currentValue == "AR")
                                {
                                    scheduleToModify.StoredAuditorium[listIndex][elementIndex] = "A";
                                }
                                else if (currentValue == "BR")
                                {
                                    scheduleToModify.StoredAuditorium[listIndex][elementIndex] = "B";
                                }
                                else if (currentValue == "CR")
                                {
                                    scheduleToModify.StoredAuditorium[listIndex][elementIndex] = "C";
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Invalid indices: {indexPair}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid format: {indexPair}");
                        }
                    }
                    scheduleAcces.SaveToJson();
                    access.SaveToJson();
                    Helpers.PrintStringToColor($"\n- Reservation for {reservation.FullName} has been removed\n", "red");
                    }
                }
            Console.WriteLine("Press ENTER to continue");
            Helpers.Color("Yellow");  
            Helpers.BackToYourMenu();
            }
            else
            {
            Console.WriteLine("File not found. No movies loaded.");
            Console.WriteLine("Press ENTER to continue");
            Helpers.Color("Yellow");
            Helpers.BackToYourMenu();
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
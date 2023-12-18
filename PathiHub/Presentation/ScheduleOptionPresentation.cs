public class ScheduleOption
{
    public ScheduleOption(bool select)
    {
        if (select)
        {
            Add = true;
        }
        else
        {
        Remove = true;
        }
    }
    bool Remove;
    bool Add;


    
    ScheduleAcces accesAud1 = new(1);
    ScheduleAcces accesAud2 = new(2);
    ScheduleAcces accesAud3 = new(3);

    List<Schedule> Aud1;
    List<Schedule> Aud2;
    List<Schedule> Aud3;
    public List<Schedule> SelectedSchedules = new List<Schedule>();
    public List<int> SelectedAuds = new();
    ConsoleKeyInfo key;
    Schedule SelectedSchedule = null;
    int SelectedAud;
            string HeaderRem = @"
______                                           _____      _              _       _      
| ___ \                                         /  ___|    | |            | |     | |     
| |_/ /___ _ __ ___   _____   _____             \ `--.  ___| |__   ___  __| |_   _| | ___ 
|    // _ \ '_ ` _ \ / _ \ \ / / _ \  ______     `--. \/ __| '_ \ / _ \/ _` | | | | |/ _ \
| |\ \  __/ | | | | | (_) \ V /  __/ |______|   /\__/ / (__| | | |  __/ (_| | |_| | |  __/
\_| \_\___|_| |_| |_|\___/ \_/ \___|            \____/ \___|_| |_|\___|\__,_|\__,_|_|\___|
                                                                                        
                                                                                        ";
            string HeaderAdd = @"
  ___      _     _         _____      _              _       _      
 / _ \    | |   | |  _    /  ___|    | |            | |     | |     
/ /_\ \ __| | __| |_| |_  \ `--.  ___| |__   ___  __| |_   _| | ___ 
|  _  |/ _` |/ _` |_   _|  `--. \/ __| '_ \ / _ \/ _` | | | | |/ _ \
| | | | (_| | (_| | |_|   /\__/ / (__| | | |  __/ (_| | |_| | |  __/
\_| |_/\__,_|\__,_|       \____/ \___|_| |_|\___|\__,_|\__,_|_|\___|
                                                                    
                                                                    ";

        string Header1 = @"
  ___            _ _ _             _                   _____ 
 / _ \          | (_) |           (_)                 |_   _|
/ /_\ \_   _  __| |_| |_ ___  _ __ _ _   _ _ __ ___     | |  
|  _  | | | |/ _` | | __/ _ \| '__| | | | | '_ ` _ \    | |  
| | | | |_| | (_| | | || (_) | |  | | |_| | | | | | |  _| |_ 
\_| |_/\__,_|\__,_|_|\__\___/|_|  |_|\__,_|_| |_| |_|  \___/ 
                                                             
                                                             ";
        string Header2 = @" 
  ___            _ _ _             _                   _____ _____ 
 / _ \          | (_) |           (_)                 |_   _|_   _|
/ /_\ \_   _  __| |_| |_ ___  _ __ _ _   _ _ __ ___     | |   | |  
|  _  | | | |/ _` | | __/ _ \| '__| | | | | '_ ` _ \    | |   | |  
| | | | |_| | (_| | | || (_) | |  | | |_| | | | | | |  _| |_ _| |_ 
\_| |_/\__,_|\__,_|_|\__\___/|_|  |_|\__,_|_| |_| |_|  \___/ \___/ 
                                                                   
                                                                   
                                                             ";
        string Header3 = @"
  ___            _ _ _             _                   _____ _____ _____ 
 / _ \          | (_) |           (_)                 |_   _|_   _|_   _|
/ /_\ \_   _  __| |_| |_ ___  _ __ _ _   _ _ __ ___     | |   | |   | |  
|  _  | | | |/ _` | | __/ _ \| '__| | | | | '_ ` _ \    | |   | |   | |  
| | | | |_| | (_| | | || (_) | |  | | |_| | | | | | |  _| |_ _| |_ _| |_ 
\_| |_/\__,_|\__,_|_|\__\___/|_|  |_|\__,_|_| |_| |_|  \___/ \___/ \___/ 
                                                                         
                                                                         ";
        List<string> ColomnNameSchedule = new(){"Scheduled", "MovieTitle",
        "Directors", "ReleaseYear", " "};

    public void Start()
    {
        if (accesAud1.LoadFromJson() && accesAud2.LoadFromJson() && accesAud3.LoadFromJson() )
        {
        Aud1 = accesAud1.GetItemList();
        Aud2 = accesAud2.GetItemList();
        Aud3 = accesAud3.GetItemList();
        SelectSched();
        }
        else
        {
            Console.WriteLine("Something went wrong");
        }
    }


    // load every schedule 1 2 and 3
    public void SelectSched()
    {
        // Add to schedule if schedule object dont have a MovieTitle Directors         
        while (SelectedSchedule == null)
        {
            Console.Clear();
            if (Add)
            {
            Helpers.PrintStringToColor(HeaderAdd,"yellow");
            }
            if (Remove)
            {
            Helpers.PrintStringToColor(HeaderRem,"yellow");
            }
            Helpers.CharLine('-', 80);
            Helpers.PrintStringToColor("\nPress [1] Auditorium 1 / [2] for Auditorium 2 / [3] for Auditorium 3 or BACKSPACE to return and choose no schedule" , "cyan");

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    SelectedAud = 1;
                    Console.Clear();
                    SelectedSchedule = (Schedule)ObjCatalogePrinter.TabelPrinter<Schedule>(Header1, Aud1, ColomnNameSchedule);
                    break;

                case ConsoleKey.D2:
                    SelectedAud = 2;
                    Console.Clear();
                    SelectedSchedule = (Schedule)ObjCatalogePrinter.TabelPrinter<Schedule>(Header2, Aud2, ColomnNameSchedule);
                    break;

                case ConsoleKey.D3:
                    SelectedAud = 3;
                    Console.Clear();
                    SelectedSchedule =  (Schedule)ObjCatalogePrinter.TabelPrinter<Schedule>(Header3, Aud3, ColomnNameSchedule);
                    break;
                
                case ConsoleKey.Backspace:
                    return;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
            Console.Clear();
        }
        if (Add)
        {   
            if (SelectedSchedule.MovieTitle != "N/A")
            {   
                bool loop = true;
                while (loop)
                {
                Console.Clear();
                Helpers.PrintStringToColor("Schedule is already assigned if you want it on this time remove first the already assigned schedule or Choose another time.\nIf you want to assign it to another time press enter or press backspace to return to the menu","Red");
                ConsoleKeyInfo key2;
                key2 = Console.ReadKey();
                if (key2.Key == ConsoleKey.Enter)
                {
                SelectedSchedule = null;
                loop = false;
                SelectSched();
                }
                if(key2.Key == ConsoleKey.Backspace)
                {
                SelectedSchedule = null;
                loop = false;
                Helpers.BackToYourMenu();
                }
                }
            }
            else
            {

                if (!SelectedAuds.Contains(SelectedAud))
                    {
                        SelectedAuds.Add(SelectedAud);
                    }

                if (SelectedSchedules.Count > 0 || SelectedSchedules.Count == 0) 
                {
                    SelectedSchedules.Add(SelectedSchedule);
                    if (SelectedAud == 1)
                    {
                        foreach (Schedule schedule in Aud1)
                        {
                            if(schedule.Scheduled == SelectedSchedule.Scheduled)
                            {
                                Aud1.Remove(schedule);
                                break;
                            }
                        }
                    }
                    if (SelectedAud == 2)
                    {
                        foreach (Schedule schedule in Aud2)
                        {
                            if(schedule.Scheduled == SelectedSchedule.Scheduled)
                            {
                                Aud2.Remove(schedule);
                                break;
                            }
                        }
                    }
                    if (SelectedAud == 3)
                    {
                        foreach (Schedule schedule in Aud3)
                        {
                            if(schedule.Scheduled == SelectedSchedule.Scheduled)
                            {
                                Aud3.Remove(schedule);
                                break;
                            }
                        }
                    }
                }

            
                    AddSchedule();
            }
        }
        if (Remove)
            {
                if (SelectedSchedule.MovieTitle == "N/A")
                {   
                    bool loop = true;
                    while (loop)
                    {
                    Console.Clear();
                    Helpers.PrintStringToColor("Schedule is not assigned. Choose another time.\nIf you want to assign it to remove another time press enter or press backspace to return to the menu","Red");
                    ConsoleKeyInfo key2;
                    key2 = Console.ReadKey();
                    if (key2.Key == ConsoleKey.Enter)
                    {
                    SelectedSchedule = null;
                    loop = false;
                    SelectSched();
                    }
                    if(key2.Key == ConsoleKey.Backspace)
                    {
                    loop = false;
                    }
                    }
                }
                RemoveSchedule(); 
            }
    }

    public void AddSchedule()
    {
        bool loop2 = true;
        while (loop2)
        {
            Helpers.PrintStringToColor(@"
______     _   _     _   _   _       _     
| ___ \   | | | |   (_) | | | |     | |    
| |_/ /_ _| |_| |__  _  | |_| |_   _| |__  
|  __/ _` | __| '_ \| | |  _  | | | | '_ \ 
| | | (_| | |_| | | | | | | | | |_| | |_) |
\_|  \__,_|\__|_| |_|_| \_| |_/\__,_|_.__/ 
                                           
                                           ","Yellow");
            Helpers.CharLine('-',80);
            Helpers.PrintStringToColor("\nDo you want to schedule another time? Press [Y]es or [N]o", "Cyan");
            string choice = Helpers.Color("Yellow").ToLower();

            if (choice == "y" || choice == "yes")
            {
                SelectedSchedule = null;
                loop2 = false;
                SelectSched();
            }
            else if (choice == "n" || choice == "no")
            {
                loop2 = false;
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
            }
        }
    }
    public void RemoveSchedule ()
    {

    }
}
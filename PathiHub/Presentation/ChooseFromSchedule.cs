public class ChooseFromSchedule
{

    public int Auditorium;
    public static string HeaderX = @"
 _____      _              _       _           
/  ___|    | |            | |     | |          
\ `--.  ___| |__   ___  __| |_   _| | ___  ___ 
 `--. \/ __| '_ \ / _ \/ _` | | | | |/ _ \/ __|
/\__/ / (__| | | |  __/ (_| | |_| | |  __/\__ \
\____/ \___|_| |_|\___|\__,_|\__,_|_|\___||___/";

    public static List<string> ColomnNameSchedule = new(){"Scheduled", "MovieTitle",
        "Directors", "ReleaseYear", " "};

    public static List<Schedule> schedule1;
    public static List<Schedule> schedule2;
    public static List<Schedule> schedule3;
    public void start()
    {

        ScheduleAcces acces1 = new(1);
        ScheduleAcces acces2 = new(2);
        ScheduleAcces acces3 = new(3);
        MoviesAccess moviesAccess = new();
        MovieToAuditoriumLogic logic = new();


        if (acces1.LoadFromJson() && acces2.LoadFromJson() && acces3.LoadFromJson()&& moviesAccess.LoadFromJson())
        {
            
            schedule1 = acces1.GetItemList();
            schedule2 = acces2.GetItemList();
            schedule3 = acces3.GetItemList();
            List<Movie> movies = moviesAccess.GetItemList();


            Schedule SelectedSchedule = SelectSched();

            Movie foundMovie = movies.FirstOrDefault(movie =>
            movie.MovieTitle == SelectedSchedule.MovieTitle &&
            movie.Directors == SelectedSchedule.Directors &&
            movie.ReleaseYear == Convert.ToInt32(SelectedSchedule.ReleaseYear));

            if (foundMovie == null)
            {
                Helpers.PrintStringToColor("Error Occurred You will be sent to the main menu","red");
                Thread.Sleep(1200);
                start();
            }
            else
            {
                    MovieSchedule.SelectedMovie = foundMovie;
                    MovieSchedule.Selectedauditorium = Auditorium;
                    MovieSchedule.SelectedSchedule = SelectedSchedule.Scheduled;
                    logic.Connector(MovieSchedule.SelectedMovie);
            }
        }
    }
    public Schedule? SelectSched()
    {
        Schedule SelectedSchedule = null;
        while (SelectedSchedule == null)
        {
            ConsoleKeyInfo key;
            Console.Clear();
            Helpers.PrintStringToColor("\nPress [1] Auditorium 1 / [2] for Auditorium 2 / [3] for Auditorium 3 or BACKSPACE to return and choose no schedule" , "cyan");

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Auditorium = 1;
                    SelectedSchedule = (Schedule)ObjCatalogePrinter.TabelPrinter<Schedule>(HeaderX,schedule1 , ColomnNameSchedule);
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Auditorium = 2;
                    SelectedSchedule = (Schedule)ObjCatalogePrinter.TabelPrinter<Schedule>(HeaderX,schedule2 , ColomnNameSchedule);
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    Auditorium = 3;
                    SelectedSchedule =  (Schedule)ObjCatalogePrinter.TabelPrinter<Schedule>(HeaderX, schedule3 , ColomnNameSchedule);
                    break; 
                case ConsoleKey.Backspace:
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
            Console.Clear();

        }
        return SelectedSchedule;

    
    }
}
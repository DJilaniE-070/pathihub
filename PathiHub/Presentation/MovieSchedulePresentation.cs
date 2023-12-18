using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
public static class MovieSchedule
{

    public static Movie SelectedMovie;

    public static int Selectedauditorium;
    public static string SelectedSchedule;

// dit is nodig om de sched 
    public static void SaveAuditorium (List<List<string>> storedAud)
    {
        ScheduleAcces scheduleAcces = new(MovieSchedule.Selectedauditorium);
        if (scheduleAcces.LoadFromJson()!= false)
        {
            List<Schedule> WholeSchedule = scheduleAcces.GetItemList();
            foreach (Schedule schedule in WholeSchedule)
            {
            // Check if any of the scheduled times match those from the movie
                if (schedule.MovieTitle == MovieSchedule.SelectedMovie.MovieTitle
                && schedule.Scheduled == MovieSchedule.SelectedSchedule
                && schedule.Directors == MovieSchedule.SelectedMovie.Directors)
                {
                    schedule.StoredAuditorium = storedAud;
                }
            }  
            scheduleAcces.SaveToJson();
        }
    }
    public static void ChooseAuditorium()
    {
        int selectedIndex = 0;
        List<int> Auditoriums = SelectedMovie.Auditorium;
        Console.CursorVisible = false;
        bool loop = true;
        while (loop)
        {
            Console.Clear();
            PrintList(Auditoriums, selectedIndex);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0) ? Auditoriums.Count - 1 : selectedIndex - 1;
                    break;

                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex == Auditoriums.Count - 1) ? 0 : selectedIndex + 1;
                    break;

                case ConsoleKey.Enter:
                    Console.WriteLine($"Selected number: {Auditoriums[selectedIndex]}");
                    Selectedauditorium = Auditoriums[selectedIndex];
                    DisplaySchedule1();
                    loop=false;
                    break;
                case ConsoleKey.Backspace:
                // check op user and if user dan naar de specifieke menu page
                    Helpers.BackToYourMenu();
                    break;
                case ConsoleKey.Escape:
                    Helpers.MainMenu();
                    loop = false;
                    break;    
                
                // Add additional cases for other keys if needed

                default:
                    break;
            }
        }
    }

    static void PrintList(List<int> numbers, int selectedIndex)
    {
        Helpers.PrintStringToColor(@"
  ___            _ _ _             _                 
 / _ \          | (_) |           (_)                
/ /_\ \_   _  __| |_| |_ ___  _ __ _ _   _ _ __ ___  
|  _  | | | |/ _` | | __/ _ \| '__| | | | | '_ ` _ \ 
| | | | |_| | (_| | | || (_) | |  | | |_| | | | | | |
\_| |_/\__,_|\__,_|_|\__\___/|_|  |_|\__,_|_| |_| |_|
                                                     ","yellow");
        Console.WriteLine();
        Helpers.CharLine('-',80);

        for (int i = 0; i < numbers.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine($"Auditorium: {numbers[i]}");

            if (i == selectedIndex)
            {
                Console.ResetColor();
            }
        }
    }    



    
    public static void DisplaySchedule1()
    {
    // This can een list in de Movie obj zijn
    // "Monday/12:00-14.30","Thursday/18:00-20:30"
    List<string> Scheduled = SelectedMovie.Scheduled;
    Dictionary<string, List<string>> formattedSchedule = ParseSchedule(Scheduled);
    int selectedDayIndex = 0;
    int selectedTimeIndex = 0;
    bool loop = true;

        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            Helpers.PrintStringToColor(@"
 _____      _              _       _          _   _____ _                     
/  ___|    | |            | |     | |        | | |_   _(_)                    
\ `--.  ___| |__   ___  __| |_   _| | ___  __| |   | |  _ _ __ ___   ___  ___ 
 `--. \/ __| '_ \ / _ \/ _` | | | | |/ _ \/ _` |   | | | | '_ ` _ \ / _ \/ __|
/\__/ / (__| | | |  __/ (_| | |_| | |  __/ (_| |   | | | | | | | | |  __/\__ \
\____/ \___|_| |_|\___|\__,_|\__,_|_|\___|\__,_|   \_/ |_|_| |_| |_|\___||___/
                                                                              
                                                                            ","yellow");
            Helpers.CharLine('-',80);
            DisplaySchedule(formattedSchedule, selectedDayIndex, selectedTimeIndex);

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedDayIndex > 0)
                        selectedDayIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedDayIndex < formattedSchedule.Count - 1)
                        selectedDayIndex++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (selectedTimeIndex > 0)
                        selectedTimeIndex--;
                    break;
                case ConsoleKey.RightArrow:
                    if (selectedTimeIndex < formattedSchedule.ElementAt(selectedDayIndex).Value.Count - 1)
                        selectedTimeIndex++;
                    break;
                case ConsoleKey.Backspace:
                    ChooseAuditorium();
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Escape:
                    Helpers.MainMenu();
                    break;
                case  ConsoleKey.Enter:
                    loop = false;
                    break;

            }   

        } while (loop);

        if (key.Key == ConsoleKey.Enter)
        {
            string selectedDay = formattedSchedule.Keys.ElementAt(selectedDayIndex);
            string selectedTime = formattedSchedule[selectedDay][selectedTimeIndex];
            SelectedSchedule = $"{selectedDay}/{selectedTime}/Aud{Selectedauditorium}";
            if (selectedTime == "X")
            {
                DisplaySchedule1();
            }
        }
    }

    static void DisplaySchedule(Dictionary<string, List<string>> schedule, int selectedDayIndex, int selectedTimeIndex)
    {
        int row = 10;

        foreach (var kvp in schedule)
        {
            Console.SetCursorPosition(0, row);
            Console.Write($"{kvp.Key,-10}");

            // Ensure that there are exactly four time slots for each day
            while (kvp.Value.Count < 4)
            {
                kvp.Value.Add("X");
            }

            for (int i = 0; i < kvp.Value.Count; i++)
            {
                Console.SetCursorPosition(15 + i * 15, row);

                // Display 'X' for non-existing times
                if (i >= kvp.Value.Count || kvp.Value[i] == "X")
                {
                    Console.Write($"{'X',-10}");
                }
                else
                {
                    Console.Write($"{kvp.Value[i],-10}");
                }

                if (row == selectedDayIndex + 10 && i == selectedTimeIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(15 + i * 15, row);

                    // Display 'X' for non-existing times
                    if (i >= kvp.Value.Count || kvp.Value[i] == "X")
                    {
                        Console.Write($"{'X',-10}");
                    }
                    else
                    {
                        Console.Write($"{kvp.Value[i],-10}");
                    }

                    Console.ResetColor();
                }
            }

            row++;
        }
    }
    static Dictionary<string, List<string>> ParseSchedule(List<string> input)
    {
        Dictionary<string, List<string>> schedule = new Dictionary<string, List<string>>();

        foreach (string pair in input)
        {
            // Split each day-time pair into day and time
            string[] parts = pair.Split('/');
            if (parts.Length == 3)
            {
                string day = parts[0];
                string time = parts[1];
                string Aud = parts [2];

                // If the day already exists in the dictionary, add the time to its list
                if (schedule.ContainsKey(day))
                {
                    schedule[day].Add(time);
                }
                else
                {
                    // If the day doesn't exist, create a new list with the time and add it to the dictionary
                    schedule[day] = new List<string> { time };   
                }
            }
            else
            {
                Console.WriteLine($"Invalid format for day-time pair: {pair}");
            }
        }
        return schedule;
    }
}
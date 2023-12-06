using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
public static class MovieSchedule
{
    public static Movie SelectedMovie;
    public static string selectedDay;
    public static string selectedTime;
    public static void DisplaySchedule()
    {
    // This can een list in de Movie obj zijn
    // "Monday/12:00-14.30","Thursday/18:00-20:30"
    List<string> Scheduled = SelectedMovie.Scheduled;
    Dictionary<string, List<string>> formattedSchedule = ParseSchedule(Scheduled);
    int selectedDayIndex = 0;
    int selectedTimeIndex = 0;

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
            }

        } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

        if (key.Key == ConsoleKey.Enter)
        {
            string selectedDay = formattedSchedule.Keys.ElementAt(selectedDayIndex);
            string selectedTime = formattedSchedule[selectedDay][selectedTimeIndex];

            Console.WriteLine($"Selected Day: {selectedDay}");
            
            Console.WriteLine($"Selected Time: {selectedTime}");
        }
    }

    static void DisplaySchedule(Dictionary<string, List<string>> schedule, int selectedDayIndex, int selectedTimeIndex)
    {
        int row = 10;

        foreach (var kvp in schedule)
        {
            
            Console.SetCursorPosition(0, row);
            Console.Write($"{kvp.Key,-10}");

            for (int i = 0; i < kvp.Value.Count; i++)
            {
                Console.SetCursorPosition(15 + i * 15, row);
                Console.Write($"{kvp.Value[i],-10}");

                if (row == selectedDayIndex+10 && i == selectedTimeIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(15 + i * 15, row);
                    Console.Write($"{kvp.Value[i],-10}");
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
            if (parts.Length == 2)
            {
                string day = parts[0];
                string time = parts[1];

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
using System;

public class MovieTimeTable
{
    MoviesAccess moviesAccess = new MoviesAccess();

    // first ask for movie via MovieCatalogePrinter and the available days
    public int selectedIndex;
    public string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

    public void Start()
    {
        Console.CursorVisible = false;
        selectedIndex = 0;

        do
        {
            Console.Clear();
            Helpers.PrintStringToColor(@"
  ___                 _  _         _      _        ______                    
 / _ \               (_)| |       | |    | |       |  _  \                   
/ /_\ \__   __  __ _  _ | |  __ _ | |__  | |  ___  | | | |  __ _  _   _  ___ 
|  _  |\ \ / / / _` || || | / _` || '_ \ | | / _ \ | | | | / _` || | | |/ __|
| | | | \ V / | (_| || || || (_| || |_) || ||  __/ | |/ / | (_| || |_| |\__ \
\_| |_/  \_/   \__,_||_||_| \__,_||_.__/ |_| \___| |___/   \__,_| \__, ||___/
                                                                   __/ |     
                                                                  |___/      
", "DarkYellow");

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Please select a day (use the arrow keys and press Enter):");

            for (int i = 0; i < days.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(days[i]);
                Console.ResetColor();
            }
            Console.WriteLine("--------------------------------------------------------------------------------");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedIndex > 0)
                    {
                        selectedIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedIndex < days.Length - 1)
                    {
                        selectedIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    return;
            }
        } while (true);
    }

    public static void GetMovieCataloge()
    {
        Console.WriteLine("Must be implement correctly");
        // Pass the MoviesAccess instance to the TabelPrinter method of MovieCatalogePrinter and print it (to test for now)
    }
}

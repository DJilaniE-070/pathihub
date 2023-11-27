using System;

public class MovieOverview
{
    private int selectedIndex;
    private string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    private string header = "Days of the Week Menu";

    public void Start()
    {
        Console.CursorVisible = false;
        selectedIndex = 0;

        do
        {
            Console.Clear();

            Console.WriteLine(header);
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
}

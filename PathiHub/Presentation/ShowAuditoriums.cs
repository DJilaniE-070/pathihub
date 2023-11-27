using System.IO.Compression;

public class ShowAuditoriums
{
    public static void DisplayAuditoriumOptions()
    {
        string[] Options = { "[1] Auditorium 1", "[2] Auditorium 2", "[3] Auditorium 3" };
        ConsoleKeyInfo key;
        int CursorIndex = 0; 
        Console.CursorVisible = false; 
        for (int i = 0; i < Options.Length; i++)
        {
            if (i == CursorIndex)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.WriteLine(Options[i]);
            Console.ResetColor();
        }
        do
        {
            key = Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("Please select an option (use the arrow keys and press Enter):");

            for (int i = 0; i < Options.Length; i++)
            {
                if (i == CursorIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.WriteLine(Options[i]);
                Console.ResetColor();
            }

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (CursorIndex > 0)
                    {
                        CursorIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CursorIndex < Options.Length - 1)
                    {
                        CursorIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                Console.Clear();
                int auditoriumChoice = CursorIndex + 1;
                
                SeatMap seatmap = new(auditoriumChoice);

                if (auditoriumChoice == 1)
                {
                    // print auditorium 1
                    Console.WriteLine("Auditorium 1");

                }
                else if (auditoriumChoice == 2)
                {
                    // print auditorium 2
                    Console.WriteLine("Auditorium 2");

                }
                else if (auditoriumChoice == 3)
                {
                    // print auditorium 3
                    Console.WriteLine("Auditorium 3");

                }
                break;
            }
        } while (key.Key != ConsoleKey.Escape);
        Console.CursorVisible = true;
    }
}
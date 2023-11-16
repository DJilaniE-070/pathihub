using System.Text;

public class SeatMap
{    
    public static void Auditoriums(int audit)
    {
        List<List<string>> auditorium1 = new List<List<string>>
        {
            // seat             1    2    3    4    5    6    7    8    9    10   11   12
            new List<string> { "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" },
            new List<string> { "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" },
            new List<string> { "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" },
            new List<string> { "C", "C", "C", "C", "C", "B", "B", "C", "C", "C", "C", "C" },
            new List<string> { "C", "C", "C", "C", "B", "B", "B", "B", "C", "C", "C", "C" },
            new List<string> { "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" },
            new List<string> { "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" },
            new List<string> { "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" },
            new List<string> { "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" },
            new List<string> { "C", "C", "C", "C", "B", "B", "B", "B", "C", "C", "C", "C" },
            new List<string> { "C", "C", "C", "C", "C", "B", "B", "C", "C", "C", "C", "C" },
            new List<string> { "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" },
            new List<string> { "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" },
            new List<string> { "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" }
        };

        List<List<string>> auditorium2 = new List<List<string>>
        {
            // seat             1    2    3    4    5    6    7    8    9    10   11   12   13   14   15   16   17   18
            new List<string> { "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" },
            new List<string> { "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X" },
            new List<string> { "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X" },
            new List<string> { "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X" },
            new List<string> { "X", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "X" },
            new List<string> { "X", "C", "C", "C", "B", "B", "B", "B", "A", "A", "B", "B", "B", "B", "C", "C", "C", "X" },
            new List<string> { "C", "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C", "C" },
            new List<string> { "C", "C", "C", "B", "B", "B", "A", "A", "A", "A", "A", "A", "B", "B", "B", "C", "C", "C" },
            new List<string> { "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C" },
            new List<string> { "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C" },
            new List<string> { "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C" },
            new List<string> { "X", "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C", "X" },
            new List<string> { "X", "C", "C", "C", "B", "B", "B", "B", "A", "A", "B", "B", "B", "B", "C", "C", "C", "X" },
            new List<string> { "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X" },
            new List<string> { "X", "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X", "X" },
            new List<string> { "X", "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X", "X" },
            new List<string> { "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X" }
        };

        List<List<string>> auditorium3 = new List<List<string>>
        {
            // seat             1    2    3    4    5    6    7    8    9    10   11   12   13   14   15   16   17   18   19   20   21   22   23   24   25   26   27   28   29   30
            new List<string> { "X", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" }
        };

        if (audit == 1)
        {
            Console.WriteLine("      Auditorium 1:");
            DisplayAuditorium(auditorium1);
            DisplayScreen(1);
        }
        if (audit == 2)
        {
            Console.WriteLine("\t    Auditorium 2:");
            DisplayAuditorium(auditorium2);
            DisplayScreen(2);
        }   
        if (audit == 3)
        {
            Console.WriteLine("\t\t\tAuditorium 3:");
            DisplayAuditorium(auditorium3);
            DisplayScreen(3);
        }
    }

    public static void DisplayAuditorium(List<List<string>> auditorium)
    {   
        Console.OutputEncoding = Encoding.UTF8;
    
        foreach (List<string> row in auditorium)
        {
            foreach (string i in row)
            {
                if (i == "X")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("  ");
                }
                else if (i == "A")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\u25CF ");
                }
                else if (i == "B")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("∎ ");
                }
                else if (i == "C")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("❏ ");
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    public static void DisplayScreen(int number)
    {
        if (number == 1)
        {
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        if (number == 2)
        {
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        if (number == 3)
        {
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
    }
}
/* 
    public bool ReserveSeat()
    {
        Console.CursorVisible = false;

        Display();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Read key without displaying it

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    
                    break;

                case ConsoleKey.DownArrow:
                    
                    break;

                case ConsoleKey.LeftArrow:
                
                    break;

                case ConsoleKey.RightArrow:
                    break;

                case ConsoleKey.Enter:
                    Console.WriteLine($"Seat selected at ({cursorLeft}, {cursorTop})");
                    ReservedSeats seat = new ReservedSeats(cursorTop, cursorLeft);
                    break;

                default:
                    // Handle other keys if needed
                    break;
            }
        }
    }
        /* zoekt naar row en number in list seats als het gevonden is wordt het in variabele seat opgeslagen anders blijft het null
        ReservedSeats seat = Seats.Find(s => s.Row == row && s.Seat == number);
        //reserveert de seat en checkt of het al niet gereserveert is
        if (seat != null && seat.IsAvailable == true)
        {
            seat.IsAvailable = false;
            Console.WriteLine($"Seat {row}-{number} has been reserved");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid seat or the seat is already reserved");
            return false;
        }
    
    // showmenu later kan worden opgesplits in usermenu of presentation layer
    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Display();
            // vraagt om rij en stoel nummer 
            Console.Write("Enter row number (1-4): ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter seat number (1-8): ");
            int number = int.Parse(Console.ReadLine());
            //ReserveSeat(row, number);
            Console.WriteLine("Press enter to reserve");
            Console.ReadLine();
        }
    }
}*/
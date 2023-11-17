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
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "A", "A", "A", "A", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X" },
            new List<string> { "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X" },
            new List<string> { "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C" },
            new List<string> { "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C" },
            new List<string> { "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C" },
            new List<string> { "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C" },
            new List<string> { "C", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "C" },
            new List<string> { "X", "C", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "C", "X" },
            new List<string> { "X", "X", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "X", "X" },
            new List<string> { "X", "X", "C", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "C", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X" },
            new List<string> { "X", "X", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X", "X", "X" },
            new List<string> { "X", "X", "X", "X", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X", "X", "X", "X", "X" },
            new List<string> { "X", "X", "X", "X", "X", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X", "X", "X", "X", "X", "X" }
        };

        int CursorRow = 0;
        int CursorSeat = 0;

        DisplayAuditorium(auditorium3, CursorRow, CursorSeat);
        DisplayScreen(audit);

        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    CursorRow = Math.Max(0, CursorRow - 1);
                    break;

                case ConsoleKey.DownArrow:
                    CursorRow = Math.Min(auditorium3.Count - 1, CursorRow + 1);
                    break;

                case ConsoleKey.LeftArrow:
                    CursorSeat = Math.Max(0, CursorSeat - 1);
                    break;

                case ConsoleKey.RightArrow:
                    CursorSeat = Math.Min(auditorium3[CursorRow].Count - 1, CursorSeat + 1);
                    break;

                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    return;
            }
            Console.Clear();
            DisplayAuditorium(auditorium3, CursorRow, CursorSeat);
            DisplayScreen(audit);
        } while (key.Key != ConsoleKey.Escape);
    }

    public static void DisplayAuditorium(List<List<string>> auditorium, int cursorrow, int cursorseat)
    {   
        Console.OutputEncoding = Encoding.UTF8;
    
        for (int row = 0; row < auditorium.Count; row++)
        {
            for (int seat = 0; seat < auditorium[row].Count; seat++)
            {
                if (row == cursorrow && seat == cursorseat)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("∎ ");
                }
                else
                {
                    switch (auditorium[row][seat])
                    {
                        case "X":
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  ");
                            break;
                        case "A":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("❏ ");
                            break;
                        case "B":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("❏ ");
                            break;
                        case "C":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("❏ ");
                            break;
                    }
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
    public static void Cursor()
    {
        int cursorRow = 0;
        int cursorCol = 0;

        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);

            // Handle arrow keys to move the cursor
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    MoveCursor(ref cursorRow, ref cursorCol, -1, 0);
                    break;

                case ConsoleKey.DownArrow:
                    MoveCursor(ref cursorRow, ref cursorCol, 1, 0);
                    break;

                case ConsoleKey.LeftArrow:
                    MoveCursor(ref cursorRow, ref cursorCol, 0, -1);
                    break;

                case ConsoleKey.RightArrow:
                    MoveCursor(ref cursorRow, ref cursorCol, 0, 1);
                    break;
            }

            // Redraw the auditorium with the updated cursor position
            Console.Clear();
            DisplayScreen(1);

        } while (key.Key != ConsoleKey.Escape); // Exit the loop when the user presses the Escape key
    }

    // loop om alle stoelen te printe

    public static void MoveCursor(List<List<string>> auditorium, ref int cursorRow, ref int cursorCol, int rowOffset, int colOffset)
    {
        int newRow = cursorRow + rowOffset;
        int newCol = cursorCol + colOffset;

        // Check if the new position is within bounds and is a valid seat (A, B, or C)
        if (newRow >= 0 && newRow < auditorium.Count &&
            newCol >= 0 && newCol < auditorium[newRow].Count &&
            (auditorium[newRow][newCol] == "A" || auditorium[newRow][newCol] == "B" || auditorium[newRow][newCol] == "C"))
        {
            cursorRow = newRow;
            cursorCol = newCol;
        }
    }
}

/*    public bool ReserveSeat()
    {
        Console.CursorVisible = false;

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
                    // Handle seat selection or other actions
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
        */
    // showmenu later kan worden opgesplits in usermenu of presentation layer
 /*   public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            // vraagt om rij en stoel nummer 
            Console.Write("Enter row number (1-4): ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter seat number (1-8): ");
            int number = int.Parse(Console.ReadLine());
            ReservedSeats seat = Seats.Find(s => s.Row == row && s.Seat == number);
            Console.WriteLine("Press enter to reserve");
            Console.ReadLine();
        }
    }
}
*/

/* 
    public bool ReserveSeat()
    {
        Console.CursorVisible = false;

        Display();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

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
using System.Text;

public class SeatMap
{    
    // lijst om reservaties op te slaan
    public static List<List<string>> ReservedSeats = new List<List<string>>();

    // 3 auditoriums hardcoded en cursor logic
    public static void Auditoriums(int auditoriumnumber)
    {
        // auditorium 1 met 150 stoelen (14 rijen en 12 stoelen per rij)
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
        // auditorium 2 met 300 stoelen (19 rijen en 18 stoelen per rij)
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
        // auditorium 3 met 500 stoelen (20 rijen en 30 stoelen per rij)
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

        // welke auditorium kiezen, maak 2 kopies van de list
        List<List<string>> Auditorium = new();
        if (auditoriumnumber == 1)
        {
            Auditorium = auditorium1;
            ReservedSeats = Auditorium;
        }
        if (auditoriumnumber == 2)
        {
            Auditorium = auditorium2;
            ReservedSeats = Auditorium;
        }
        if (auditoriumnumber == 3)
        {
            Auditorium = auditorium3;
            ReservedSeats = Auditorium;
        }

        // cursor positie rij en stoel
        int CursorRow = 0;
        int CursorSeat = 0;

        // message
        string message = "";

        // laat de auditorium eerst zien samen met titel, scherm, legenda en cursor
        DisplayTitle(auditoriumnumber);
        DisplayAuditorium(Auditorium, CursorRow, CursorSeat);
        DisplayScreen(auditoriumnumber);
        DisplayCursorPosition(CursorRow, CursorSeat);
        DisplayLegenda();

        // cursor om te navigeren
        ConsoleKeyInfo key;
        Console.CursorVisible = true;
        do
        {
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    CursorRow = Math.Max(0, CursorRow - 1);
                    break;

                case ConsoleKey.DownArrow:
                    CursorRow = Math.Min(Auditorium.Count - 1, CursorRow + 1);
                    break;

                case ConsoleKey.LeftArrow:
                    CursorSeat = Math.Max(0, CursorSeat - 1);
                    break;

                case ConsoleKey.RightArrow:
                    CursorSeat = Math.Min(Auditorium[CursorRow].Count - 1, CursorSeat + 1);
                    break;

                case ConsoleKey.Enter:
                    // veranderd lijst naar reserve met R
                    if (Auditorium[CursorRow][CursorSeat] == "A" || Auditorium[CursorRow][CursorSeat] == "B" || Auditorium[CursorRow][CursorSeat] == "C")
                    {
                        Auditorium[CursorRow][CursorSeat] = "R";
                        message = $"Stoel in rij {CursorRow + 1} met nummer {CursorSeat + 1} is gereserveerd, Dank u wel voor het reserveren";
                    }
                    else if (ReservedSeats[CursorRow][CursorSeat] == "X")
                    {
                        message = $"Rij " + (CursorRow + 1) + ", nummer " + (CursorSeat + 1) + " is geen stoel";
                    }
                    else if (ReservedSeats[CursorRow][CursorSeat] == "X")
                    {
                        message = $"Stoel in rij " + (CursorRow + 1) + " met nummer " + (CursorSeat + 1) + " is al gereserveerd";
                    }
                    //ReservedSeats reservedSeats = new(CursorRow, CursorSeat);
                    break;
            }
            // clear het scherm en laat auditorium weer zien samen met titel, scherm, legenda en cursor
            Console.Clear();
            DisplayTitle(auditoriumnumber);
            DisplayAuditorium(Auditorium, CursorRow, CursorSeat);
            DisplayScreen(auditoriumnumber);
            DisplayCursorPosition(CursorRow, CursorSeat);
            Console.WriteLine(message);
            DisplayLegenda();
        // escape button om uit loop te gaan
        } while (key.Key != ConsoleKey.Escape);
    }

    // auditorium printen
    public static void DisplayAuditorium(List<List<string>> auditorium, int cursorrow, int cursorseat)
    {   
        // output van symbool in console te kunnen laten tonen
        Console.OutputEncoding = Encoding.UTF8;
        // auditorium printen loops
        for (int row = 0; row < auditorium.Count; row++)
        {
            for (int seat = 0; seat < auditorium[row].Count; seat++)
            {
                // als positie row en seat gelijk zijn aan cursorrow en cursorseat dan print symbool met kleur
                if (row == cursorrow && seat == cursorseat)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("∎ ");
                }
                // print wat in auditorium staat met kleur en symbool
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
                        case "R":
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("▣ ");
                            break;
                    }
                }
                // reset kleur van symbool
                Console.ResetColor();
                }
            // nieuwe rij printen
            Console.WriteLine();
        }
    }

    // titel printen
    public static void DisplayTitle(int auditoriumnumber)
    {
        if (auditoriumnumber == 1)
        {
            Console.WriteLine("      Auditorium 1:");
        }
        if (auditoriumnumber == 2)
        {
            Console.WriteLine("\t    Auditorium 2:");
        }
        if (auditoriumnumber == 3)
        {
            Console.WriteLine("\t\t\tAuditorium 3:");
        }
    }

    // scherm printen
    public static void DisplayScreen(int auditoriumnumber)
    {
        if (auditoriumnumber == 1)
        {
            Console.WriteLine();
            Console.WriteLine("         Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        if (auditoriumnumber == 2)
        {
            Console.WriteLine();
            Console.WriteLine("               Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        if (auditoriumnumber == 3)
        {
            Console.WriteLine();
            Console.WriteLine("                          Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
    }

    // legenda printen
    public static void DisplayLegenda()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❏ = 20 euro");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("❏ = 15 euro");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("❏ = 10 euro");
        Console.ResetColor();
    }

    // cursor positie printen
    public static void DisplayCursorPosition(int cursorrow, int cursorseat)
    {
        Console.WriteLine($"Geselecteerde rij: {cursorrow + 1} , geselecteerde stoel: {cursorseat + 1}");
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
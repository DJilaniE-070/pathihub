using System.Text;

public class SeatMap
{    
    // lijst om reservaties op te slaan
    //public static List<List<string>> ReservedSeats = new List<List<string>>();
    //public static List<ReservedSeats> ReserveSeat = new List<ReservedSeats>();
    
    private double Astoelen;
    private double Bstoelen;
    private double Cstoelen;
    public string Message = "";
    public int AuditoriumNumber;
    public int CursorRow = 0;
    public int CursorSeat = 0;
    public List<List<string>> Auditorium = new();
    public double ASTOEL 
    { 
        get
        {
            return Astoelen;
        } 
        set
        {
            Astoelen = value > 8 ? value : 8;
        }
    }
    public double BSTOEL 
    { 
        get
        {
            return Bstoelen;
        } 
        set
        {
            Bstoelen = value > 5 ? value : 5;
        }
    }
    public double CSTOEL 
    { 
        get
        {
            return Cstoelen;
        } 
        set
        {
            Cstoelen = value > 3 ? value : 3;
        }
    }

    public SeatMap(int auditoriumnumber)
    {
        ASTOEL = 25;
        BSTOEL = 20;
        CSTOEL = 15;
        AuditoriumNumber = auditoriumnumber;
        Auditoriums();
    }

    // 3 auditoriums hardcoded en cursor logic
    public void Auditoriums()
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

        // auditorium kiezen, maakt een kopie van de auditorium 1 tot en met 3 en zet in Auditorium
        //List<List<string>> Auditorium = new();
        if (AuditoriumNumber == 1)
        {
            Auditorium = auditorium1;
        }
        if (AuditoriumNumber == 2)
        {
            Auditorium = auditorium2;
        }
        if (AuditoriumNumber == 3)
        {
            Auditorium = auditorium3;
        }

        // cursor positie voor rij en stoel
        //int CursorRow = 0;
        //int CursorSeat = 0;

        // message wordt altijd geprint, maar is default op leeg en print normaal niks totdat je op enter klikt
        //string message = "";

        // laat de auditorium eerst zien samen met titel, scherm, legenda en cursor
        /* ben van plan om een DisplayAll() te maken om alles aan te roepen, zodat minder code hoeft te worden uitgevoerd
        DisplayTitle(AuditoriumNumber);
        DisplayAuditorium(Auditorium, CursorRow, CursorSeat);
        DisplayScreen(AuditoriumNumber);
        DisplayCursorPosition(CursorRow, CursorSeat);
        DisplayLegenda();
        */

        // laat de hele auditorium zien
        DisplayAll();

        // cursor om te navigeren
        ConsoleKeyInfo key;
        Console.CursorVisible = true;
        do
        {
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    CursorRow = CursorRow > 0 ? CursorRow - 1 : CursorRow;
                    break;
                case ConsoleKey.DownArrow:
                    CursorRow = CursorRow < Auditorium.Count - 1 ? CursorRow + 1 : CursorRow;
                    break;
                case ConsoleKey.LeftArrow:
                    CursorSeat = CursorSeat > 0 ? CursorSeat - 1 : CursorSeat;
                    break;
                case ConsoleKey.RightArrow:
                    CursorSeat = CursorSeat < Auditorium[CursorRow].Count - 1 ? CursorSeat + 1 : CursorSeat;
                    break;
                case ConsoleKey.Backspace:
                    if (Auditorium[CursorRow][CursorSeat] == "AR")
                    {
                        Auditorium[CursorRow][CursorSeat] = "A";
                    }
                    else if (Auditorium[CursorRow][CursorSeat] == "BR")
                    {
                        Auditorium[CursorRow][CursorSeat] = "B";
                    }
                    else if (Auditorium[CursorRow][CursorSeat] == "CR")
                    {
                        Auditorium[CursorRow][CursorSeat] = "C";
                    }
                    break;
                // Reserveer een stoel in de auditorium
                case ConsoleKey.Enter:
                    // als A, B of C is reserveer stoel en verander positie in list naar R
                    if (Auditorium[CursorRow][CursorSeat] == "A")
                    {
                        Auditorium[CursorRow][CursorSeat] = "AR";
                        Message = $"Stoel in rij {CursorRow + 1} met nummer {CursorSeat + 1} is gereserveerd, Dank u wel voor het reserveren";
                    }
                    else if (Auditorium[CursorRow][CursorSeat] == "B")
                    {
                        Auditorium[CursorRow][CursorSeat] = "BR";
                        Message = $"Stoel in rij {CursorRow + 1} met nummer {CursorSeat + 1} is gereserveerd, Dank u wel voor het reserveren";
                    }
                    else if (Auditorium[CursorRow][CursorSeat] == "C")
                    {
                        Auditorium[CursorRow][CursorSeat] = "CR";
                        Message = $"Stoel in rij {CursorRow + 1} met nummer {CursorSeat + 1} is gereserveerd, Dank u wel voor het reserveren";
                    }
                    // als X is print dat het geen stoel is en doet niks 
                    else if (Auditorium[CursorRow][CursorSeat] == "X")
                    {
                        Message = $"Dit is geen stoel";
                    }
                    // als R is dan is het al gereserveerd en print dit, doet niks verder
                    else if (Auditorium[CursorRow][CursorSeat] == "R")
                    {
                        Message = $"Dit is een gereserveerde stoel, kies een andere stoel";
                    }
                    break;
            }
            // laat de hele auditorium zien
            DisplayAll();
            
            /* clear het scherm en laat auditorium weer zien samen met titel, scherm, legenda en cursor
            Console.Clear();
            DisplayTitle(AuditoriumNumber);
            DisplayAuditorium(Auditorium, CursorRow, CursorSeat);
            DisplayScreen(AuditoriumNumber);
            DisplayCursorPosition(CursorRow, CursorSeat);
            Console.WriteLine(message);
            DisplayLegenda();*/

        // escape button om uit loop te gaan
        } while (key.Key != ConsoleKey.Escape);
    }

    // print alles
    public void DisplayAll()
    {
        Console.Clear();
        DisplayTitle();
        DisplayAuditorium();
        DisplayScreen();
        DisplayCursorPosition();
        DisplayMessage();
        DisplayLegenda();
    }

    // auditorium printen
    public void DisplayAuditorium()
    {   
        // output van symbool in console te kunnen laten tonen
        Console.OutputEncoding = Encoding.UTF8;
        // auditorium printen loops
        for (int row = 0; row < Auditorium.Count; row++)
        {
            for (int seat = 0; seat < Auditorium[row].Count; seat++)
            {
                // als positie row en seat gelijk zijn aan cursorrow en cursorseat dan print symbool met kleur
                if (row == CursorRow && seat == CursorSeat)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("∎ ");
                }
                // print wat in auditorium staat met kleur en symbool
                else
                {
                    switch (Auditorium[row][seat])
                    {
                        case "X":
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  ");
                            break;
                        case "A":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("❑ ");
                            break;
                        case "B":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("❑ ");
                            break;
                        case "C":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("❑ ");
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
    public void DisplayTitle()
    {
        if (AuditoriumNumber == 1)
        {
            Console.WriteLine("      Auditorium 1:");
        }
        if (AuditoriumNumber == 2)
        {
            Console.WriteLine("\t    Auditorium 2:");
        }
        if (AuditoriumNumber == 3)
        {
            Console.WriteLine("\t\t\tAuditorium 3:");
        }
    }

    // scherm printen
    public void DisplayScreen()
    {
        if (AuditoriumNumber == 1)
        {
            Console.WriteLine();
            Console.WriteLine("         Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        if (AuditoriumNumber == 2)
        {
            Console.WriteLine();
            Console.WriteLine("               Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        if (AuditoriumNumber == 3)
        {
            Console.WriteLine();
            Console.WriteLine("                          Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
    }

    // legenda printen
    public void DisplayLegenda()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❏ = {Astoelen} euro");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"❏ = {Bstoelen} euro");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"❏ = {Cstoelen} euro");
        Console.ResetColor();
    }

    // cursor positie printen
    public void DisplayCursorPosition()
    {
        Console.Write("Rij: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{CursorRow + 1}]");
        Console.ResetColor();
        Console.Write(" Stoel: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"[{CursorSeat + 1}]\n\n");
        Console.ResetColor();
    }

    // message printen
    public void DisplayMessage()
    {
        Console.WriteLine(Message);
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
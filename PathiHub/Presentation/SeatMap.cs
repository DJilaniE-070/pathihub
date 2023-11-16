using System.Text;

public class SeatMap
{
    public List<ReservedSeats> Seats;
    static int cursorLeft = 0;
    static int cursorTop = 0;


    public SeatMap()
    {
        Seats = new List<ReservedSeats>();
        // dit kan later nog verander worden naar andere values, bijvoorbeeld door constructor parameters toe tevoegen
        int SeatRows = 4;
        int SeatNumbers = 8;
        for (int row = 1; row <= SeatRows; row++)
        {
            for (int number = 1; number <= SeatNumbers; number++)
            {
                Seats.Add(new ReservedSeats(row, number));
            }
        }
    }
    // loop om alle stoelen te printen
    public void Display()
    {   
        Console.OutputEncoding = Encoding.UTF8;

        List<string> row1 = new List<string> { "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" };
        List<string> row2 = new List<string> { "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" };
        List<string> row3 = new List<string> { "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" };
        List<string> row4 = new List<string> { "C", "C", "C", "C", "C", "B", "B", "C", "C", "C", "C", "C" };
        List<string> row5 = new List<string> { "C", "C", "C", "C", "B", "B", "B", "B", "C", "C", "C", "C" };
        List<string> row6 = new List<string> { "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" };
        List<string> row7 = new List<string> { "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" };
        List<string> row8 = new List<string> { "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" };
        List<string> row9 = new List<string> { "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" };
        List<string> row10 = new List<string> { "C", "C", "C", "C", "B", "B", "B", "B", "C", "C", "C", "C" };
        List<string> row11 = new List<string> { "C", "C", "C", "C", "C", "B", "B", "C", "C", "C", "C", "C" };
        List<string> row12 = new List<string> { "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" };
        List<string> row13 = new List<string> { "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" };
        List<string> row14 = new List<string> { "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" };
        
        List<List<string>> auditorium = new List<List<string>> { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13, row14 };

        
    
        foreach (List<string> row in auditorium)
        {
            foreach (string i in row)
            {
                if (i == "X")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("  ");
                    Console.ResetColor();
                }
                else if (i == "A")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\u25CF ");
                    Console.ResetColor();
                }
                else if (i == "B")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("∎ ");
                    Console.ResetColor();
                }
                else if (i == "C")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("❏ ");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
        ReserveSeat();
    }

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
}
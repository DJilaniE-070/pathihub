
public class SeatMap
{
    public List<SeatData> Seats;

    public SeatMap()
    {
        Seats = new List<SeatData>();
        // dit kan later nog verander worden naar andere values, bijvoorbeeld door constructor parameters toe tevoegen
        int SeatRows = 4;
        int SeatNumbers = 8;
        for (int row = 1; row <= SeatRows; row++)
        {
            for (int number = 1; number <= SeatNumbers; number++)
            {
                Seats.Add(new SeatData(row, number));
            }
        }
    }
    // loop om alle stoelen te printen
    public void DisplaySeatMap()
    {
        List<string> row1 = new List<string> { "X", "B", "X", "X", "B", "X", "X", "B", "X", "X" };
        List<string> row2 = new List<string> { "D", "E", "F", "X", "A", "X", "X", "B", "X", "X" };
        List<string> row3 = new List<string> { "G", "H", "I", "X", "A", "A", "X", "B", "B", "B" };
        List<string> row4 = new List<string> { "J", "K", "L", "X", "A", "A", "X", "B", "B", "B" };
        List<string> row5 = new List<string> { "J", "K", "L", "X", "A", "A", "X", "B", "B", "B" };
        List<string> row6 = new List<string> { "X", "B", "X", "X", "A", "A", "A", "B", "B", "B" };
        List<string> row7 = new List<string> { "X", "B", "X", "X", "A", "A", "A", "B", "B", "B" };
        List<string> row8 = new List<string> { "D", "E", "F", "X", "A", "A", "X", "B", "B", "B" };
        List<string> row9 = new List<string> { "G", "H", "I", "X", "A", "X", "X", "B", "X", "X" };
        List<string> row10 = new List<string> { "J", "K", "L", "X", "B", "X", "X", "B", "X", "X" };
        
        List<List<string>> rows = new List<List<string>> { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10 };

        foreach (List<string> row in rows)
        {
            foreach (string i in row)
            {
                if (i == "X")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    
                    Console.Write("X");
                    Console.ResetColor();
                    break;
                }
                if (i == "A")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    Console.Write("X");
                    Console.ResetColor();
                    break;
                }
                if (i == "A")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    
                    Console.Write("X");
                    Console.ResetColor();
                    break;
                }
            }
        }
        Console.WriteLine("All Seats:");         
    }

    public bool ReserveSeat(int row, int number)
    {
        // zoekt naar row en number in list seats als het gevonden is wordt het in variabele seat opgeslagen anders blijft het null
        SeatData seat = Seats.Find(s => s.Row == row && s.Number == number);
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
    }
    // showmenu later kan worden opgesplits in usermenu of presentation layer
    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            DisplaySeatMap();
            // vraagt om rij en stoel nummer 
            Console.Write("Enter row number (1-4): ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter seat number (1-8): ");
            int number = int.Parse(Console.ReadLine());
            ReserveSeat(row, number);
            Console.WriteLine("Press enter to reserve");
            Console.ReadLine();
        }
    }
}

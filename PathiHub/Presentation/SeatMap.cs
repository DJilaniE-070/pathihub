
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
        Console.WriteLine("All Seats:");
        foreach (SeatData seat in Seats)
        {
            string status = "";
            if (seat.IsAvailable)
            {
                status = "Available";
            }
            else
            {
                status = "Reserved";
            }
            Console.Write($"Seat {seat.Row}-{seat.Number}: {status}");
            Console.WriteLine();
        }
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

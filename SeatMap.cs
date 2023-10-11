
public class SeatMap
{
    public List<SeatData> Seats;

    public SeatMap()
    {
        Seats = new List<SeatData>();
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

    public void DisplaySeatMap()
    {
        Console.WriteLine("Cinema Seat Map:");
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
        SeatData seat = Seats.Find(s => s.Row == row && s.Number == number);

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

    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            DisplaySeatMap();

            Console.Write("Enter row number (1-4): ");
            int Row = int.Parse(Console.ReadLine());
            Console.Write("Enter seat number (1-8): ");
            int number = int.Parse(Console.ReadLine());
            ReserveSeat(Row, number);
            Console.WriteLine("Press enter to reserve");
            Console.ReadLine();
        }
    }
}
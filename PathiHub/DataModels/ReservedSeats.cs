public class ReservedSeats
{
    public int Row { get; set; }
    public string Seat { get; set; }
    public int AuditoriumNumber { get; set; }
    public bool IsAvailable { get; set; }

    public ReservedSeats(int row, string seat, int auditoriumNumber)
    {
        Row = row;
        Seat = seat;
        AuditoriumNumber = auditoriumNumber;
        IsAvailable = true;
    }
}
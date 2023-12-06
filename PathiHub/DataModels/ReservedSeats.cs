public class ReservedSeats
{
    private int Row { get; set; }
    private string Seat { get; set; }
    private int AuditoriumNumber { get; set; }
    private bool IsAvailable { get; set; }

    public ReservedSeats(int row, string seat, int auditoriumNumber)
    {
        Row = row;
        Seat = seat;
        AuditoriumNumber = auditoriumNumber;
        IsAvailable = true;
    }
}
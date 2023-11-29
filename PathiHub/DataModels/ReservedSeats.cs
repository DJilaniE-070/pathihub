public class ReservedSeats
{
    public string Row;
    public int Seat;
    public int AuditoriumNumber;
    public bool IsAvailable = false;

    public ReservedSeats(string row, int seat, int auditoriumnumber)
    {
        Row = row;
        Seat = seat;
        AuditoriumNumber = auditoriumnumber;
        IsAvailable = true;
    }
}
public class ReservedSeats
{
    public int Row;
    public int Seat;
    public bool IsAvailable;

    public ReservedSeats(int row, int seat)
    {
        Row = row;
        Seat = seat;
        IsAvailable = true;
    }
}
public class SeatData
{
    public int Row;
    public int Number;
    public bool IsAvailable;

    public SeatData(int row, int number)
    {
        Row = row;
        Number = number;
        IsAvailable = true;
    }
}
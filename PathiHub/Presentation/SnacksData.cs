public class SnacksData
{
    public string Name;
    public double Price;
    public bool IsAvailable;

    public SnacksData(string name, double price, bool isavailable)
    {
        Name = name;
        Price = price;
        IsAvailable = isavailable;
    }
}
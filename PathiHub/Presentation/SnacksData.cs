public class SnacksData
{
    public string Name { get; set; }
    public double Price { get; set; }
    public bool IsAvailable { get; set; }

    public SnacksData(string name, double price, bool isAvailable)
    {
        Name = name;
        Price = price;
        IsAvailable = isAvailable;
    }
}
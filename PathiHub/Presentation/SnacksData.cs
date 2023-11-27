public class SnacksData
{
    public string Name;
    public string Description;
    public double Price;
    public int Stock;
    public bool IsAvailable;

    public SnacksData(string name, string description, double price, int stock, bool isavailable)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        IsAvailable = isavailable;
    }

    public SnacksData(string name, string description, double price, int stock)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        IsAvailable = stock > 0;
    }

    public SnacksData(string name, string description, double price)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = 0;
        IsAvailable = false;
    }

    public SnacksData(string name, string description, double price, bool isavailable)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = 100;
        IsAvailable = isavailable;
    }
}
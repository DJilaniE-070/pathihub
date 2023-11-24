
public class SnacksMenu
{
    private int CursorIndex = 0;
    public static List<SnacksData> _snacksdata = new List<SnacksData>
    {
        new SnacksData("Chips", "A bag of chips", 1.50, 10),
        new SnacksData("Chocolate Bar", "A bar of Pathi chocolate", 1.00, 10),
        new SnacksData("Soda", "A bottle of soda", 1.25, 10),
        new SnacksData("Popcorn", "A bag of popcorn", 2.00, 10, true),
        new SnacksData("Snoep", "A bag of candy", 0.75, 10, false)
    };
    public List<Snacks> BoughtSnacks;
    public string Name;
    public int Quantity;
    public double TotalPrice;
    public int Amount = 1;
    
    public SnacksMenu()
    {
        DisplayAmountSnacks();
    }

    public void BuySnacks()
    {

    }

    public void Start()
    {
        DisplayAmountSnacks();
    }

    public void ChangeSnacks()
    {
        DisplaySnacks();
        CursorIndex = 0;
        ConsoleKeyInfo key;
        Console.CursorVisible = true;
        do
        {
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (CursorIndex > 0)
                    {
                        CursorIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CursorIndex < _snacksdata.Count)
                    {
                        CursorIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    DisplayAmountSnacks();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Amount++;
                    }
                    BoughtSnacks.Add(new Snacks(_snacksdata[CursorIndex].Name, Amount));
                    break;
            }
        } while (key.Key != ConsoleKey.Escape);
        Menu.Start();
    }

    public void DisplayAmountSnacks()
    {
        //Console.Clear();
        DisplaySnacks();
        CursorIndex = 0;

        ConsoleKeyInfo key;
        Console.CursorVisible = true;
        do
        {
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (CursorIndex > 0)
                    {
                        CursorIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CursorIndex < _snacksdata.Count)
                    {
                        CursorIndex++;
                    }
                    break;
            }
            DisplaySnacks();
        } while (key.Key != ConsoleKey.Escape);
        Menu.Start();
    }

    public void DisplaySnacks()
    {
        Console.Clear();
        Console.WriteLine("Snacks:");
        Console.WriteLine();
        for (int i = 0; i < _snacksdata.Count; i++)
        {
            if (CursorIndex == i)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.WriteLine($"{i + 1}. {_snacksdata[i].Name}");
            Console.ResetColor();
        }
    }

    public double CalculatePrice(string name)
    {
        foreach (var snack in _snacksdata)
        {
            if (name == snack.Name)
            {
                return snack.Price * Quantity;
            }
        }
        return 0;
    }
}
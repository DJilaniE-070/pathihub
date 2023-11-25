
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

public class SnacksMenu
{
    private int CursorIndex = 1;
    private int PageIndex = 0;
    private int StartIndex = 0;
    private int Steps = 10;
    public static List<SnacksData> _snacksdata = new List<SnacksData>
    {
        //                     name                    description   price   stock   isavailable
        new SnacksData("Pathi Original Chips", "Originele Pathi chips", 1.50, 10, true),
        new SnacksData("Pathi Cheese Chips", "Pathi chips met kaas", 1.50, 0),
        new SnacksData("Pathi Paprika Chips", "Pathi chips met paprika", 1.50, 10),
        new SnacksData("Doritos", "Original Doritos", 2.00, 10),
        new SnacksData("Cheetos", "Kaas smaak Cheetos", 2.00, 10),
        new SnacksData("Nachos", "Met salsa of guacamole", 1.00, 10),
        new SnacksData("Chocolade reep (groot)", "Chocolade reep", 1.00, false),
        new SnacksData("Chocolade reep (klein)", "Chocolade reep", 1.00, 10),
        new SnacksData("Fanta Stic", "Pathi's Orange Juice", 1.00, 10),
        new SnacksData("Red Bull", "Energy drink", 1.00, 10),
        new SnacksData("Sprite", "", 1.00, 10, true),
        new SnacksData("Spa Blauw", "Water", 1.00, 10),
        new SnacksData("Spa Rood", "Water met prik", 1.00, 10),
        new SnacksData("Fanta", "Orange Juice", 1.00, 10),
        new SnacksData("Coca Cola", "Cola", 1.00, 10),
        new SnacksData("Coca Cola Light", "Cola zonder suiker", 1.00, 10),
        new SnacksData("Coca Cola Zero", "Cola zonder suiker", 1.00, 10),
        new SnacksData("Pathi Cola Super", "De originele Pathi Cola", 1.25, true),
        new SnacksData("Pathi Cola Ultra", "Pathi Cola zonder suiker", 1.25, 10), 
        new SnacksData("Zoete Popcorn", "Een grote zak zoet popcorn", 2.00, 10, true),
        new SnacksData("Mix Popcorn", "Een grote zak zoete en zoute popcorn mix", 0.75, 10, false),
        new SnacksData("Zoute Popcorn", "Een grote zak zoute popcorn", 2.00, 10),
        new SnacksData("Caramel Popcorn", "Een grote zak caramel popcorn", 2.00, 10),
        new SnacksData("M&M", "M&M", 2.00, 10),
        new SnacksData("KitKat", "KitKat", 2.00, 10),
        new SnacksData("Twix", "Twix ", 2.00, 10, true),
        new SnacksData("Snickers", "Snickers", 2.00, 10),
        new SnacksData("Skittles", "Skittles", 2.00, 10),
        new SnacksData("Raffaello", "Raffaello Armani", 2.00, 10, false),
        new SnacksData("Pretzels", "Zoute pretzels met Pathi saus", 2.00, 10),
        new SnacksData("Crisps", "Crisps", 2.00, 10),
        new SnacksData("Mix Snoep", "Een mix van alle snoep", 2.00, 10),
        new SnacksData("Mix Chocolade", "Een mix van alle chocolade", 2.00, 10),
        new SnacksData("Slush Pathi", "Slush Puppy maar dan Pathi stijl", 2.00, 10),
        new SnacksData("Ijs", "Keuze uit vanilla, chocolade, aardbei, citroen en mango", 2.00, 10),
        new SnacksData("Hot Dog", "Broodje met hotdog, Pathi stijl", 2.00, 10),
    };
    public List<Snacks> BoughtSnacks;
    public string Name;
    public int Quantity;
    public double TotalPrice;
    public int Amount = 1;
    
    public SnacksMenu()
    {
    }

    public void BuySnacks()
    {

    }

    public void Start()
    {
        Cursor();
    }
    
    // print all snacks
    public void Cursor()
    {
        DisplaySnacks();

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
                    if (_snacksdata[CursorIndex].IsAvailable == false)
                    {
                        CursorIndex--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (CursorIndex < _snacksdata.Count - 1)
                    {
                        CursorIndex++;
                    }
                    if (_snacksdata[CursorIndex].IsAvailable == false)
                    {
                        CursorIndex++;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (PageIndex > 0)
                    {
                        PageIndex--;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    int LastPage = _snacksdata.Count % 10;
                    if (PageIndex < LastPage)
                    {
                        PageIndex++;
                    }
                    break;

                case ConsoleKey.Enter:
                    BoughtSnacks.Add(new Snacks(_snacksdata[CursorIndex].Name, Amount));
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
            if (_snacksdata[StartIndex].IsAvailable)
            {
                if (CursorIndex == i)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write($"{i + 1}. {_snacksdata[i].Name}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}. {_snacksdata[i].Name} is out of stock");
            }
            Console.ResetColor();
            StartIndex++;
        }

        Console.WriteLine();
        Console.WriteLine("Press 'Left Arrow' to go to the previous page, 'Right Arrow' to go to the next page.");
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

    public void ChangeSnacks(string name)
    {
        foreach (var snack in _snacksdata)
        {
            if (name == snack.Name)
            {
                Console.WriteLine("Snack bestaat al en kan aangepast of verwijderd worden");
                switch (CursorIndex)
                {
                    // pas snack aan
                    case 1:
                        EditSnacks(name);
                        break;
                    // verwijder snack
                    case 2:
                        RemoveSnacks(name);
                        break;
                }
            }
        }
        Console.WriteLine("Snack bestaat niet en kan niet aangepast of verwijderd worden, wilt u het toevoegen?");
        switch (CursorIndex)
        {

        }
    }

    public void EditSnacks(string name)
    {
        foreach (var snack in _snacksdata)
        {

        }
    }

    public void RemoveSnacks(string name)
    {
        foreach (var snack in _snacksdata)
        {

        }
    }
    public void EditSnacks(string name)
    {
        foreach (var snack in _snacksdata)
        {

        }
    }

    public void RemoveSnacks(string name)
    {
        foreach (var snack in _snacksdata)
        {

        }
    }
}
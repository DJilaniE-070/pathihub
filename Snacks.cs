public class Snacks
{
    string[] Chips = {"Chips Cheese Onion", "Delicious chips freshly made with love", "12.99", "Yes", "10"};
    string[] Popcorn = {"Zoute Popcorn", "Delicious chips freshly made with love", "12.99", "Yes", "10"};
    string[] Candy = {"Zurematten", "Delicious chips freshly made with love", "12.99", "Yes", "10"};
    string[] Cola = {"Cola", "Delicious chips freshly made with love", "12.99", "Yes", "10"};

    string[] Snacks = {"Chips", "Popcorn", "Candy", "Drinks"};
    // index meanings: name, description, price, avalaibility, stock

    string data = "4,5";

    int row, int seat = data.Split(",");
    
    public void ChangeSnack(string name)
    {
        foreach (string snack in Snacks)
        {
            if (name == snack)
            {
                Console.WriteLine($"{snack} can be changed");

            }
        }
    }

    public void AddSnack(string name)
    {
        foreach (string snack in Snacks)
        {
            if (name == snack)
            {
                Console.WriteLine($"{snack} can be added");
                Snacks.Add(snack);
            }
        }
    }

    public void RemoveSnack(string name)
    {
        foreach (string snack in Snacks)
        {
            if (name == snack)
            {
                Console.WriteLine($"{snack} can be removed");
                Snacks.Remove(snack);
            }
        }
    }
}
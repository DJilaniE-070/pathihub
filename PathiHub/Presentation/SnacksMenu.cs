using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class SnacksMenu
{
    //positie cursor
    private static int CursorIndex = 0;
    private static string FilePath = System.IO.Path.GetFullPath(Environment.CurrentDirectory, @"DataSources/snacksdata.json");
    private static List<SnacksData> _snacksdata = new List<SnacksData>
    {
        //                     name      price    isavailable
        new SnacksData("Pathi Original Chips", 1.50, true),
        new SnacksData("Pathi Cheese Chips", 1.50, true),
        new SnacksData("Pathi Paprika Chips", 1.50, true),
        new SnacksData("Chocolade reep", 1.00, false),
        new SnacksData("Fanta Stic", 1.00, true),
        new SnacksData("Red Bull", 1.00, true),
        new SnacksData("Sprite", 1.00, true),
        new SnacksData("Spa Blauw", 1.00, true),
        new SnacksData("Spa Rood", 2.00, true),
        new SnacksData("Fanta", 1.00, true),
        new SnacksData("Coca Cola", 1.00, true),
        new SnacksData("Coca Cola Light", 1.00, true),
        new SnacksData("Coca Cola Zero", 1.00, true),
        new SnacksData("Pathi Cola Super", 1.25, true),
        new SnacksData("Pathi Cola Ultra", 1.25, true), 
        new SnacksData("Zoete Popcorn", 2.00, true),
        new SnacksData("Mix Popcorn", 0.75, false),
        new SnacksData("Zoute Popcorn", 2.00, true),
        new SnacksData("Caramel Popcorn", 2.00, true),
        new SnacksData("Pretzels", 2.00, true),
        new SnacksData("Mix Snoep", 2.00, true),
        new SnacksData("Mix Chocolade", 2.00, true),
        new SnacksData("Slush Pathi", 2.00, true),
        new SnacksData("Ijs", 2.00, false),
        new SnacksData("Hot Dog", 2.00, true)
    };
    
    public SnacksMenu()
    {
        SaveSnacksDataToJson(_snacksdata);
        Cursor();
    }

    public void Start()
    {
        SaveSnacksDataToJson(_snacksdata);
        List<SnacksData> loadedSnacksData = LoadSnacksDataFromJson();
    }

    static void SaveSnacksDataToJson(List<SnacksData> snacksData)
    {
        string json = JsonSerializer.Serialize(snacksData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    static List<SnacksData> LoadSnacksDataFromJson()
    {
        string loadedJson = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<SnacksData>>(loadedJson);
    }

    // print all snacks
    private void Cursor()
    {
        //print de snacks eerst
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
                    break;
                case ConsoleKey.DownArrow:
                    if (CursorIndex < _snacksdata.Count - 1)
                    {
                        CursorIndex++;
                    }
                    break;

                case ConsoleKey.Enter:
                    ChangeSnacks(_snacksdata[CursorIndex]);
                    break;
                case ConsoleKey.Backspace:
                    RemoveSnacks(_snacksdata[CursorIndex]);
                    break;
                case ConsoleKey.Spacebar:
                    AddSnacks();
                    break;

            }
            //print de snacks
            DisplaySnacks();
        } while (key.Key != ConsoleKey.Escape);
        Menu.Start();
    }

    private void DisplaySnacks()
    {
        Console.Clear();
        Console.ResetColor();  
        Console.WriteLine("Snacks:");
        Console.WriteLine();
        
        if (_snacksdata != null)
        {
            for (int i = 0; i < _snacksdata.Count; i++)
            {
                if (_snacksdata[i] != null)
                {
                    if (_snacksdata[i].IsAvailable)
                    {
                        if (CursorIndex == i)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine($"{i + 1}. {_snacksdata[i].Name}");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (CursorIndex == i)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{i + 1}. {_snacksdata[i].Name} is not available");
                        Console.ResetColor();
                    }
                }
            }
        }
        Console.WriteLine("Press [escape] to return to main menu");
        Console.WriteLine("Press [enter] to edit selected snack");
        Console.WriteLine("Press [space] to add a new snack");
        Console.WriteLine("Press [backspace] to remove selected snack");
    }
    

    private void ChangeSnacks(SnacksData snacksData)
    {
        Console.Clear();
        Console.WriteLine($"Editing {snacksData.Name}");
        Console.WriteLine("Enter new values:\n");

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("Price: ");

        double newPrice;
        if (double.TryParse(Helpers.Color("Yellow"), out newPrice))
        {
            snacksData.Price = newPrice;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid input for price. The price will remain unchanged.");
        }

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("\nIs Available (true/false): ");
        
        bool newIsAvailable;
        if (bool.TryParse(Helpers.Color("Yellow"), out newIsAvailable))
        {
            snacksData.IsAvailable = newIsAvailable;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input for availability. The availability will remain unchanged.");
        }
        SaveSnacksDataToJson(_snacksdata);
    }

    private void RemoveSnacks(SnacksData snacksData)
    {
        Console.Clear();
        Console.WriteLine($"Deleting {snacksData.Name}");
        Console.WriteLine("Are you sure you want to delete this snack? (Y/N)");

        ConsoleKeyInfo confirmKey = Console.ReadKey(true);
        if (confirmKey.Key == ConsoleKey.Y)
        {
            _snacksdata.Remove(snacksData);
            Console.WriteLine($"Snack {snacksData.Name} deleted.");
            SaveSnacksDataToJson(_snacksdata);
        }
        else
        {
            Console.WriteLine("Deletion canceled.");
        }
    }

    private void AddSnacks()
    {
        Console.Clear();
        Console.WriteLine("Adding a new snack");
        
        Console.Write("Name: ");
        string name = Helpers.Color("Yellow");

        Console.Write("Price: ");
        double price;
        if (!double.TryParse(Helpers.Color("Yellow"), out price))
        {
            Console.WriteLine("Invalid input for price. Snack not added.");
            return;
        }

        Console.Write("Is Available (true/false): ");
        bool isAvailable;
        if (!bool.TryParse(Helpers.Color("Yellow"), out isAvailable))
        {
            Console.WriteLine("Invalid input for availability. Snack not added.");
            return;
        }

        SnacksData newSnack = new SnacksData(name, price, isAvailable);
        _snacksdata.Add(newSnack);
        Console.WriteLine($"Snack {name} added.");

        SaveSnacksDataToJson(_snacksdata);
    }
}

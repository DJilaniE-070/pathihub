
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class SnacksMenu
{
    //positie cursor
    private int CursorIndex = 0;
    private string filePath = @"C:\Users\31685\Documents\GitHub\pathihub\PathiHub\DataSources\snacksdata.json";
    private static List<SnacksData> _snacksdata = new List<SnacksData>
    {
        //                     name                    description   price   stock   isavailable
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
        LoadSnacksData();
        Cursor();
    }

    public void Start()
    {
        LoadSnacksData();
        Cursor();
    }
    
    private void LoadSnacksData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            _snacksdata = JsonConvert.DeserializeObject<List<SnacksData>>(json);
        }
        else
        {
            _snacksdata = new List<SnacksData>();
        }
    }

    // Save snacks data to a JSON file
    private void SaveSnacksData()
    {
        string json = JsonConvert.SerializeObject(_snacksdata, Formatting.Indented);
        File.WriteAllText(filePath, json);
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
                    if (CursorIndex >= 0 && CursorIndex < _snacksdata.Count)
                    {
                        ChangeSnacks(_snacksdata[CursorIndex].Name);
                    }
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
        Console.WriteLine("Snacks:");
        Console.WriteLine();
        
        for (int i = 0; i < _snacksdata.Count; i++)
        {
            if (i >= 0 && i < _snacksdata.Count)
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
        Console.WriteLine();
    }

    private void ChangeSnacks(string name)
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
                        //EditSnacks(name);
                        break;
                    // verwijder snack
                    case 2:
                        //RemoveSnacks(name);
                        break;
                }
            }
        }
    }

    public void EditSnacks(string name)
    {
    
    }

    public void RemoveSnacks(string name)
    {
    
    }
}
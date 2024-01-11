using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class SnacksMenu
{
    //positie cursor
    private bool IsManager = false;
    private static int CursorIndex = 0;
    private static string FilePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/", "snacksdata.json"));
    private static List<SnacksData> _snacksdata;

    public SnacksMenu(bool ismanager)
    {
        IsManager = ismanager;
        _snacksdata = LoadSnacksDataFromJson();
        //SaveSnacksDataToJson(_snacksdata);
        Cursor();
    }

    public void Start()
    {
        _snacksdata = LoadSnacksDataFromJson();
        //SaveSnacksDataToJson(_snacksdata);
        //List<SnacksData> loadedSnacksData = LoadSnacksDataFromJson();
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
                    if (IsManager)
                    {
                        EditSnacks(_snacksdata[CursorIndex]);
                    }
                    break;
                case ConsoleKey.Backspace:
                    if (IsManager)
                    {
                        RemoveSnacks(_snacksdata[CursorIndex]);
                    }
                    break;
                case ConsoleKey.Spacebar:
                    if (IsManager)
                    {
                        AddSnacks();
                    }
                    break;

            }
            //print de snacks
            DisplaySnacks();
        } while (key.Key != ConsoleKey.Escape);
        if(!IsManager)
        {
        Helpers.MainMenu();
        Environment.Exit(0);
        }
        ManagerMenu.Start();
    }

    private void DisplaySnacks()
    {
        Console.Clear();
        Console.ResetColor();  
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Pathihub Snacks:");
        Console.ResetColor();  
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{_snacksdata[CursorIndex].Name} costs {_snacksdata[CursorIndex].Price} euro");
        Console.ResetColor(); 
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
        Console.WriteLine();
        Console.WriteLine("Press [escape] to return to main menu");
        if (IsManager)
        {
            Console.WriteLine("Press [enter] to edit selected snack");
            Console.WriteLine("Press [backspace] to remove selected snack");
            Console.WriteLine("Press [space] to add a new snack");
        }
    }
    

    private void EditSnacks(SnacksData snacksData)
    {
        Console.Clear();
        Console.Write($"Editing");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($" {snacksData.Name}");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Enter new values:");
        Console.WriteLine();

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
        Console.Write($"Deleting");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($" {snacksData.Name}");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Are you sure you want to delete this snack? (Y/N)");
        Console.WriteLine();
        Console.WriteLine("Press [Y] to confirm");
        Console.WriteLine("Press anything else to cancel");

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
        Console.WriteLine();
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

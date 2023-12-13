using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ObjCatalogePrinter
{
    private static int selectedObjIndex = 0;


    public static object? TabelPrinter<T>(string HeaderX, List<T> itemList, List<string> ColomnNames)
    {
         if (itemList != null && itemList.Count > 0)
        {   
            Type itemType = typeof(T);
            // Teken de tabel met films

            DrawTable(HeaderX, itemList, ColomnNames);

            // Wacht op invoer van de gebruiker
            ConsoleKeyInfo key;
            do
            {
                
                
                key = Console.ReadKey();

                // Pas de index van de geselecteerde film aan op basis van de pijltjestoetsen
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedObjIndex = (selectedObjIndex - 1 + itemList.Count) % itemList.Count;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedObjIndex = (selectedObjIndex + 1) % itemList.Count;
                        break;
                    case ConsoleKey.Backspace:
                        if (itemType == typeof(Schedule))
                        {
                            return null;
                        }
                        selectedObjIndex = 0;
                        Helpers.BackToYourMenu();
                        break;
                    case ConsoleKey.Escape:
                        selectedObjIndex = 0;
                        Helpers.MainMenu();
                        break;

                }

                // Teken de tabel met films (opnieuw) om de geselecteerde film te markeren
                Console.Clear();
                DrawTable(HeaderX, itemList, ColomnNames);

            } while (key.Key != ConsoleKey.Enter);

            // Nu heb je toegang tot de geselecteerde film in de "movies" lijst
            
            Thread.Sleep(500);
            object? selectedItem = itemList[selectedObjIndex];
            selectedObjIndex = 0;
            return selectedItem;
        }

        return null;
    }

    public static void DrawTable<T>(string HeaderX ,List<T> objList, List<string> displayFields)   
     {
        Type itemType = typeof(T);
        Helpers.PrintStringToColor(HeaderX, "yellow");
    
        Helpers.CharLine('-' ,80);
        switch (itemType.Name)
        {
            case "Schedule":
                Console.WriteLine("These are our Schedules");
                break;
            case "Movie":
                Console.WriteLine("This is our Movie Catalog");
                break;
            case "Reservation":
                Console.WriteLine("These are the made Reservations");
                break;
            default:
                Console.WriteLine("This is our Catalog");
                break;
        }
        Helpers.CharLine('-' ,80);
        
        if (itemType == typeof(Schedule))
        {
        Console.WriteLine($"\n Navigate the menu with Up and Down arrows. Press Backspace to Select Another Auditorium. Press ENTER to select a {itemType.Name}\n\n\n");
        }
        else
        {
        Console.WriteLine($"\n Navigate the menu with Up and Down arrows. Press Backspace to return to the manager menu. Press ENTER to select a {itemType.Name}\n\n\n");
        }

        Console.WriteLine("{0,-25} | {1,-25} | {2,-25} | {3,-30} | {4,-10}", displayFields[0], displayFields[1], displayFields[2], displayFields[3], displayFields[4]);
        Console.WriteLine(new string('-', 110));

        for (int i = 0; i < objList.Count; i++)
        {
            if (i == selectedObjIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            var displayValues = displayFields
                .Select(field =>
                {
                    var property = typeof(T).GetProperty(field);
                    var value = property?.GetValue(objList[i]);

                    if (value == null)
                    {
                        return "N/A";
                    }

                    // If the property is a collection, concatenate its elements
                    if (value is List<string> IsList)
                    {
                        return string.Join(", ", IsList);
                    }

                    string stringValue = value.ToString();

                    // Truncate the string if it exceeds 20 characters
                    if (stringValue.Length > 25)
                    {
                        stringValue = stringValue.Substring(0, 22) + "...";
                    }

                    return stringValue;
                })
                .ToArray();

            Console.WriteLine("{0,-25} | {1,-25} | {2,-25} | {3,-30} | {4,-10}", displayValues);
            Console.ResetColor();
    }
    }
}

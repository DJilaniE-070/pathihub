using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ObjCatalogePrinter
{
    private static int selectedObjIndex = 0;


    public static object TabelPrinter<T>(string HeaderX, List<T> itemList, List<string> ColomnNames)
    {
         if (itemList != null && itemList.Count > 0)
        {   
            
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
                        ManagerMenu.Start();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine(" ");
                        Menu.Start();
                        break;

                }

                // Teken de tabel met films (opnieuw) om de geselecteerde film te markeren
                Console.Clear();
                DrawTable(HeaderX, itemList, ColomnNames);

            } while (key.Key != ConsoleKey.Enter);

            // Nu heb je toegang tot de geselecteerde film in de "movies" lijst
            
            Thread.Sleep(500);
            return itemList[selectedObjIndex];
        }

        return null;
    }

    public static void DrawTable<T>(string HeaderX ,List<T> objList, List<string> displayFields)    {
        Console.WriteLine(HeaderX);
    
        Helpers.CharLine('-' ,80);
        Console.WriteLine("This our Catalog");
        Helpers.CharLine('-' ,80);
        
        Console.WriteLine("\n Navigate the menu with Up and Down arrows. Press Backspace to return to the manager menu\n\n\n");

        Console.WriteLine("{0,-20} | {1,-15} | {2,-25} | {3,-30} | {4,-10}", "MovieTitle", "ReleaseYear", "Director", "Genre", "Rating");
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

                    var stringValue = value.ToString();

                    // Truncate the string if it exceeds 20 characters
                    if (stringValue.Length > 20)
                    {
                        stringValue = stringValue.Substring(0, 17) + "...";
                    }

                    return stringValue;
                })
                .ToArray();

            Console.WriteLine("{0,-20} | {1,-15} | {2,-25} | {3,-30} | {4,-10}", displayValues);
            Console.ResetColor();
    }
    }
}

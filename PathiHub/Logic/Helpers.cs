//In deze class gaan we de alle helpers toevoegen
public class Helpers
{
    
    //deze functie schrijft een char uit meerdere keren 
    public static void  CharLine(char CharItem,int NumberOfPrints)
    {
        // Voor het standaard menu is de int 80
        Console.WriteLine(new string(CharItem, NumberOfPrints));
    }
    
    //deze functie print een string uit merdere keren
     public static void  StringLine(string StringItem,int NumberOfPrints)
     {
         // Voor het standaard menu is de int 80
         Console.WriteLine();
     }

    
    // Mini versie van het printen voor een cursor
    public static int Minicuror(string[] menuOptions, string info)
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;

        do
        {
            
            Thread.Sleep(5000);
            Console.Clear();
            
            //hier komt de informatie die eerder is geprint:
            
            Console.WriteLine("--------------------------------------------------------------------------------");

            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(menuOptions[i]);
                Console.ResetColor();
            }
            Console.WriteLine("--------------------------------------------------------------------------------");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedIndex > 0)
                    {
                        selectedIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (selectedIndex < menuOptions.Length - 1)
                    {
                        selectedIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    return selectedIndex;
            }
        } while (true);
    }
    
    // This Method return a string with a Readline() as input
    public static string Color(string color)
    {
        ConsoleColor consoleColor;

        try
        {
            consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
        }
        catch (ArgumentException)
        {
            consoleColor = ConsoleColor.White; // Default to White for invalid input
            Console.WriteLine("Invalid color name. Defaulting to White color.");
        }

        Console.ForegroundColor = consoleColor; // Set text color to the parsed color
        string sentence = Console.ReadLine();
        Console.ResetColor(); // Reset text color to default
        return sentence;
    }
    
    
    
    // This Method return a string with a Readline() as input
    public static void PrintStringToColor(string sentence,string color)
    {
        ConsoleColor consoleColor;

        try
        {
            consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
        }
        catch (ArgumentException)
        {
            consoleColor = ConsoleColor.White; // Default to White for invalid input
            Console.WriteLine("Invalid color name. Defaulting to White color.");
        }

        Console.ForegroundColor = consoleColor; // Set text color to the parsed color
        Console.WriteLine(sentence);
        Console.ResetColor(); // Reset text color to default
    }
    
    
    
    
}
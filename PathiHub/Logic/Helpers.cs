//In deze class gaan we de alle helpers toevoegen
public class Helpers
{
    //deze variabele is nodig om application wide de logged in gebruiker bij te houden.
    public static AccountModel? CurrentAccount { get; set; }    
    
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

    public static void BackToYourMenu()
    {
        if (CurrentAccount == null)
        {
            Menu.Start();
        } 
        string role = CurrentAccount.Role;
        switch (role)
        {
            case "Manager":
                    Console.Clear();
                    ManagerMenu.Start();
                    break;
                case "Financial Manager":
                    Console.Clear();
                    FinancialMenu.Start();
                    break;
                case "Coworker":
                    Console.Clear();
                    CoWorker.Start();
                    break;
                case "User":
                    Console.Clear();
                    UserMenu.Start();
                    break;
                case "Customer":
                    Console.Clear();
                    // CustomerMenu.CustomerStart();
                    break;
                default:
                    Menu.Start();
                    break;
        }
    }
    
    // Mini versie van het printen voor een cursor
    public static int MiniCursor(string[] menuOptions, DeleteMovieOutTabel movieDeletor)
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;

        do
        {
            Thread.Sleep(500);
            Console.Clear();

            DisplayInfo(movieDeletor);

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
    
    
    public static void DisplayInfo(DeleteMovieOutTabel movieDeletor)
    {
        Console.Clear();
        movieDeletor.MovieDeletor("HeaderX");
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
using System.Text;
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
        else
        {
        string role = CurrentAccount.Role;
        switch (role)
        {
            case "Manager":
                    Console.Clear();
                    ManagerMenu.Start();
                    Environment.Exit(0);
                    break;
                case "Financial Manager":
                    Console.Clear();
                    FinancialMenu.Start();
                    Environment.Exit(0);
                    break;
                case "Coworker":
                    Console.Clear();
                    CoWorker.Start();
                    Environment.Exit(0);
                    break;
                case "User":
                    Console.Clear();
                    UserMenu.Start();
                    Environment.Exit(0);
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
    }
    
    public static void PathiHubPrint()
    {
        PrintStringToColor(@"
______     _   _     _ _           _     
| ___ \   | | | |   (_) |         | |    
| |_/ /_ _| |_| |__  _| |__  _   _| |__  
|  __/ _` | __| '_ \| | '_ \| | | | '_ \ 
| | | (_| | |_| | | | | | | | |_| | |_) |
\_|  \__,_|\__|_| |_|_|_| |_|\__,_|_.__/ ","yellow");

CharLine('-',80);
Console.WriteLine("Please select an option (using the arrow keys and press Enter. Backspace to go Your menu or Escape to go the Main Menu):");
CharLine('-',80);
Console.WriteLine();
    }
    public static void MainMenu()
    {
        Console.WriteLine(" ");
        CurrentAccount = null;
        Menu.Start();
        Environment.Exit(0);
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

        switch (color.ToLower())
        {
            case "black":
                consoleColor = ConsoleColor.Black;
                break;
            case "darkblue":
                consoleColor = ConsoleColor.DarkBlue;
                break;
            case "darkgreen":
                consoleColor = ConsoleColor.DarkGreen;
                break;
            case "darkcyan":
                consoleColor = ConsoleColor.DarkCyan;
                break;
            case "darkred":
                consoleColor = ConsoleColor.DarkRed;
                break;
            case "darkmagenta":
                consoleColor = ConsoleColor.DarkMagenta;
                break;
            case "darkyellow":
                consoleColor = ConsoleColor.DarkYellow;
                break;
            case "gray":
                consoleColor = ConsoleColor.Gray;
                break;
            case "darkgray":
                consoleColor = ConsoleColor.DarkGray;
                break;
            case "blue":
                consoleColor = ConsoleColor.Blue;
                break;
            case "green":
                consoleColor = ConsoleColor.Green;
                break;
            case "cyan":
                consoleColor = ConsoleColor.Cyan;
                break;
            case "red":
                consoleColor = ConsoleColor.Red;
                break;
            case "magenta":
                consoleColor = ConsoleColor.Magenta;
                break;
            case "yellow":
                consoleColor = ConsoleColor.Yellow;
                break;
            case "white":
                consoleColor = ConsoleColor.White;
                break;
            default:
                consoleColor = ConsoleColor.White; // Default to White for invalid input
                Console.WriteLine("Invalid color name. Defaulting to White color.");
                break;
        }

        Console.ForegroundColor = consoleColor; // Set text color to the parsed color
        string sentence = ReadlineOrExit().Trim();
        Console.ResetColor(); // Reset text color to default
        return sentence;
    }

    
    
    public static void DisplayInfo(DeleteMovieOutTabel movieDeletor)
    {
        Console.Clear();
        movieDeletor.MovieDeletor("HeaderX");
    }
    
    
    // This Method return a string with a Readline() as input
    public static void PrintStringToColor(string sentence, string color)
    {
        ConsoleColor consoleColor;

        switch (color.ToLower())
        {
            case "black":
                consoleColor = ConsoleColor.Black;
                break;
            case "darkblue":
                consoleColor = ConsoleColor.DarkBlue;
                break;
            case "darkgreen":
                consoleColor = ConsoleColor.DarkGreen;
                break;
            case "darkcyan":
                consoleColor = ConsoleColor.DarkCyan;
                break;
            case "darkred":
                consoleColor = ConsoleColor.DarkRed;
                break;
            case "darkmagenta":
                consoleColor = ConsoleColor.DarkMagenta;
                break;
            case "darkyellow":
                consoleColor = ConsoleColor.DarkYellow;
                break;
            case "gray":
                consoleColor = ConsoleColor.Gray;
                break;
            case "darkgray":
                consoleColor = ConsoleColor.DarkGray;
                break;
            case "blue":
                consoleColor = ConsoleColor.Blue;
                break;
            case "green":
                consoleColor = ConsoleColor.Green;
                break;
            case "cyan":
                consoleColor = ConsoleColor.Cyan;
                break;
            case "red":
                consoleColor = ConsoleColor.Red;
                break;
            case "magenta":
                consoleColor = ConsoleColor.Magenta;
                break;
            case "yellow":
                consoleColor = ConsoleColor.Yellow;
                break;
            case "white":
                consoleColor = ConsoleColor.White;
                break;
            default:
                consoleColor = ConsoleColor.White; // Default to White for invalid input
                Console.WriteLine("Invalid color name. Defaulting to White color.");
                break;
        }

        Console.ForegroundColor = consoleColor; // Set text color to the parsed color
        Console.WriteLine(sentence);
        Console.ResetColor(); // Reset text color to default
    }
    
    public  static string ReadlineOrExit()
    {
        StringBuilder userInputBuilder = new StringBuilder();
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);

            // Check for Escape key
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("\nExiting...");
                Menu.Start();
                Environment.Exit(0); // Exit the entire program
            }

            // Handle backspace
            if (keyInfo.Key == ConsoleKey.Backspace && userInputBuilder.Length > 0)
            {
                Console.Write("\b \b");
                userInputBuilder.Remove(userInputBuilder.Length - 1, 1);
            }
            else
            {
                Console.Write(keyInfo.KeyChar);
                userInputBuilder.Append(keyInfo.KeyChar);
            }

        } while (keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine(); // Move to the next line after Enter

        return userInputBuilder.ToString();
    }

    public string Cursor(string[] menuOptions)
    {
        Console.CursorVisible = false;
        int selectedIndex = 0;

        do
        {
            Console.Clear();
            
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
                    return menuOptions[selectedIndex];
            }
        } while (true);
    }

}
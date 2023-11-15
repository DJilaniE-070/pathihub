//In deze class gaan we de alle helpers toevoegen
public class Helpers
{
    public static void  StringLine(int NumberOfPrints)
    {
        // Voor het standaard menu is de int 80
        Console.WriteLine(new string('-', NumberOfPrints));
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
    
    
}
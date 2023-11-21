using System.Threading;
using System.Text;

public static class Menu 
{
    // dit is het scherm is word puur gebruikt als eerste scherm
    public static void Start()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        int selectedIndex = 0;
        bool exit = false;

        string[] menuOptions = { "Login as a guest", "Login as an user", "Creating an account" };

        do
        {
            Console.Clear();

            // promotie menu start
            
            Helpers.PrintStringToColor(
            @"
______     _   _     _   _   _       _     
| ___ \   | | | |   (_) | | | |     | |    
| |_/ /_ _| |_| |__  _  | |_| |_   _| |__  
|  __/ _` | __| '_ \| | |  _  | | | | '_ \ 
| | | (_| | |_| | | | | | | | | |_| | |_) |
\_|  \__,_|\__|_| |_|_| \_| |_/\__,_|_.__/ 
                                          ","DarkYellow");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();

            //print elke promoted movie van list
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                           The Adventure Begins");
            Console.WriteLine("╭━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╮");
            Console.ResetColor();
            Console.WriteLine("In a futuristic world, Alice, a skilled adventurer, and her loyal sidekick Bob, \nembark on a thrilling journey to save their city from the evil plans of Eve, \na cunning antagonist. With high-tech gadgets and unyielding determination, \nthey must overcome various challenges and foes to restore peace to their homeland.");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine();
            Console.WriteLine("                             Galactic Quest");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine("In the vast expanse of the galaxy, Chris, a brave spaceman, and his alien friend Zara\n embark on a quest to forge alliances between planets and civilizations. \nTheir journey is fraught with intergalactic challenges and unexpected friendships, \ntesting their courage and resolve to bring peace to the universe.");
 

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("                              The Avengers");
            Console.WriteLine("♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦ ♦");
            Console.ResetColor();
            Console.WriteLine("In a world threatened by an imminent cosmic catastrophe, Earth's mightiest heroes, \nThe Avengers, assemble to confront a powerful enemy set on destroying the planet. \nAs they unite their unique powers, the team faces internal conflicts, \nunexpected alliances, and a race against time to save humanity from impending doom. \nGet ready for an epic battle that transcends individual abilities, \nproving that together, they are unstoppable.");

            //promotie menu einde
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Please select an option (using the arrow keys and press Enter):");

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
                    Console.Clear();
                    Console.Write("Loading");

                    // loading animatie start
                    for (int i = 0; i < 4; i++)
                    {
                        Thread.Sleep(500); // Wacht 500 milliseconden (0,5 seconden)
                        Console.Write(".");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Loading Completed.");
                    Thread.Sleep(1000);
                    // loading animatie eind

                    PerformAction(menuOptions[selectedIndex]);
                    exit = true;
                    break;
            }

        } while (!exit);

        Console.CursorVisible = true;
    }

    static void PerformAction(string option)
    {
        Console.WriteLine("Selected: " + option);
        switch (option)
        {
            case "Login as a guest":
                Thread.Sleep(1500);
                GuestLogin.Start();
                break;

            case "Login as an user":
                Thread.Sleep(1500);
                GlobalLogin.Start();
                break;

            case "Creating an account":
                Thread.Sleep(1500);
                Console.WriteLine(" Must be implemented");
                break;
        }
    }
}
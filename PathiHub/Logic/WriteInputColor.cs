public static class WriteInputColor
{
    // This Class return a string with a Readline() as input
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
}


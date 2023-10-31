public static class PrintStringToColor
{
    // This Class return a string with a Readline() as input
    public static void Color(string sentence,string color)
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

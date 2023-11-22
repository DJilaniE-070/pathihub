public class DiscriptionPrinter
{
    public static void DrawBox(Movie chosenmovie)
    {
        MoviesAccess access = new();
        if (access.LoadFromJson() == true)
        {
            List<Movie> movies = access.GetItemList();
            string? selectedmovie = chosenmovie.Plot;

            // Define the width of the box
            int boxWidth = 30;

            // Split the plot into lines
            List<string> plotLines = WrapText(selectedmovie, boxWidth - 4);

            // Create the top border of the box
            Console.WriteLine("+" + new string('-', boxWidth - 2) + "+");

            // Create empty lines in the box
            for (int i = 0; i < (boxWidth - 6) / 2; i++)
            {
                Console.WriteLine("|" + new string(' ', boxWidth - 2) + "|");
            }

            // Print the plot lines within the box
            foreach (string line in plotLines)
            {
                Console.WriteLine($"| {line.PadRight(boxWidth - 6)} |");
            }

            // Create empty lines in the box
            for (int i = 0; i < (boxWidth - 6) / 2; i++)
            {
                Console.WriteLine("|" + new string(' ', boxWidth - 2) + "|");
            }

            // Create the bottom border of the box
            Console.WriteLine("+" + new string('-', boxWidth - 2) + "+");
        }
    }

    // Function to wrap text into lines of a specified length
    private static List<string> WrapText(string text, int lineLength)
    {
        List<string> lines = new List<string>();

        string[] words = text.Split(' ');

        string currentLine = "";
        foreach (string word in words)
        {
            if ((currentLine + word).Length <= lineLength)
            {
                currentLine += word + " ";
            }
            else
            {
                lines.Add(currentLine.Trim());
                currentLine = word + " ";
            }
        }

        if (!string.IsNullOrWhiteSpace(currentLine))
        {
            lines.Add(currentLine.Trim());
        }

        return lines;
    }
}
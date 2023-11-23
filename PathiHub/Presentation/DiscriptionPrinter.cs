public class DiscriptionPrinter
{
    public static void DrawBox(Movie chosenmovie)
    {
        MoviesAccess access = new();
        if (access.LoadFromJson() == true)
        {
            List<Movie> movies = access.GetItemList();
            string? selectedmovie = chosenmovie.Plot;

            // Set the fixed width of the box
            int boxWidth = 40;

            // Create the top border of the box(-4 is so that the sides match)
            Console.WriteLine("+" + new string('-', boxWidth - 4) + "+");

            // Split the plot into sentences
            List<string> sentences = SplitIntoSentences(selectedmovie);

            // Calculate the number of empty lines on each side of the text
            int emptyLines = Math.Max((boxWidth - 6 - sentences.Count) / 2, 0);

            // Limit the number of empty lines to 8 on each side
            emptyLines = Math.Min(emptyLines, 0);

            // Create empty lines on the top side of the text
            for (int i = 0; i < emptyLines; i++)
            {
                Console.WriteLine("|" + new string(' ', boxWidth - 2) + "|");
            }

            // Print the sentences within the box
            foreach (string sentence in sentences)
            {
                // Wrap the sentence within the box width
                List<string> wrappedLines = WrapText(sentence, boxWidth - 6);
                foreach (string line in wrappedLines)
                {
                    Console.WriteLine($"| {line.PadRight(boxWidth - 6)} |");
                }
            }

            // Create empty lines on the bottom side of the text
            for (int i = 0; i < emptyLines; i++)
            {
                Console.WriteLine("|" + new string(' ', boxWidth - 2) + "|");
            }

            // Create the bottom border of the box
            Console.WriteLine("+" + new string('-', boxWidth - 4 ) + "+");
        }
    }

    // Function to split text into sentences
    private static List<string> SplitIntoSentences(string text)
    {
        // This is a simple implementation and may not cover all cases
        char[] sentenceSeparators = { '.', '!', '?' };
        return text.Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries)
                   .Select(sentence => sentence.Trim())
                   .Where(sentence => !string.IsNullOrWhiteSpace(sentence))
                   .ToList();
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

public class SaveSeatInfoToJson
{
    public static void SaveToJson()
    {
        // Get the current directory path
        string currentDirectory = Directory.GetCurrentDirectory();

        string folderPath = @"C:\Path\To\Your\Folder"; // Change this to your desired folder path
        string filePath = Path.Combine(folderPath, "reservedSeats.json");

        // Serialize the reserved seats and write to the file
        string json = JsonConvert.SerializeObject(reservedSeats, Formatting.Indented);
        File.WriteAllText(filePath, json);

        Console.WriteLine("Reservations saved to: " + filePath);
    }
}
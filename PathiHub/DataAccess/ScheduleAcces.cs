using Newtonsoft.Json;
public class ScheduleAcces : JsonFileAccess<Schedule>
{
    public ScheduleAcces(int Auditorium) : base($"ScheduleAuditorium{Auditorium}.json"){}


    public override void SaveToJson()
    {
        List<string> CFSchedule = new();
        string filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/", fileName));

        foreach (Schedule item in itemList)
        {
            string thing = JsonConvert.SerializeObject(item, Formatting.None);
            CFSchedule.Add(thing);
        }

        // Use a for loop instead of Formatting.Indented for the entire list
        for (int i = 0; i < CFSchedule.Count; i++)
        {
            // Manually add a newline and indentation to each item except the last one
            if (i < CFSchedule.Count - 1)
            {
                CFSchedule[i] = CFSchedule[i] + ",";
            }
        }

        string json1 = $"[{string.Join(Environment.NewLine, CFSchedule)}]";
        File.WriteAllText(filePath, json1);
    }
}
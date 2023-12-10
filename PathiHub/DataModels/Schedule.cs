
using Newtonsoft.Json;
public class Schedule
{
    public string Scheduled { get; set; }
    public string MovieTitle { get; set; }
    public string Directors { get; set; }

    // object want can int of N/A zijn zelfde voor storedauditorium kan 2d list zijn of string
    public string ReleaseYear { get; set; }
    public List<List<string>>? StoredAuditorium{get;set;}

}
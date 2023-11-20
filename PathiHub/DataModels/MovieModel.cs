public class Movie
{
    public string MovieTitle { get; set; }
    public int? ReleaseYear { get; set; }
    public List<string>? Genre { get; set; }
    public string Director { get; set; }
    public List<string>? Writers { get; set; }
    public string? Plot { get; set; }
    public double? Rating { get; set; }
    public int? RuntimeMinutes { get; set; }
    public string? Language { get; set; }
    public string? Country { get; set; }
    public List<string>? Awards { get; set; }
    
    public int? Auditorium { get; set; }
}
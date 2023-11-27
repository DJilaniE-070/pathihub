public class Movie
{
    public string MovieTitle { get; set; }
    public int ReleaseYear { get; set; }
    public string ReleaseDate {get;set;}
    
    public List<string> Genre { get; set; }
    
    public List<string> Actors {get;set;}
    public string Director { get; set; }
    public List<string> Directors { get; set; }
    public List<string> Writers { get; set; }
    public string Plot { get; set; }
    // IMDB rating if connected to wifi
    public double Rating { get; set; }
    public int RuntimeMinutes { get; set; }
    public string Language { get; set; }
    public List<string> Languages {get;set;}
    public string Country { get; set; }

    public List<string> Countrys {get;set;}
    
    public int Auditorium {get; set;}
    public List<string> Awards { get; set; }

    public string Poster {get;set;}
}
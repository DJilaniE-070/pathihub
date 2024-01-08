public class PromotionMovie
{
    
    
        public string MovieTitle { get; set; }
        public int ReleaseYear { get; set; }
        public string ReleaseDate {get;set;}
    
        public List<string> Genre { get; set; }
    
        public List<string> Actors {get;set;}
        public string Directors { get; set; }
        public List<string> Writers { get; set; }
        public string Plot { get; set; }
        // IMDB rating if connected to wifi
        public double Rating { get; set; }
        public int RuntimeMinutes { get; set; }
        public string Languages { get; set; }
        public string Countrys { get; set; }
    
        public List<int> Auditorium {get; set;}
        public List<string> Awards { get; set; }

        public string Poster {get;set;}

        // Voorbeeld scheduled is [Maandaag,1300-1500]
        public List<string> Scheduled {get;set;}
        public string PromotedMovieColor { get; set; }
    
}
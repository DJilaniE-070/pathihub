using Newtonsoft.Json;

public class Movie
{
    [JsonProperty("movieTitle")]
    public string MovieTitle { get; set; }

    [JsonProperty("releaseYear")]
    public int ReleaseYear { get; set; }

    [JsonProperty("genre")]
    public List<string> Genre { get; set; }

    [JsonProperty("director")]
    public string Director { get; set; }

    [JsonProperty("writers")]
    public List<string> Writers { get; set; }

    [JsonProperty("plot")]
    public string Plot { get; set; }

    [JsonProperty("rating")]
    public double Rating { get; set; }

    [JsonProperty("runtimeMinutes")]
    public int RuntimeMinutes { get; set; }

    [JsonProperty("language")]
    public string Language { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("awards")]
    public List<string> Awards { get; set; }

    [JsonProperty("posterURL")]
    public string PosterURL { get; set; }
}

public class CastMember
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("role")]
    public string Role { get; set; }
}

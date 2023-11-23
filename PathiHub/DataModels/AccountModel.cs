using System.Text.Json.Serialization;

public class AccountModel
{
    [JsonPropertyName("id")] //TODO: fix id to increase automatically.
    public int Id { get; set; }

    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }
    
    [JsonPropertyName("role")]
    public string Role { get; set; }

    public AccountModel(int id, string emailAddress, string password, string fullName, string role)
    {
        Id = id;
        EmailAddress = emailAddress;
        Password = password;
        FullName = fullName;
        Role = role;
    }
}
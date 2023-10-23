namespace PathiHub.DataModels;

public class CoworkerModel : AccountModel
{
    
    public CoworkerModel(int id, string emailAddress, string password, string fullName, string role) : base(id, emailAddress, password, fullName, role)
    {
        
    }
}
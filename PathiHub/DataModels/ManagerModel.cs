namespace PathiHub.DataModels;

public class ManagerModel : AccountModel
{
    public ManagerModel(int id, string emailAddress, string password, string fullName, string role) : base(id, emailAddress, password, fullName, role)
    {
        
    }
}
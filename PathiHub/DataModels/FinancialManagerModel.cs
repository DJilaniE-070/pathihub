namespace PathiHub.DataModels;

public class FinancialManagerModel : AccountModel
{
    public FinancialManagerModel(int id, string emailAddress, string password, string fullName, string role) : base(id, emailAddress,
        password, fullName, role)
    {
        
    }
}
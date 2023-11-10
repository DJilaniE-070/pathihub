namespace PathiHub.Presentation;

public class UserRegistration
{
    public void Start()
    {
        Console.WriteLine("Please follow the steps below to create an account:");
        Console.WriteLine("1. Enter your email address");
        string email = Console.ReadLine() ?? String.Empty;
        Console.WriteLine("2. Enter your password");
        string password = Console.ReadLine() ?? String.Empty;
        Console.WriteLine("3. Enter your full name");
        string fullName = Console.ReadLine() ?? String.Empty;
        // TODO: check input validation
        AccountModel acc = new AccountModel(0, email, password, fullName, "Customer");
        AccountsLogic.UpdateList(acc);
    }

    public void RegisterUser()
    {
        Console.WriteLine("Please follow the steps below to create a user account:");

        Console.WriteLine("Enter your email address: ");
        string userEmail = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter your password: ");
        string userPassword = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter your full name: ");
        string userFullname = Console.ReadLine() ?? string.Empty;

        AccountModel userAccount = new AccountModel(0, userEmail, userPassword, userFullname, "User");
        AccountsLogic.UpdateList(userAccount);

        Console.WriteLine("User account created successfully.");
    }

}
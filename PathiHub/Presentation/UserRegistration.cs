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

    public static void RegisterUser()
    {
        Console.WriteLine("Please follow the steps below to create a user account:");

        Console.WriteLine("Enter your email address: ");
        string? userEmail = Console.ReadLine();

        Console.WriteLine("Enter your password: ");
        string? userPassword = Console.ReadLine();

        List<string> passwordIssues = PasswordCheck.PasswordIssue(userPassword);

        if (passwordIssues.Count > 0)
        {
            Console.WriteLine("Invalid password. Please check the following requirements:");

            foreach (var issue in passwordIssues)
            {
                Console.WriteLine($"- {PasswordCheck.GetIssueDescription(issue)}");
            }
            return;
        }

        if (!PasswordCheck.IsValid(userPassword))
        {
            Console.WriteLine("Invalid password. Please check the password requirements.");
            return;
        }

        Console.WriteLine("Enter your full name: ");
        string? userFullname = Console.ReadLine();

        AccountModel userAccount = new AccountModel(0, userEmail, userPassword, userFullname, "User");
        AccountsLogic.UpdateList(userAccount);

        Console.WriteLine("User account created successfully.");
    }
}
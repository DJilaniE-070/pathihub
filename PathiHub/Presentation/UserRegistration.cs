namespace PathiHub.Presentation;

public class UserRegistration
{
    public static void RegisterUser()
    {
        Console.WriteLine("Please follow the steps below to create a user account:");

        string? userEmail = null;
        while (string.IsNullOrEmpty(userEmail) || !userEmail.Contains('@'))
        {
            Console.WriteLine("Enter your email address: ");
            userEmail = Console.ReadLine();

            if (!userEmail.Contains('@'))
            {
                Console.WriteLine("The email is invalid. Please enter a valid email address");
            }
        }

        Console.WriteLine("Password should be between 8 and 20 characters");
        Console.WriteLine("Password should contain at least one special character");
        Console.WriteLine("Password should contain at least one number");
        Console.WriteLine("Password should contain at least one uppercase");

        string? userPassword = null;
        List<string> passwordIssues = new List<string>();
        while (string.IsNullOrEmpty(userPassword) || passwordIssues.Count > 0 || !PasswordCheck.IsValid(userPassword))
        {
            Console.WriteLine("Enter your password: ");
            userPassword = Console.ReadLine();

            passwordIssues = PasswordCheck.PasswordIssue(userPassword);

            if (passwordIssues.Count > 0 || !PasswordCheck.IsValid(userPassword))
            {
                Console.WriteLine("Invalid password. Please check the following requirements:");

                foreach (var issue in passwordIssues)
                {
                    Console.WriteLine($"- {PasswordCheck.GetIssueDescription(issue)}");
                }
            }
        }

        Console.WriteLine("Enter your full name: ");
        string? Name = Console.ReadLine();
          

        List<AccountModel> ListOfAccounts = AccountsAccess.LoadAll();
        int index = ListOfAccounts.Count()+1;
        Console.WriteLine(index);
        AccountModel userAccount = new AccountModel(index, userEmail, userPassword, Name, "User");
        AccountsLogic.UpdateList(userAccount);

        Console.WriteLine("User account created successfully.");
    }

    private bool CheckInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input cannot be empty");
            return false;
        }

        return true;
    }

    /*
    public void Start()
    {
        Console.WriteLine("Please follow the steps below to create an account:");
        Console.WriteLine("1. Enter your email address");
        string email = Console.ReadLine() ?? String.Empty;
        Console.WriteLine("2. Enter your password");
        string password = Console.ReadLine() ?? String.Empty;
        Console.WriteLine("3. Enter your full name");
        string fullName = Console.ReadLine() ?? String.Empty;
        // TODO: check if input validation is enough or if more should be added
        if (!CheckInput(email) && !CheckInput(password) && !CheckInput(fullName))
        {
            Console.WriteLine("Please try again");
            Start();
        }
        AccountModel acc = new AccountModel(0, email, password, fullName, "Customer");
        AccountsLogic.UpdateList(acc);
    }
    */
}
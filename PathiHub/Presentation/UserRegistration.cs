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
        // TODO: check if input validation is enough or if more should be added
        if (!CheckInput(email) && !CheckInput(password) && !CheckInput(fullName))
        {
            Console.WriteLine("Please try again");
            Start();
        }
        AccountModel acc = new AccountModel(0, email, password, fullName, "Customer");
        AccountsLogic.UpdateList(acc);
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
}
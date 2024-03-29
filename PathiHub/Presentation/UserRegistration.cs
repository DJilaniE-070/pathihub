﻿namespace PathiHub.Presentation;

public class UserRegistration
{
    public static void RegisterUser()
    {
        Console.Clear();
        Helpers.PrintStringToColor(@" 
 _____                     _           _   _                     ___                                    _   
/  __ \                   | |         | | | |                   / _ \                                  | |  
| /  \/ _ __   ___   __ _ | |_   ___  | | | | ___   ___  _ __  / /_\ \  ___   ___   ___   _   _  _ __  | |_ 
| |    | '__| / _ \ / _` || __| / _ \ | | | |/ __| / _ \| '__| |  _  | / __| / __| / _ \ | | | || '_ \ | __|
| \__/\| |   |  __/| (_| || |_ |  __/ | |_| |\__ \|  __/| |    | | | || (__ | (__ | (_) || |_| || | | || |_ 
 \____/|_|    \___| \__,_| \__| \___|  \___/ |___/ \___||_|    \_| |_/ \___| \___| \___/  \__,_||_| |_| \__|
                                                                                                            
                                                                                                            
","DarkYellow");

        Helpers.CharLine('-' ,80);
        Console.WriteLine("");

        Console.WriteLine("Please follow the steps below to create a user account:");
        Console.WriteLine("");

        Helpers.CharLine('-' ,80);
        Thread.Sleep(300);

        // asks for the user email and checks for @
        string? userEmail = null;
        while (string.IsNullOrEmpty(userEmail) || !userEmail.Contains('@'))
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Enter your email address: ");
            userEmail = Helpers.Color("DarkYellow");
            Console.ResetColor(); 

            if (!userEmail.Contains('@'))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The email is invalid. Please enter a valid email address\n");
            }
        }

        Console.ResetColor();
        Thread.Sleep(300);

        Helpers.CharLine('-' ,80);
        Console.WriteLine("Password should be between 8 and 20 characters");
        Console.WriteLine("Password should contain at least one special character");
        Console.WriteLine("Password should contain at least one number");
        Console.WriteLine("Password should contain at least one uppercase");
        Helpers.CharLine('-' ,80);

        // Asks for the password and asks for password confirmation, also checks if password contains all criteria
        string? userPassword = null;
        string? confirmPassword = null;
        List<string> passwordIssues = new List<string>();

        // Password entry loop to ensure it meets requirements
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Enter your password: ");
            userPassword = SecurePassword.MaskPassword("");
            Console.ResetColor();

            passwordIssues = PasswordCheck.PasswordIssue(userPassword);

            // Check if the password meets requirements
            if (passwordIssues.Count > 0 || !PasswordCheck.IsValid(userPassword))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid password. Please check the following requirements:");
                Console.ResetColor();

                foreach (var issue in passwordIssues)
                {
                    Console.WriteLine($"- {PasswordCheck.GetIssueDescription(issue)}");
                }

                continue;
            }

            // Check to see if email is already registered / in use
            if (IsEmailExists(userEmail))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The entered email is already registered. You will be redirected.\n");
                Thread.Sleep(3000);
                Console.Clear();
                UserRegistration.RegisterUser();
                return;
                
            }

            // asks for password confirmation
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Please confirm your password: ");
            confirmPassword = SecurePassword.MaskPassword("");

            // Check if both passwords match
            if (userPassword != confirmPassword)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passwords do not match. Please try again.");
                Console.ResetColor();
                continue; // Restarts the loop for password entry
            }

            break; // Exit the loop when passwords match and meet the requirements
        }

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Enter your full name: ");
        string? Name = Helpers.Color("DarkYellow");

        // Loads the existing accounts and creates a new user account
        // inserts it into the json
        List<AccountModel> ListOfAccounts = AccountsAccess.LoadAll();

        // to create a new user id
        int index = ListOfAccounts.Count()+1;
        
        AccountsLogic accountsLogic = new AccountsLogic();
        AccountModel userAccount = new AccountModel(index, userEmail, userPassword, Name, "User");
        accountsLogic.UpdateList(userAccount);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("User account created successfully.");

        Thread.Sleep(1500);
        Console.WriteLine("You will be redirected to the User menu.");
        Thread.Sleep(2000);
        Console.Clear();
        Console.ResetColor();
        AccountModel NewAcc = accountsLogic.CheckLogin(userEmail, userPassword);
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

    private static bool IsEmailExists(string email)
    {
        List<AccountModel> listOfAccounts = AccountsAccess.LoadAll();
        return listOfAccounts.Any(account => account.EmailAddress == email);
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
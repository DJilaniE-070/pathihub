using System.Text.RegularExpressions;

public static class PasswordCheck
{   
    public static bool IsLower(string password)
    {
        if (!Regex.IsMatch(password, @"[a-z]"))
        {
            return false;
        }
        return true;
    }

    public static bool IsUpper(string password)
    {
        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            return false;
        }
        return true;
    }

    public static bool IsLength(string password)
    {
        if (password.Length < 8 || password.Length > 20)
        {
            return false;
        }
        return true;
    }

    public static bool IsInt(string password)
    {
        if (!Regex.IsMatch(password, @"[0-9]"))
        {
            return false;
        }
        return true;
    }

    public static bool IsSymbol(string password)
    {
        if (!Regex.IsMatch(password, @"[!@#$%^&*]"))
        {
            return false;
        }
        return true;
    }
}

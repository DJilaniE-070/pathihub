using System.Text.RegularExpressions;

public static class PasswordCheck
{
    public static bool IsValidPassword(string password)
    {
        if (!Regex.IsMatch(password, @"[a-z]"))
        {
            return false;
        }
        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            return false;
        }
        if (password.Length < 8 || password.Length > 20)
        {
            return false;
        }
        if (!Regex.IsMatch(password, @"[0-9]"))
        {
            return false;
        }
        if (!Regex.IsMatch(password, @"[!@#$%^&*]"))
        {
            return false;
        }
        return true;
    }
}

using System.Collections;
using System.Text.RegularExpressions;
using Microsoft.Win32.SafeHandles;

public static class PasswordCheck
{
    public static bool IsValid(string password)
    {
        return PasswordIssue(password).Count == 0;
    }

    public static List<string> PasswordIssue(string password)
    {
        var invalid = new List<string>();
        if (!IsLower(password))
        {
            invalid.Add("Password");
        }
        if (!IsUpper(password))
        {
            invalid.Add("upper");
        }
        if (!IsLength(password))
        {
            invalid.Add("length");
        }
        if (!IsNumber(password))
        {
            invalid.Add("number");
        }
        if (!IsSymbol(password))
        {
            invalid.Add("symbol");
        }
        return invalid;
    }

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

    public static bool IsNumber(string password)
    {
        if (!Regex.IsMatch(password, @"[0-9]"))
        {
            return false;
        }
        return true;
    }

    public static bool IsSymbol(string password)
    {
        if (!Regex.IsMatch(password, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
        {
            return false;
        }
        return true;
    }
    public static string GetIssueDescription(string issue)
    {
        return issue switch
        {
            "Password" => "Password must contain at least one lowercase letter.",
            "upper" => "Password must contain at least one uppercase letter.",
            "length" => "Password must be between 8 and 20 characters long.",
            "number" => "Password must contain at least one numeric digit.",
            "symbol" => "Password must contain at least one special symbol (!@#$%^&*()_+[]{};:<>|./?,-).",
            _ => "Don't know error",
        };
    }
}

public static class SecurePassword
{
    public static string MaskPassword(string password)
    {
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            // back en enter werkt niet
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
            }
        }
        // stopt input als enter is geklikt
        while (key.Key != ConsoleKey.Enter);
        
        return password;
    }
}

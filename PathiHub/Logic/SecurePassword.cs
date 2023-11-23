public static class SecurePassword
{
    public static string MaskPassword(string password)
    {
        ConsoleKeyInfo key;
        // elke password is geel
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        do
        {
            key = Console.ReadKey(true);
            // als back en enter niet wordt ingedrukt, elke input veranderen in *
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            // als backspace wordt geklikt en er is minimaal 1 lengte in password verwijderd het de laatste char en de laatste asterisk
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Remove(password.Length - 1);
                // backspace gevolgd door spatie en weer backspace zodat de asterisk ook dynamisch wordt weergegeven
                Console.Write("\b \b");
            }
        }
        // stopt input als enter is geklikt
        while (key.Key != ConsoleKey.Enter);
        Console.WriteLine();
        return password;
    }
}

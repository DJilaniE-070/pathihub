using System.Reflection;

public class EditObjOutTabel
{   

    public static void Editor<T>(string ObjName ,T DataAcces)
     {
        MoviesAccess selectedMovieAccess;
        if (DataAcces is MoviesAccess movieAccess)
        {
            selectedMovieAccess = movieAccess;
            
            var SelectedObj = MovieCatalogePrinter.TabelPrinter(selectedMovieAccess);
            Helpers.PrintStringToColor($"\nAre you sure you want to Edit the {ObjName} '{SelectedObj.MovieTitle} from {SelectedObj.ReleaseYear}'.\nPlease type 'yes' or 'no'.", "blue");
            Console.Write("\u2192 ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes")
            {
                DisplayObj(SelectedObj);
            }

            if (answer == "no")
            {
                Console.WriteLine($"You have chosen not to Edit the {ObjName}: {SelectedObj.MovieTitle} from {SelectedObj.MovieTitle} from {SelectedObj.ReleaseYear}.");
                Helpers.PrintStringToColor($"Do you want to change another {ObjName}?", "blue");
                Console.Write("\u2192 ");
                string answer2 = Console.ReadLine().ToLower();
                if (answer2 == "yes")
                {
                    Console.WriteLine("You will be redirected");
                    Thread.Sleep(800);
                    MovieOptionPresentation.EditMoviePresentation();
                }

                if (answer2 == "no")
                {
                    Console.WriteLine("You will be redirected");
                    Thread.Sleep(800);
                    ManagerMenu.Start();
                }
            }

            Console.Clear();
        }
    }
    static List<string> GetPropertyNames<T>(T obj)
    {
        // Get the type of the class
        Type objType = typeof(T);

        // Get all public properties of the class
        var properties = objType.GetProperties();

        // Extract property names and put them into a list
        List<string> propertyNames = new List<string>();
        foreach (var property in properties)
        {
            propertyNames.Add(property.Name);
        }

        return propertyNames;
    }
        static List<string> GetPropertyValues<T>(T obj)
    {
        // Get the type of the class
        Type objType = typeof(T);

        // Get all public properties of the class
        var properties = objType.GetProperties();

        // Extract property values and put them into a list
        List<string> propertyValues = new List<string>();
        foreach (var property in properties)
        {
            // Get the value of the property for the provided object
            object value = property.GetValue(obj);
            if (value != null)
            {
                if (value is List<string> stringList)
                {
                    string concatenatedString = string.Join(", ", stringList);
                    propertyValues.Add(concatenatedString);
                }
                else
                {
                    propertyValues.Add(value.ToString());
                }
            }
            else
            {
                propertyValues.Add("X");
            }
        }

        return propertyValues;
    }

    static string FormatText(string input)
    {
        const int maxLength = 20;

        if (input.Length > maxLength)
        {
            return input.Substring(0, maxLength - 3) + "...";
        }

        return input.PadRight(maxLength);
    }


    public static void DisplayObj<T>(T obj)
    {
        List<string> FieldNames = GetPropertyNames(obj);
        List<string> FieldValues = GetPropertyValues(obj);

        int selectedIndex = 0; 

       do
    {
        Console.Clear();
        Console.WriteLine(@"
 _____    _ _ _              ___  ___                 
|  ___|  | (_) |             |  \/  |                 
| |__  __| |_| |_ ___  _ __  | .  . | ___ _ __  _   _ 
|  __|/ _` | | __/ _ \| '__| | |\/| |/ _ \ '_ \| | | |
| |__| (_| | | || (_) | |    | |  | |  __/ | | | |_| |
\____/\__,_|_|\__\___/|_|    \_|  |_/\___|_| |_|\__,_|                                                                                                                                       
                                                      ");
        Helpers.CharLine('-' ,80);
        Console.WriteLine("What do you like to change");
        Helpers.CharLine('-' ,80);
        Console.WriteLine("\n\n");

        // Display menu options
        for (int i = 0; i < FieldNames.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine($"{FieldNames[i],-20}| {FormatText(FieldValues[i])}");

            Console.ResetColor();
        }
        

        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.UpArrow && selectedIndex > 0)
        {
            selectedIndex--;
        }
        else if (key.Key == ConsoleKey.DownArrow && selectedIndex < FieldNames.Count - 1)
        {
            selectedIndex++;
        }
        else if (key.Key == ConsoleKey.Enter)
        {
            break;
        }

    }   
    while (true);
    
    if (selectedIndex >= 0)
    {
        Helpers.CharLine('-' ,80);
        string fieldName = FieldNames[selectedIndex];
        string fieldValue = FieldValues[selectedIndex];

        Console.WriteLine($"You selected: {fieldName}\n");
        Console.WriteLine($"This is the current value: {fieldValue}");
        Helpers.CharLine('-' ,80);
        Helpers.PrintStringToColor($"Enter new value for {fieldName}: ","blue");
        string newValue = Helpers.Color("Yellow");

        Helpers.CharLine('-' ,80);
        Helpers.PrintStringToColor("Do you want to change something else (type in yes / no)","blue");
        while(true)
        {
        string choice = Helpers.Color("Yellow").ToLower();

        if (choice == "no")
        {
            Console.WriteLine("\nYou will be redirected to the main menu");
            Thread.Sleep(800);
            ManagerMenu.Start();
            break;
        }
        else if (choice == "yes")
        {
            DisplayObj(obj);
        }
        else
        {
            Helpers.PrintStringToColor("Please type in yes or no","red");
        }


        }
    }
    }
}
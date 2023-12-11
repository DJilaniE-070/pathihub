using System.Reflection;
using System.Text;


public class PerformActionToTabel
{   
    static Movie SelectedMovie = null;
    static MoviesAccess SelectedMovieData = null;
    static Reservation SelectedReservation = null;
    static ReservationAccess SelectedReservationData = null;

    public static void Editor(string Header, string ObjName ,List<string> ColomnNames)
     {


        if (ObjName.ToLower() == "movie")
        {
            MoviesAccess selectedMovieAccess = new();
            if (selectedMovieAccess.LoadFromJson() != false)
            {
                List<Movie> movies = selectedMovieAccess.GetItemList();
                Movie movie = (Movie)ObjCatalogePrinter.TabelPrinter<Movie>(Header, movies,ColomnNames);
                SelectedMovie = movie;
                SelectedMovieData = selectedMovieAccess;
            }
        }
        else if (ObjName.ToLower() == "reservation")
        {
            ReservationAccess SelectedReservationAcces = new();
            if (SelectedReservationAcces.LoadFromJson() != false)
            {
                List<Reservation> reservations = SelectedReservationAcces.GetItemList();


                Reservation reservation = (Reservation)ObjCatalogePrinter.TabelPrinter<Reservation>(Header, reservations,ColomnNames);
                SelectedReservation = reservation;
                SelectedReservationData = SelectedReservationAcces;
            }
        }
        else
        {
            Console.WriteLine("Error object can't be edited");
            Helpers.BackToYourMenu();
        }
            Helpers.PrintStringToColor($"\nAre you sure you want to edit this {ObjName}'.\nPlease type 'yes' or 'no'.", "blue");
            Console.Write("\u2192 ");
            string answer = Console.ReadLine().ToLower();

            if (answer == "yes")
                {
                    if (SelectedMovie != null)
                    {
                        EditObj(SelectedMovie);
                    }
                    else if (SelectedReservation != null)
                    {
                        EditObj(SelectedReservation);
                    }
                }

            if (answer != "yes")
            {
                Console.WriteLine($"You have chosen not to edit this {ObjName}");
                Helpers.PrintStringToColor($"Do you want to edit another {ObjName}?", "blue");
                Console.Write("\u2192 ");
                string answer2 = Console.ReadLine().ToLower();
                if (answer2 == "yes")
                {
                    Console.WriteLine("You will be redirected");
                    Thread.Sleep(800);
                    Console.Clear();
                    MovieOptionPresentation.EditMoviePresentation();
                }

                if (answer2 != "yes")
                {
                    Console.WriteLine("You will be redirected");
                    Thread.Sleep(800);
                    Helpers.BackToYourMenu();
                }
            }

            Console.Clear();
    }
    static List<string> GetPropertyNames<T>(T obj)
    {
        Type objType = typeof(T);

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
        Type objType = typeof(T);
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
        else
        {
            return input + new string(' ', Math.Max(0, maxLength - input.Length));
        }
    }



    static void ChangeValues<T> (T obj, string fieldName, string NewValue)
    {
        Type objectType = obj.GetType();
        var field = objectType.GetProperty(fieldName);

        if (field != null)
        {
            PropertyInfo propertyInfo = objectType.GetProperty(fieldName);
            switch (propertyInfo.PropertyType.Name)
            {
                case "Int32":
                    field.SetValue(obj, Convert.ToInt32(NewValue));

                    break;
                case "Double":
                    field.SetValue(obj, Convert.ToDouble(NewValue));
                    break;
                case "String":
                    field.SetValue(obj, NewValue);
                    break;
                // List<string> is represented as List`1 in the type name
                case "List`1": 
                    List<string> LOS = NewValue.Split(",").ToList();
                    field.SetValue(obj,LOS);
                    break;
            }
        }
        else
            {
                Console.WriteLine($"Field '{fieldName}' not found in type '{objectType.Name}'.");
            }
    }
    static string EditPLot (string fieldValue)
    {
        string originalString = fieldValue;
        int currentPosition = 0;


        while (true)
        {
            Console.Clear();
Helpers.PrintStringToColor(@"  
______ _       _   
| ___ \ |     | |  
| |_/ / | ___ | |_ 
|  __/| |/ _ \| __|
| |   | | (_) | |_ 
\_|   |_|\___/ \__| ","yellow");
        Helpers.CharLine('-' ,80);

            if (!originalString.EndsWith(" ")&& !originalString.StartsWith(" "))
            {   
                originalString = " " + originalString + " ";
            }

            DisplayStringWithHighlight(originalString, currentPosition);
            
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentPosition = Math.Max(0, currentPosition - 1);
                    break;
                case ConsoleKey.RightArrow:
                     currentPosition = Math.Min(originalString.Length-1, currentPosition + 1);
                    break;
                case ConsoleKey.Backspace:
                    try
                    {
                    if (currentPosition > -1)
                    {
                    
                        originalString = originalString.Remove(currentPosition , 1);
                        currentPosition--;
                    }
                    break;
                    }
                    catch(Exception)
                    {
                    break;
                    }
                    
                case ConsoleKey.Enter:
                    return originalString.Trim();
                default:
                    try
                    {            
                    
                    if (currentPosition >= 0 && currentPosition <= originalString.Length)
                    {
                        originalString = originalString.Insert(currentPosition+1, key.KeyChar.ToString());
                    }
                    else if (currentPosition == -1)
                    {
                        originalString = key.KeyChar + originalString;
                    }                    
                    currentPosition++;
                        break;
                    }
                    catch(Exception)
                    {
                        break;
                    }
            }

    }
    }

    static void DisplayStringWithHighlight(string input, int highlightPosition)
    {

        Console.Write("Edited plot: ");
        for (int i = 0; i < input.Length; i++)
        {
            if (i == highlightPosition)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Write(input[i]);

            if (i == highlightPosition)
            {
                Console.ResetColor();
            }
        }
        Console.WriteLine();
    }
    public static void EditObj<T>(T obj)
    {
        List<string> FieldNames = GetPropertyNames(obj);
        List<string> FieldValues = GetPropertyValues(obj);


        int selectedIndex = 0; 

       do
    {
        Console.Clear();
        Helpers.PrintStringToColor(@"
 _____    _ _ _              ___  ___                 
|  ___|  | (_) |             |  \/  |                 
| |__  __| |_| |_ ___  _ __  | .  . | ___ _ __  _   _ 
|  __|/ _` | | __/ _ \| '__| | |\/| |/ _ \ '_ \| | | |
| |__| (_| | | || (_) | |    | |  | |  __/ | | | |_| |
\____/\__,_|_|\__\___/|_|    \_|  |_/\___|_| |_|\__,_|                                                                                                                                       
                                                      ","yellow");
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
       else if (key.Key == ConsoleKey.Backspace)
        {
            Helpers.BackToYourMenu();
            break;
        }
        else if (key.Key == ConsoleKey.Escape)
        {
            Helpers.MainMenu();
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
        
        if (fieldName == "Plot")
        {
        string changedplot = EditPLot(fieldValue);
        ChangeValues(obj,fieldName,changedplot);
        }
        else
        {
            string NewValue = Helpers.Color("yellow");
            ChangeValues(obj,fieldName,NewValue);
        }

        Helpers.CharLine('-' ,80);
        Helpers.PrintStringToColor("Do you want to change something else (type in yes / no)","blue");
        while(true)
        {
        string choice = Helpers.Color("Yellow").ToLower();

        if (choice == "no")
        {
            Console.WriteLine("\nYou will be redirected to the main menu");
            Thread.Sleep(800);
            if (SelectedMovieData != null)
            {
             SelectedMovieData.SaveToJson();
            }
            else if (SelectedReservationData != null)
            {
                SelectedReservationData.SaveToJson();
            }
            else
            {
                Helpers.PrintStringToColor("Something went wrong", "red");
            }
            Helpers.BackToYourMenu();
            break;
        }
        else if (choice == "yes")
        {
            EditObj(obj);
        }
        else
        {
            Helpers.PrintStringToColor("Please type in yes or no","red");
        }
        }
    }
    }
}    
    
  

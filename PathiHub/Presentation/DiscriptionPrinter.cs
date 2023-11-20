using Microsoft.VisualBasic.CompilerServices;

public class DiscriptionPrinter
{
    public static void DrawBox(Movie chosenmovie)
    {
        MoviesAccess access= new();
        if (access.LoadFromJson() == true)
        {
            List<Movie> movies = access.GetItemList();
            string? selectedmovie = chosenmovie.Plot;
            
            
            // List<Movie> movies = access.GetItemList();
            // string? plot = movieData.Plot;
            string whiteLine = "|";
            Console.WriteLine("+-----------------------------------------------------------------------------+"); 
            Console.WriteLine("|                                                                             |");
            Console.WriteLine("|                                                                             |"); 
            Console.WriteLine("|                                                                             |"); 
            Console.WriteLine($"{whiteLine}{selectedmovie}{whiteLine}");
            Console.WriteLine("|                                                                             |");
            Console.WriteLine("|                                                                             |");
            Console.WriteLine("|                                                                             |");
            Console.WriteLine("|                                                                             |");
            Console.WriteLine("|                                                                             |");
            Console.WriteLine("+-----------------------------------------------------------------------------+");
            
        }
        
    }
}
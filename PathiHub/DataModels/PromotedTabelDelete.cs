namespace PathiHub.DataModels;

public class PromotedTabelDelete
{
    
    public static void MovieDeletor(string HeaderX)
    {
        string header =    (@"
    ______                          _   _              ___  ___                 
    | ___ \                        | | (_)             |  \/  |                 
    | |_/ / __ ___  _ __ ___   ___ | |_ _  ___  _ __   | .  . | ___ _ __  _   _ 
    |  __/ '__/ _ \| '_ ` _ \ / _ \| __| |/ _ \| '_ \  | |\/| |/ _ \ '_ \| | | |
    | |  | | | (_) | | | | | | (_) | |_| | (_) | | | | | |  | |  __/ | | | |_| |
    \_|  |_|  \___/|_| |_| |_|\___/ \__|_|\___/|_| |_| \_|  |_/\___|_| |_|\__,_|
                                                                                                       
                                   ");
        PromotionMovieAccess movieData = new();
        Movie selectedMovie = PromotedTabelLogic.TabelPrinter(movieData, header);

        Helpers.PrintStringToColor($"\nAre you sure you want to delete the movie '{selectedMovie.MovieTitle}'.\nPlease type 'yes' or 'no'.", "blue");
        Console.Write("\u2192 ");
        string answer = Console.ReadLine().ToLower();

        if (answer == "yes")
        {
            movieData.RemoveThing(selectedMovie);
            Helpers.PrintStringToColor($"You have deleted the movie: '{selectedMovie.MovieTitle}'.", "red");
            Console.WriteLine("Dit is de check voor promoted tabeld delete");
            Thread.Sleep(2000);
            

            // Serialize the updated list back to JSON
            movieData.SaveToJson();
        }

        if (answer == "no")
        {
            Console.WriteLine($"You have chosen not to delete the movie: {selectedMovie.MovieTitle}.");
            Helpers.PrintStringToColor("Do you want to choose another movie to remove?", "blue");
            Console.Write("\u2192 ");
            string answer2 = Console.ReadLine().ToLower();
            if (answer2 == "yes")
            {
                Console.WriteLine("You will be redirected");
                Thread.Sleep(800);
                MovieOptionPresentation.RemoveMoviePresentation();
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

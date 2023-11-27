namespace PathiHub.DataModels;

public class PromotedTabelDelete
{
    
    public static void MovieDeletor(string HeaderX)
    {
        string header = (@"
___  ___           _        _____       _        _                  
|  \/  |          (_)      /  __ \     | |      | |                 
| .  . | _____   ___  ___  | /  \/ __ _| |_ __ _| | ___   __ _  
| |\/| |/ _ \ \ / / |/ _ \ | |    / _` | __/ _` | |/ _ \ / _` |
| |  | | (_) \ V /| |  __/ | \__/\ (_| | || (_| | | (_) | (_| |
\_|  |_/\___/ \_/ |_|\___|  \____/\__,_|\__\__,_|_|\___/ \__, |
                                                          __/ |     
                                                         |___/     
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
using System;
using PathiHub.DataModels;
using PathiHub.Presentation;

public class PromotionMenu
{
    public string header = (@"
                                   ______                          _   _              ___  ___                 
                                   | ___ \                        | | (_)             |  \/  |                 
                                   | |_/ / __ ___  _ __ ___   ___ | |_ _  ___  _ __   | .  . | ___ _ __  _   _ 
                                   |  __/ '__/ _ \| '_ ` _ \ / _ \| __| |/ _ \| '_ \  | |\/| |/ _ \ '_ \| | | |
                                   | |  | | | (_) | | | | | | (_) | |_| | (_) | | | | | |  | |  __/ | | | |_| |
                                   \_|  |_|  \___/|_| |_| |_|\___/ \__|_|\___/|_| |_| \_|  |_/\___|_| |_|\__,_|
                                                                                                       
                                   ");

    public void Start()
    {
       

        //deze conosole.writeline moet een header worden en pas moviecatalogprintermangerversion aan dat hij headers aanneemt
        PromotedMovieCataloge();
        Thread.Sleep(3000);
        
    }
    
    //this method prints the promoted movie cataloge. And searches the one you selected and want to remove from the json file
    public void PromotedMovieCataloge()
    {
        string header = "These Movies are Currently being promoted:\nWhich one do you want to be changed?";
        PromotionMovieAccess promotionMovieAccess = new();
        
        //eerst verwijderen
        PromotedTabelDelete.MovieDeletor("test om een film te verwijderen");
        
        //dan toevoegen
        // Movie PromoteThisSelectedMovie = PromotedTabelLogic.TabelPrinter(promotionMovieAccess, header);
        // Helpers.PrintStringToColor($"\nAre you sure you want to modify the promotion for the movie '{PromoteThisSelectedMovie.MovieTitle}'? Please type 'yes' or 'no'.", "blue");
        
                
        Console.Write("\u2192 ");
        string? answer = Console.ReadLine().ToLower();
        switch (answer)
        {
            case "yes":
                // Toggle the promotion status of the selected movie
                Helpers.PrintStringToColor($"Please choose a new movie you would like to promote.", "red");
                AddNewPromotionMovie();
                Thread.Sleep(2000);
                break;

            case "no":
                // Ask if the person wants to promote another movie or perform other actions
                break;

            default:
                Console.WriteLine("The input given cannot be used because it's not a valid string.");
                PromotionMenu starter = new();
                starter.PromotedMovieCataloge();
                break;
        }
        
    }
    
    public void AddNewPromotionMovie()
    {
        string header = "add new movie to the json";
        MoviesAccess movieData = new();
        Movie selectedMovie = MovieCatalogePrinterManagerVersion.TabelPrinter(movieData, header);
        Helpers.PrintStringToColor($"\nAre you sure you want to modify the promotion for the movie '{selectedMovie.MovieTitle}'? Please type 'yes' or 'no'.", "blue");
        Console.Write("\u2192 ");
        string? answer = Console.ReadLine().ToLower();
        
        

        switch (answer)
        {
            case "yes":
                
                //maak verbinding met de json en voel selectdMovie toe
                // Load existing promotion movie data from JSON
                       
                PromotionMovieAccess promotedMovies = new();
                if (promotedMovies.LoadFromJson())
                {
                    List<Movie> x = promotedMovies.GetItemList();
                    x.Add(selectedMovie); 
                    promotedMovies.SaveToJson(); 
                }
                
                
                Helpers.PrintStringToColor($"You have succesfully changed the promotion status for the movie: '{selectedMovie.MovieTitle}'.", "green");
                PromotedMovieCataloge();
                Thread.Sleep(2000);
                break;

            case "no":
                // Ask if the person wants to promote another movie or perform other actions
                break;

            default:
                Console.WriteLine("The input given cannot be used because it's not a valid string.");
                break;
        }
    }
}





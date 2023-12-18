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
    }
    
    //this method prints the promoted movie cataloge. And searches the one you selected and want to remove from the json file
    public void PromotedMovieCataloge()
    {
        string header = "These Movies are Currently being promoted:\nWhich one do you want to be changed?";
        Thread.Sleep(1000);
        PromotionMovieAccess promotionMovieAccess = new();
        
        //eerst verwijderen
        PromotedTabelDelete.MovieDeletor("test om een film te verwijderen");
        
        //Dan toevoegen
        AddNewPromotionMovie();
    }
    
    public void AddNewPromotionMovie()
    {
        string header = "Which movie would you like to promote";
        MoviesAccess movieData = new();
        Movie selectedMovie = MovieCatalogePrinterManagerVersion.TabelPrinter(movieData, header);
        Helpers.PrintStringToColor($"\nAre you sure you want to modify the promotion for the movie '{selectedMovie.MovieTitle}'? Please type 'yes' or 'no'.", "blue");
        Console.Write("\u2192 ");
        string? answer = Helpers.Color("Yellow").ToLower();
        
        

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
                Menu.Start();
                Thread.Sleep(2000);
                break;

            case "no":
                Console.WriteLine("you will be redirected to make a diffrent choice");
                Thread.Sleep(2000);
                Console.Clear();
                AddNewPromotionMovie();
                break;

            default:
                Console.WriteLine("The input given cannot be used because it's not a valid string.");
                break;
        }
    }
}





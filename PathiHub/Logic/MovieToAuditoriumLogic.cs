public class MovieToAuditoriumLogic
{
    public void Connector(Movie chosenmovie)
    {
        MoviesAccess access = new();
                if (access.LoadFromJson() == true)
                {
                    List<Movie> movies = access.GetItemList();
                    int SelectedAuditoruim = chosenmovie.Auditorium;
                    SeatMap seatmap = new SeatMap(SelectedAuditoruim);
                    
                    if (SelectedAuditoruim == 1)
                    {
                        seatmap.Auditoriums();
                    }
                    
                    if (SelectedAuditoruim == 2)
                    {
                        seatmap.Auditoriums();
                    }
                    
                    if (SelectedAuditoruim == 3)
                    {
                        seatmap.Auditoriums();
                    }
                   
                    
                }
    }
    
}
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
                    seatmap.Auditoriums();
                    
                }
    }
    
}
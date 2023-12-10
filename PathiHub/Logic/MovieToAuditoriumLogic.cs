public class MovieToAuditoriumLogic
{
    public void Connector(Movie chosenmovie)
    {
        MoviesAccess access = new();
                if (access.LoadFromJson() == true)
                {
                    List<Movie> movies = access.GetItemList();
                    
                    // int SelectedAuditoruim = chosenmovie.Auditorium;
                    // SeatMap seatmap = new SeatMap(SelectedAuditoruim);
                    // seatmap.Auditoriums();
                    
                }
    }
    
    public void initializerAuditorium(List<Movie> movies)
    {
        foreach (Movie movie in movies)
        {
            foreach(int Auditorium in movie.Auditorium)
            {
                initializerTimes(Auditorium, movie);
            }
        }
    }

    public void initializerTimes (int Auditorium,Movie movie)
    {
        ScheduleAcces scheduleAcces = new(Auditorium);
        List<Schedule> WholeSchedule = scheduleAcces.GetItemList();
        foreach (Schedule schedule in WholeSchedule)
        {
        // Check if any of the scheduled times match those from the movie
            foreach (string movieScheduledTime in movie.Scheduled)
            {
                if (schedule.Scheduled.Contains(movieScheduledTime))
                {
                    // Update the title based on the movie
                    schedule.MovieTitle = movie.MovieTitle;
                    schedule.Directors = movie.Directors;
                    schedule.ReleaseYear = movie.ReleaseYear;
                }
            }
        }  
        scheduleAcces.SaveToJson();
    }
}
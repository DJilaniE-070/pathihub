public class MovieToAuditoriumLogic
{
    public void Connector(Movie chosenmovie)
    {
        int SelectedAuditoruim = MovieSchedule.Selectedauditorium;
        List<List<string>>Auditorium = HasAuditorium(chosenmovie,SelectedAuditoruim);
        if (SelectedAuditoruim != null && Auditorium != null)
        {
            SeatMap seatmap = new SeatMap(SelectedAuditoruim,Auditorium);
            seatmap.Auditoriums();
        }
        if (SelectedAuditoruim != null && Auditorium == null)
        {
            SeatMap seatmap = new SeatMap(SelectedAuditoruim);
            seatmap.Auditoriums();
        }
        else
        {
            Console.WriteLine("Something went wrong");
        }
    }

    public List<List<string>> HasAuditorium(Movie movie, int AudNum)
    {
        List<List<string>> result = new List<List<string>>();
        ScheduleAcces acces = new(AudNum);
        string SelectedSchedule = MovieSchedule.SelectedSchedule;
        if (acces.LoadFromJson())
        {
            List<Schedule> WholeSchedule = acces.GetItemList();
            foreach (Schedule schedule in WholeSchedule)
            {
                if ( movie.MovieTitle == schedule.MovieTitle && SelectedSchedule == schedule.Scheduled)
                {
                    result = schedule.StoredAuditorium;
                    return result;
                }
            }
            return null;
        }

        // Return null if conditions are not met or if there's an issue with loading from JSON
        return null;
    }

    // Hieronder is de code om de films waarden juist te in laden bij de schedule json
    
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
        scheduleAcces.LoadFromJson();
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
                    schedule.ReleaseYear = Convert.ToString(movie.ReleaseYear);
                }
            }
        }  
        scheduleAcces.SaveToJson();
    }
}
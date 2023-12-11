using System.Security.Cryptography.X509Certificates;

public class MovieToAuditoriumLogic
{
    public void Connector(Movie chosenmovie)
    {
        Console.Clear();
        int SelectedAuditoruim = MovieSchedule.Selectedauditorium;
        Schedule? schedule = HasAuditorium(chosenmovie,SelectedAuditoruim);
        if (SelectedAuditoruim != null && schedule != null)
        {
            SeatMap seatmap = new SeatMap(SelectedAuditoruim, schedule.StoredAuditorium);
            seatmap.Auditoriums();
        }
        else if
         (SelectedAuditoruim!= null && schedule == null)
        {
            SeatMap seatmap = new SeatMap(SelectedAuditoruim);
            seatmap.Auditoriums();
        }
        else
        {
            Console.WriteLine("Something went wrong");
        }
    }

    public static Schedule? HasAuditorium(Movie movie, int AudNum)
    {
        ScheduleAcces acces = new(AudNum);
        string SelectedSchedule = MovieSchedule.SelectedSchedule;
        if (acces.LoadFromJson())
        {
            List<Schedule> WholeSchedule = acces.GetItemList();
            foreach (Schedule schedule in WholeSchedule)
            {
                if ( movie.MovieTitle == schedule.MovieTitle && SelectedSchedule == schedule.Scheduled && schedule.StoredAuditorium != null)
                {
                    return schedule;
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

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

    // Dit is voor de begine van programma elke week als het zo is dan clear alle stored seats zodat er geen stoelen voor altijd opgeslagen word
    public bool ClearSchedules ()
    {
        ScheduleAcces accesAud1 = new(1);
        ScheduleAcces accesAud2 = new(2);
        ScheduleAcces accesAud3 = new(3);
        
        if (accesAud1.LoadFromJson() && accesAud2.LoadFromJson() && accesAud3.LoadFromJson() )
        {
            List<Schedule> Aud1 = accesAud1.GetItemList();
            List<Schedule> Aud2 = accesAud2.GetItemList();
            List<Schedule> Aud3 = accesAud3.GetItemList();

            if (Aud1 != null && Aud2 != null && Aud3 != null)
            {
                foreach(Schedule schedule1 in Aud1)
                {
                    schedule1.MovieTitle = "N/A";
                    schedule1.Directors = "N/A";
                    schedule1.ReleaseYear = "N/A";
                    schedule1.StoredAuditorium = null;
                }
                foreach(Schedule schedule2 in Aud2)
                {
                    schedule2.MovieTitle = "N/A";
                    schedule2.Directors = "N/A";
                    schedule2.ReleaseYear = "N/A";
                    schedule2.StoredAuditorium = null;
                }

                foreach(Schedule schedule3 in Aud3)
                {
                    schedule3.MovieTitle = "N/A";
                    schedule3.Directors = "N/A";
                    schedule3.ReleaseYear = "N/A";
                    schedule3.StoredAuditorium = null;
                }
                accesAud1.SaveToJson();
                accesAud2.SaveToJson();
                accesAud3.SaveToJson();
                return true;
            }
            else
            {
                Console.WriteLine("Something went wrong");
                return false;

            }
        }
        return false;
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

    public void RemoveSchedules(List<string> schedules)
    {
        foreach (string schedule in schedules)
        {
            string[] parts = schedule.Split('/');
            if (parts.Length == 3)
            {
                string Aud = parts [2];

                int Auditorium = int.Parse(Aud[3].ToString());
                ScheduleAcces acces = new(Auditorium);

                if(acces.LoadFromJson())
                {
                    List<Schedule> SchedulesFromJson = acces.GetItemList();
                    foreach (Schedule JsonSchedule in SchedulesFromJson)
                    {
                        if (JsonSchedule.Scheduled == schedule)
                        {
                            JsonSchedule.MovieTitle = "N/A";
                            JsonSchedule.Directors = "N/A";
                            JsonSchedule.ReleaseYear = "N/A";
                            JsonSchedule.StoredAuditorium = null;
                        }
                    }
                    acces.SaveToJson();
                }
            }
        }

    }
}
using Newtonsoft.Json;

public class ReservationAcces
{

    public List<Reservation> reservationlist = new List<Reservation>();
    
    public void SaveReservationToJson()
    {
        string filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/reservation.json"));
        string json = JsonConvert.SerializeObject(reservationlist, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public bool LoadMoviesFromJson()
    {
        string filePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/reservation.json"));
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            reservationlist = JsonConvert.DeserializeObject<List<Reservation>>(json);
            return true;
        }
        else
        {
            return false;
        }
    }
}
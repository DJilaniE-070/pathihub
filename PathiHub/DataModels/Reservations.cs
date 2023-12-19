public class Reservation
{
    public string FullName {get; set;}
    public string Email{get;set;}
    public string Auditorium {get;set;}
    public List<string> SeatNames{get;set;}
    public string movie {get; set;}
    public string Date {get; set;}
    public string Time {get;set;}
    public double Price {get;set;}
    public string ReservationCode {get; set;}
    public string CinemaLocation{get;}

    public Reservation()
    {    
    CinemaLocation = "Wijnhaven 107";
    }

}
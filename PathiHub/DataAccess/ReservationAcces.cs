public class ReservationAccess : JsonFileAccess<Reservation>
{
    public ReservationAccess() : base("reservation.json"){}
}
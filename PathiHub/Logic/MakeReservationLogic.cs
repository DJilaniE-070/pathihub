using Newtonsoft.Json;
public class MakeReservation
{
    private static List<Reservation> Reservations = new List<Reservation>();

    public bool AddReservation(Reservation reservation)
    {
        bool reservationExist = false;
        foreach (Reservation reservation_ in Reservations)
        {
            if (string.Equals(reservation_.FullName, reservation.FullName) &&
                string.Equals(reservation_.ReservationCode, reservation.ReservationCode))
            {
                // Reservation already exists
                reservationExist = true;
                break;
            }
        }
        if (reservationExist == true)
        {
            return false; 
            //return false because Reservation exist and the reservation has not been added to the json list
        }
        else
        {
            // Reservation doesn't exist, proceed to add it to the list
            Reservations.Add(reservation);
            return true;
        }
    }

    public bool RemoveReservation(string FullName,string Email, string movieTitle)
    {
        Reservation ReservationToRemove = null;

        foreach (Reservation reservation in Reservations)
        {
            //search based on title and director
            if (string.Equals(reservation.FullName, FullName ) &&
                string.Equals(reservation.Email, Email ) &&
                string.Equals(reservation.movie.MovieTitle, movieTitle))
            {
                ReservationToRemove = reservation;
                break;
            }
        }

        if (ReservationToRemove != null)
        {
            Reservations.Remove(ReservationToRemove);
            return true;
        }
        else
        {
            return false;
        }
    }

}
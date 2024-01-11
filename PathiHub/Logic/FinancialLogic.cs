public class FinancialLogic
{
    public double taxRate = 0.09;

    public double totalSum;
    public double totalWithoutTax;
    public double Tax;
    public void start()
    {

        ReservationAccess access = new();

        if(access.LoadFromJson()!= false)
        {
            List<Reservation> reservations = access.GetItemList();
            totalSum = reservations.Sum(reservation => reservation.Price);
            Tax = totalSum * taxRate;
            totalWithoutTax = totalSum - Tax;

        }
    }
}
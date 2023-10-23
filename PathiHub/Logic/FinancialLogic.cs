public static class FinancialLogic
{
    public static int TotalReservations = 0;
    public static double TotalRevenue = 0;

    //methode om aantal reserveringen bij te voegen
    public static void UpdateTotalReservations(int amount)
    {
        TotalReservations += amount;
    }

    //methode om de opbrengsten bij te voegen
    public static void UpdateTotalRevenue(double amount)
    {
        TotalRevenue += amount;
    }

    /*
    nog niet geimplementeerd maar een stukje code dat kan 
    gebruikt worden om de 2 mehodes in deze class te gebruiken:

    public void ToAdd()
    {
        //voeg reservering toe

        int aantalReserveringen = 5;
        FinancialLogic.UpdateAantalReserveringen(aantalReserveringen);

        //voeg opbrengsten toe

        double opbrengsten = 100.50;
        FinancialLogic.UpdateOpbrengsten(opbrengsten);
    }
    */
}

public static class FinancialLogic
{
    public static int AantalReserveringen = 0;
    public static double AlleOpbrengsten = 0;

    //methode om aantal reserveringen bij te voegen
    public static void UpdateAantalReserveringen(int aantal)
    {
        AantalReserveringen += aantal;
    }

    //methode om de opbrengsten bij te voegen
    public static void UpdateOpbrengsten(double bedrag)
    {
        AlleOpbrengsten += bedrag;
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
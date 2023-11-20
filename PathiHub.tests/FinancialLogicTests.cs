namespace PathiHub.tests;

[TestClass]
public class FinancialLogicTests
{
    [TestMethod]
    public void UpdateTotalReservationsTest()
    {
        FinancialLogic.UpdateTotalReservations(5);
        Assert.AreEqual(5, FinancialLogic.TotalReservations);
    }
    
    [TestMethod]
    public void UpdateTotalRevenueTest()
    {
        FinancialLogic.UpdateTotalRevenue(5.5);
        Assert.AreEqual(5.5, FinancialLogic.TotalRevenue);
    }
}
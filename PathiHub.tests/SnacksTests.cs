using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SnacksMenuTests
{
    [TestMethod]
    public void AddSnacks_Test()
    {
        SnacksMenu snacksMenu = new SnacksMenu(ismanager: true);

        snacksMenu.AddSnacks();

        Assert.AreEqual(1, snacksMenu.GetSnacksCount()); 
    }

    [TestMethod]
    public void EditSnacks_Test()
    {
        SnacksMenu snacksMenu = new SnacksMenu(ismanager: true);
        double newPrice = 5.99;
        bool newIsAvailable = false;
        List<SnacksData> loadedSnacksData = snacksMenu.LoadSnacksDataFromJson();
        SnacksData originalSnack = loadedSnacksData.Count > 0 ? loadedSnacksData[0] : null;

        Assert.IsNotNull(originalSnack, "No sdata");

        double originalPrice = originalSnack.Price;
        bool originalIsAvailable = originalSnack.IsAvailable;
        snacksMenu.EditSnacks(originalSnack);

        Assert.AreEqual(newPrice, originalSnack.Price);
        Assert.AreEqual(newIsAvailable, originalSnack.IsAvailable);

        originalSnack.Price = originalPrice;
        originalSnack.IsAvailable = originalIsAvailable;
    }

    [TestMethod]
    public void RemoveSnacks_Test()
    {
        SnacksMenu snacksMenu = new SnacksMenu(ismanager: true);
        List<SnacksData> loadedSnacksData = snacksMenu.LoadSnacksDataFromJson();
        SnacksData snackToRemove = loadedSnacksData.Count > 0 ? loadedSnacksData[0] : null;

        Assert.IsNotNull(snackToRemove, "No data");

        int initialCount = snacksMenu.GetSnacksCount();
        snacksMenu.RemoveSnacks(snackToRemove);

        Assert.AreEqual(initialCount - 1, snacksMenu.GetSnacksCount());
    }
}


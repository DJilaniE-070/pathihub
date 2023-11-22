namespace PathiHub.tests;

[TestClass]
public class AccountsLogicTests
{
    private AccountsLogic _accountsLogic = new AccountsLogic();
    [ClassInitialize]
    public static void Initialize(TestContext context) 
    {
    }
    
    [TestMethod]
    public void UpdateListTest()
    {
        int count = _accountsLogic.GetAccounts().Count;
        var acc = new AccountModel(count + 1, "test", "test", "test", "test");
        AccountsLogic.UpdateList(acc);
        Assert.AreEqual(count + 1, _accountsLogic.GetAccounts().Count);
        Assert.AreEqual(count + 1, AccountsLogic.GetById(count + 1).Id);
    }
    
    [TestMethod]
    public void GetByIdTest()
    {
        var acc = new AccountModel(_accountsLogic.GetAccounts().Count + 1, "test", "test", "test", "test");
        AccountsLogic.UpdateList(acc);
        Assert.AreEqual(acc, AccountsLogic.GetById(_accountsLogic.GetAccounts().Count + 1));
    }
    
    [TestMethod]
    public void CheckLoginTest()
    {
        var acc = new AccountModel(_accountsLogic.GetAccounts().Count + 1, "test", "test", "test", "test");
        AccountsLogic.UpdateList(acc);
        Assert.AreEqual(acc, AccountsLogic.CheckLogin("test", "test"));
    }

    [TestMethod]
    public void GetAccountsTest()
    {
        Assert.IsNotNull(_accountsLogic.GetAccounts());
    }
}
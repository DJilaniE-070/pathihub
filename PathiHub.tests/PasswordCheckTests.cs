namespace PathiHub.tests;

[TestClass]
public class PasswordCheckTests
{
    [TestMethod]
    public void IsLowerTest()
    {
        Assert.IsTrue(PasswordCheck.IsLower("abcd"));
        Assert.IsFalse(PasswordCheck.IsLower("ABCD"));
    }
    
    [TestMethod]
    public void IsUpperTest()
    {
        Assert.IsTrue(PasswordCheck.IsUpper("ABCD"));
        Assert.IsFalse(PasswordCheck.IsUpper("abcd"));
    }
    
    [TestMethod]
    public void IsLengthTest()
    {
        Assert.IsFalse(PasswordCheck.IsLength("abcd"));
        Assert.IsTrue(PasswordCheck.IsLength("abcd12345"));
        Assert.IsFalse(PasswordCheck.IsLength("12345678911234567891123456789"));
    }
    
    [TestMethod]
    public void IsNumberTest()
    {
        Assert.IsTrue(PasswordCheck.IsNumber("1234"));
        Assert.IsFalse(PasswordCheck.IsNumber("abcd"));
    }
    
    [TestMethod]
    public void IsSymbolTest()
    {
        Assert.IsTrue(PasswordCheck.IsSymbol("ab#cd"));
        Assert.IsFalse(PasswordCheck.IsSymbol("1234"));
    }
    
}
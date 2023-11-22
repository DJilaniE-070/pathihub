namespace PathiHub.tests;

[TestClass]
public class PasswordCheckTests
{
    [TestMethod]
    [DataRow("abcd", true)]
    [DataRow("ABCD", false)]
    [DataRow("1234", false)]
    [DataRow("abcd12345", true)]
    [DataRow("AbC", true)] 
    public void IsLowerTest(string password, bool expected)
    {
        Assert.AreEqual(expected, PasswordCheck.IsLower(password));
    }
    
    // [TestMethod]
    // public void IsLowerTest()
    // {
    //     Assert.IsTrue(PasswordCheck.IsLower("abcd"));
    //     Assert.IsFalse(PasswordCheck.IsLower("ABCD"));
    // }
    
    [TestMethod]
    [DataRow("ABCD", true)]
    [DataRow("abcd", false)]
    [DataRow("1234", false)]
    [DataRow("abcd12345", false)]
    [DataRow("AbC123", true)]
    [DataRow("AbC", true)]
    [DataRow("ABC123", true)]
    public void IsUpperTest(string password, bool expected)
    {
        Assert.AreEqual(expected, PasswordCheck.IsUpper(password));
    }
    
    
    // public void IsUpperTest()
    // {
    //     Assert.IsTrue(PasswordCheck.IsUpper("ABCD"));
    //     Assert.IsFalse(PasswordCheck.IsUpper("abcd"));
    // }
    
    [TestMethod]
    [DataRow("abcd", false)]
    [DataRow("1234", false)]
    [DataRow("abcd12345", true)]
    [DataRow("12345678911234567891123456789", false)]
    public void IsLengthTest(string password, bool expected)
    {
        Assert.AreEqual(expected, PasswordCheck.IsLength(password));
    }
    
    // public void IsLengthTest()
    // {
    //     Assert.IsFalse(PasswordCheck.IsLength("abcd"));
    //     Assert.IsTrue(PasswordCheck.IsLength("abcd12345"));
    //     Assert.IsFalse(PasswordCheck.IsLength("12345678911234567891123456789"));
    // }
    
    [TestMethod]
    [DataRow("1234", true)]
    [DataRow("abcd", false)]
    [DataRow("abcd12345", true)]
    [DataRow("AbC123", true)]
    [DataRow("AbC", false)]
    [DataRow("ABC123", true)]
    public void IsNumberTest(string password, bool expected)
    {
        Assert.AreEqual(expected, PasswordCheck.IsNumber(password));
    }
    // public void IsNumberTest()
    // {
    //     Assert.IsTrue(PasswordCheck.IsNumber("1234"));
    //     Assert.IsFalse(PasswordCheck.IsNumber("abcd"));
    // }
    
    [TestMethod]
    [DataRow("####", true)]
    [DataRow("abcd", false)]
    [DataRow("ab#cd", true)]
    [DataRow("1234", false)]
    [DataRow("abcd#12345", true)]
    [DataRow("AbC123", false)]
    [DataRow("AbC", false)]
    [DataRow("ABC123", false)]
    public void IsSymbolTest(string password, bool expected)
    {
        Assert.AreEqual(expected, PasswordCheck.IsSymbol(password));
    }
    // public void IsSymbolTest()
    // {
    //     Assert.IsTrue(PasswordCheck.IsSymbol("ab#cd"));
    //     Assert.IsFalse(PasswordCheck.IsSymbol("1234"));
    // }
    
}
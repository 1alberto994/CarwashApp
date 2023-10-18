namespace CarWashTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestViewStautusCounter()
    {
        AutoImplant implant = new("1", Implant.States.M)
        Company company = new(); 
        Assert.AreEqual($"Current state = {Implant.States.M} Counter wash: {}" ,company.ViewImplantByID("1"));
    }
}
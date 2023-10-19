namespace CarWashTest;

[TestClass]
public class CarWashLibraryTest
{

    [TestMethod]
    public void TestImplantChangeState()
    {
        Implant implant = new("1", 13.4);
        Assert.IsTrue(implant.ChangeState(Implant.States.M, new DateOnly(2023, 12, 10)));
        Assert.AreEqual(Implant.States.M, implant.CurrentState);

        Assert.IsFalse(implant.ChangeState(Implant.States.M, new DateOnly(2023, 12, 10)));
    }

    [TestMethod]
    public void CompanyConstructorWithCollection()
    {
        Implant[] implants = { new("1", 12.3), new("2", 10.4), new("3", 7.4) };
        Company company = new(implants);
    }

    [TestMethod]
    public void TestSearchMostBrokenImplant()
    {
        Implant implant1 = new("1", 13.4);
        Implant implant2 = new("2", 19.12);
        Implant implant3 = new("3", 25.50);
        implant1.ChangeState(Implant.States.B, DateOnly.FromDateTime(DateTime.Now));

        Implant[] implants = { implant1, implant2, implant3 };
        Company companyWithCollection = new(implants);

        Assert.AreEqual(implant1, companyWithCollection.SearchMostBrokenImplant());
        implant2.ChangeState(Implant.States.B, DateOnly.FromDateTime(DateTime.Now));
        implant2.ChangeState(Implant.States.B, DateOnly.FromDateTime(DateTime.Now));
        Assert.AreEqual(implant1, companyWithCollection.SearchMostBrokenImplant());
        implant2.ChangeState(Implant.States.O, DateOnly.FromDateTime(DateTime.Now));
        implant2.ChangeState(Implant.States.B, DateOnly.FromDateTime(DateTime.Now));
        Assert.AreEqual(implant2, companyWithCollection.SearchMostBrokenImplant());



    }


    [TestMethod]
    public void TestMostUsedAutoImplant()
    {
        AutoImplant implant1 = new("1", 13.4);
        Implant implant2 = new("2", 19.12);
        AutoImplant implant3 = new("3", 25.50);
        implant1.MakeWash();

        Implant[] implants = { implant1, implant2, implant3 };
        Company companyWithCollection = new(implants);

        Assert.AreEqual(implant1, companyWithCollection.SearchMostUsedAutoImplant());
        implant3.MakeWash();
        implant3.MakeWash();
        Assert.AreEqual(implant3, companyWithCollection.SearchMostUsedAutoImplant());

    }
}
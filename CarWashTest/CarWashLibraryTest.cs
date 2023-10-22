using System.Runtime.Serialization;

namespace CarWashTest;

[TestClass]
public class CarWashLibraryTest
{

    [TestMethod]
    public void TestInsertNewImplant()
    {
        Implant[] implants = { new("1", 12.3), new("2", 10.4), new("3", 7.4) };
        Company testCompany = new(implants);
        AutoImplant insertedImplant = new("4", 2);
        testCompany.InsertNewImplant(insertedImplant);
        Assert.AreEqual(insertedImplant, testCompany.ViewImplantByID("4"));
        Assert.IsTrue(testCompany.InsertNewImplant(insertedImplant));

    }

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

    [TestMethod]
    public void TestViewImplantByID()
    {
        AutoImplant implant = new("1", 1);
        SelfImplant implant1 = new("2", 2);
        SelfImplant implant2 = new("3", 3);
        Implant[] implants = { implant, implant1, implant2 };
        Company companyWithCollection = new(implants);
        Assert.AreEqual(implant, companyWithCollection.ViewImplantByID("1"));
    }

    [TestMethod]

    public void TestViewImplant()
    {
        SelfImplant implant1 = new("1", 1);
        SelfImplant implant2 = new("2", 2);
        AutoImplant implant = new("3", 3);
        List<Implant> mynewimplant = new List<Implant>();
        mynewimplant.Add(implant1);
        mynewimplant.Add(implant2);
        mynewimplant.Add(implant);

        Company companyWithCollection = new();
        List<Implant> viewimplant = (List<Implant>)companyWithCollection.ViewImplant();
        bool flag = true;
        for (int i = 0; i < viewimplant.Count; i++)
        {
            flag = mynewimplant[i] == viewimplant[i] ? true : false;
            if (!flag) break;
        }
        Assert.IsTrue(flag);

    }

    [TestMethod]

    public void TestSearchStatusMaintenance()
    {
        SelfImplant implant1 = new("1", 1);
        implant1.ChangeState(Implant.States.M, DateOnly.FromDateTime(DateTime.Now));
        AutoImplant implant2 = new("2", 2);
        Company company = new();
        company.InsertNewImplant(implant1);
        company.InsertNewImplant(implant2);
        List<Implant> maintenance = (List<Implant>)company.SearchStatusMaintenance();
        Assert.IsTrue(maintenance.Count == 1 && maintenance[0] == implant1);

    }


}
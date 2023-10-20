using Newtonsoft.Json;

namespace FileManagerLybraryTest;

[TestClass]
public class CarWashLibraryTest
{
    [TestMethod]
    public void TestFilePushAllMethod()
    {
        Implant[] implants = { new AutoImplant("1", 1), new AutoImplant("2", 1), new AutoImplant("3", 1) };

        Company company = new();

        string inPath = "C:/Users/bsett/Desktop/MyGitHub/TrainingProgramProject/CarwashApp/implants/jsonImplants.json";
        string outPath = "C:/Users/bsett/Desktop/MyGitHub/TrainingProgramProject/CarwashApp/JsonInventory/SavedImplant.json";

        FileManager fileManager = new(inPath, outPath, company);
        fileManager.pushAll();
        bool flag = true;

        List<Implant> implantsTookFromCompany = (List<Implant>)company.ViewImplant();
        for (int i = 0; i < implants.Length; i++)
        {
            if (implantsTookFromCompany[i].ID != implants[i].ID || !(implantsTookFromCompany[i] is AutoImplant))
            {
                flag = false;
                break;
            }
        }
        Assert.IsTrue(flag);
    }
}
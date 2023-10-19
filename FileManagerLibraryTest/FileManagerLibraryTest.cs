using System.Text.Json;

namespace FileManagerLybraryTest;

[TestClass]
public class CarWashLibraryTest
{
    [TestMethod]
    public void TestFilePushAllMethod()
    {
        AutoImplant[] implants = { new AutoImplant("1", 1), new AutoImplant("2", 1), new AutoImplant("3", 1) };

        Company company = new();

        string inPath = "C:/Users/bsett/Desktop/MyGitHub/TrainingProgramProject/CarwashApp/implants/jsonImplants.json";
        string outPath = "C:/Users/bsett/Desktop/MyGitHub/TrainingProgramProject/CarwashApp/JsonInventory/SavedImplant.json";
        using (StreamWriter JsonFileWR = new StreamWriter(inPath))
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            foreach (var implant in implants)
            {
                string serializedImplant = JsonSerializer.Serialize(implant);
                JsonFileWR.WriteLine(serializedImplant);
            }
        }

        FileManager fileManager = new(inPath, outPath, company);
        bool flag = true;

        List<Implant> implantsTookFromCompany = (List<Implant>)company.ViewImplant();
        for (int i = 0; i < implants.Length; i++)
        {
            if (implantsTookFromCompany[i] != implants[i])
            {
                flag = false;
                break;
            }
        }
        Assert.IsTrue(flag);
    }
}
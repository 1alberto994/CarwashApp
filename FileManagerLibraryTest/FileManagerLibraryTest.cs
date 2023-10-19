using System.Text.Json;

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
        using (StreamWriter JsonFileWR = new StreamWriter(inPath))
        {
            foreach (Implant implant in implants)
            {
                string serializedImplant = JsonSerializer.Serialize(implant);
                JsonFileWR.WriteLine(serializedImplant);
            }
        }

        FileManager fileManager = new(inPath, outPath, company);
    }
}
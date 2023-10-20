using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using Microsoft.VisualBasic.FileIO;

namespace FileManagerLybraryTest;

[TestClass]
public class CarWashLibraryTest
{
    private string _inPath = "..\\..\\..\\..\\implants\\jsonImplants.json";

    private string _outPath = "..\\..\\..\\..\\implants\\SaveImplants.json";

    [TestMethod]
    public void TestFilePushAndSaveAllMethod()
    {
        Implant[] implants = { new AutoImplant("1", 1), new AutoImplant("2", 1), new AutoImplant("3", 1) };

        Company company = new();

        FileManager fileManager = new(_inPath, _outPath, company);
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
        fileManager.Dispose();
        Assert.IsTrue(FileSystem.GetFileInfo(_outPath).Length != 0);
    }

    [TestMethod]
    public void TestFIleUpdateWithEvent()
    {
        Implant[] implants = { new AutoImplant("1", 1), new AutoImplant("2", 1), new AutoImplant("3", 1) };
        Company company = new();

        FileManager fileManager = new(_inPath, _outPath, company);
        long oldSavedFileLength = FileSystem.GetFileInfo(_outPath).Length;
        company.InsertNewImplant(new SelfImplant("10", 13.4));
        Assert.IsTrue(FileSystem.GetFileInfo(_outPath).Length > oldSavedFileLength);
    }
}
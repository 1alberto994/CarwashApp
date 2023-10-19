using System.Security.AccessControl;
using System.Text.Json;

public class FileManager
{
    private string _inPath, _outPath;
    private Company _company;

    private async void SaveAll()
    {
        List<Implant> implants = new(); // _company.ViewImplant();

        StreamWriter JsonFileWR = new StreamWriter(_outPath);
        foreach (Implant implant in implants)
        {
            string serializedImplant = JsonSerializer.Serialize(implant);
            await JsonFileWR.WriteLineAsync(serializedImplant);
        }
    }

    private void pushAll()
    {
        StreamReader JsonFileReader = new(_inPath);
        string? jsonLine;
        while ((jsonLine = JsonFileReader.ReadLine()) != null)
        {
            _company.InsertNewImplant(JsonSerializer.Deserialize<Implant>(jsonLine));
        }
    }

    public FileManager(string inPath, string outPath, Company company)
    {
        _inPath = inPath;
        _outPath = outPath;
        _company = company;

        pushAll();
    }

    public FileManager(string inPath, Company company)
    {
        _inPath = _outPath = inPath;
        _company = company;

        pushAll();
    }

    ~FileManager()
    {
            SaveAll();
    }
}
using System.Security.AccessControl;
using System.Text.Json;

public class FileManager
{
    private string _path, _outPath;
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

    public FileManager(string path, Company company)
    {
        _path = path;
        _company = company;
    }

    public void pushAll()
    {
        // prendo gli impianti dal file json e li carico
        // _company.InsertNewImplant(implant);
    }

    ~FileManager()
    {
        SaveAll();
    }

}
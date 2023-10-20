using System.Text.Json.Serialization.Metadata;
using Newtonsoft.Json;

public class FileManager
{
    private string _inPath, _outPath;
    private Company _company;

    private async void SaveAll()
    {
        List<Implant> implants = (List<Implant>) _company.ViewImplant();

        StreamWriter JsonFileWR = new StreamWriter(_outPath);
        foreach (Implant implant in implants)
        {
            // Serializing with NewtonSoftJson to handle the Polimorphism
            string serializedImplant = JsonConvert.SerializeObject(implant, Formatting.None, new JsonSerializerSettings{
                TypeNameHandling = TypeNameHandling.All
            });

            await JsonFileWR.WriteLineAsync(serializedImplant);
        }
    }

    public void pushAll()
    {
        using (StreamReader JsonFileReader = new(_inPath))
        {
            string? jsonLine;
            while ((jsonLine = JsonFileReader.ReadLine()) != null)
            {
                // Serializing with NewtonSoftJson to handle the Polimorphism
                Implant implant = JsonConvert.DeserializeObject<Implant>(jsonLine, new JsonSerializerSettings{
                    TypeNameHandling = TypeNameHandling.Auto
                });
                if(implant is AutoImplant)
                _company.InsertNewImplant(implant);
            }
        }
    }

    public FileManager(string inPath, string outPath, Company company)
    {
        _inPath = inPath;
        _outPath = outPath;
        _company = company;
    }

    public FileManager(string inPath, Company company)
    {
        _inPath = _outPath = inPath;
        _company = company;
    }

    ~FileManager()
    {
        SaveAll();
    }
}
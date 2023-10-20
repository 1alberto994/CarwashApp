using System.Text.Json.Serialization.Metadata;
using Newtonsoft.Json;

public class FileManager : IDisposable
{
    private string _inPath, _outPath;
    private Company _company;

    private bool dispose = false;

    public void Dispose()
    {
        Disposing();
        GC.SuppressFinalize(this);

    }

    protected void Disposing()
    {
        if (!dispose)
        {
            SaveAll();
            dispose = true;
        }
    }

    private void SaveAll()
    {
        List<Implant> implants = (List<Implant>)_company.ViewImplant();
        File.Delete(_outPath);
        string[] serializedImplants = new string[implants.Count];

        for(int i = 0; i< implants.Count; i++){
            // Serializing with NewtonSoftJson to handle the Polimorphism
            serializedImplants[i] = JsonConvert.SerializeObject(implants[i], Formatting.None, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }
        File.WriteAllLines(_outPath, serializedImplants);
    }

    public void pushAll()
    {
        using (StreamReader JsonFileReader = new(_inPath))
        {
            string? jsonLine;
            while ((jsonLine = JsonFileReader.ReadLine()) != null)
            {
                // Serializing with NewtonSoftJson to handle the Polimorphism
                Implant implant = JsonConvert.DeserializeObject<Implant>(jsonLine, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                if (implant is AutoImplant)
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
        Dispose();
    }
}
using Newtonsoft.Json;

public class FileManager : IDisposable
{
    private List<Implant> _implants = new();

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
        File.Delete(_outPath);
        string[] serializedImplants = new string[_implants.Count];

        for (int i = 0; i < _implants.Count; i++)
        {
            // Serializing with NewtonSoftJson to handle the Polimorphism
            serializedImplants[i] = JsonConvert.SerializeObject(_implants[i], Formatting.None, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
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
                // Deserializing with NewtonSoftJson to handle the Polimorphism
                Implant implant = JsonConvert.DeserializeObject<Implant>(jsonLine, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                _company.InsertNewImplant(implant);
                _implants.Add(implant);
            }
        }
    }

    public FileManager(string inPath, string outPath, Company company)
    {
        _inPath = inPath;
        _outPath = outPath;
        _company = company;
        pushAll();
        _company.implantUpdated += ImplantUpdateHandler;
        _company.implantStatusChanged += ImplantStatusChangedHandler;
    }


    public FileManager(string inPath, Company company)
    {
        _inPath = _outPath = inPath;
        _company = company;
        pushAll();
        _company.implantUpdated += ImplantUpdateHandler;
        _company.implantStatusChanged += ImplantStatusChangedHandler;
    }

    public void ImplantUpdateHandler(object implant, EventArgs e)
    {
        if (implant is Implant) _implants.Add((Implant)implant);
        SaveAll();
    }

    public void ImplantStatusChangedHandler(object sender, EventArgs e)
    {
        SaveAll();
    }

    ~FileManager()
    {
        Dispose();
    }
}
using System.Security.AccessControl;

public class FileManager : IDisposable
{
    private string _path;
    private Company _company;

    private void SaveAll()
    {
        //prendi tutti gli impianti da _company

        //fanne il salvataggio su file
    }

    public FileManager(string path)
    {
        _path = path;
    }


    public void Dispose()
    {
        //salvo tutto sui file; 

        try
        {
            SaveAll();
        }
        catch
        {

        }


        GC.SuppressFinalize(this);
    }


    ~FileManager() { }

}
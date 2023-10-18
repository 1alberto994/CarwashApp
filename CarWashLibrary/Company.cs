using System.Reflection.Metadata.Ecma335;

public class Company
{
    private Dictionary<string, Implant> _implants = new();

    private bool _ImplantStatusChanged = true, _autoImplantStatusChanged = true; //event !! (voglio che lo stato di _statusChanged cambi quando viene cambiato in true al cambiamento di stato di un oggetto)

    private Implant _maxImplant = null;
    
    private AutoImplant _mostUsedAutoImplant = null;

    public Implant SearchMostBrokenImplant()
    {
        if (_implants.Count == 0) throw new NoImplantsLoaded("There isn't any Washing Implant in this Company");
        if (!_ImplantStatusChanged) return _maxImplant;

        _ImplantStatusChanged = false;
        int maxTimeBroken = 0;
        foreach (var implant in _implants.Values)
        {
            int howManyTimeBroken = implant.HowManyTimeBroken;
            if (howManyTimeBroken > maxTimeBroken)
            {
                _maxImplant = implant;
                maxTimeBroken = howManyTimeBroken;
            }
        }
        return _maxImplant;
    }

    public AutoImplant SearchMostUsedAutoImplant()
    {
        if (_implants.Count == 0) throw new NoImplantsLoaded("There isn't any Washing Implant in this Company");
        if (!_autoImplantStatusChanged) return _mostUsedAutoImplant;

        _autoImplantStatusChanged = false;
        int maxUse = 0;
        foreach (Implant implant in _implants.Values)
        {
            if (implant is AutoImplant && ((AutoImplant)implant).CountWash >= maxUse)
            {
                maxUse = ((AutoImplant)implant).CountWash;
                _mostUsedAutoImplant = (AutoImplant)implant;
            }
        }
        return _mostUsedAutoImplant;

    }

    public bool InsertNewImplant(Implant implant)
    {
        if (_maxImplant == null) _maxImplant = implant;
        if (_mostUsedAutoImplant == null && implant is AutoImplant) _mostUsedAutoImplant = (AutoImplant)implant;

        try
        {
            _implants.Add(implant.ID, implant);
            return true;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }

    public Company() { }

    public Company(ICollection<Implant> implants)
    {
        foreach (Implant implant in implants) { InsertNewImplant(implant); }
    }
}
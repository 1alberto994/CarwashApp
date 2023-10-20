using System.Reflection.Metadata.Ecma335;

public class Company
{
    private Dictionary<string, Implant> _implants = new();

    private bool _ImplantStatusChanged = true, _autoImplantStatusChanged = true;

    private Implant _maxImplant = null;

    private AutoImplant _mostUsedAutoImplant = null;

    public event EventHandler<EventArgs> implantUpdated;
    public event EventHandler<EventArgs> implantStatusChanged;

    protected virtual void RaiseImplantStatusChangedEvent(EventArgs e)
    {
        EventHandler<EventArgs> statusCheged = implantStatusChanged;
        //check if there are any Subscriber
        if (statusCheged != null)
        {
            statusCheged(this, e);
        }
    }

    protected virtual void RaiseImplantUpdateEvent(EventArgs e, Implant implant)
    {
        EventHandler<EventArgs> update = implantUpdated;
        if (update != null)
        {
            update(implant, e);
        }
    }

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
            _implants[implant.ID] = implant;
            implant.StateChangedEvent += StateChangedHandler;
            RaiseImplantUpdateEvent(EventArgs.Empty, implant);
            if (implant is AutoImplant) { ((AutoImplant)implant).WashDoneEvent += WashIncrementHandler; }
            return true;
        }
        catch (Exception e) when (e is ArgumentException || e is KeyNotFoundException)
        {
            return false;
        }
    }

    public void StateChangedHandler(object state, EventArgs e)
    {
        RaiseImplantStatusChangedEvent(EventArgs.Empty);
        if ((Implant.States)state == Implant.States.B && !_ImplantStatusChanged) { _ImplantStatusChanged = true; }
    }

    public void WashIncrementHandler(object sender, EventArgs e)
    {
        if (!_autoImplantStatusChanged) { _autoImplantStatusChanged = true; }
    }

    public Company() { }

    public Company(ICollection<Implant> implants)
    {
        foreach (Implant implant in implants)
        {
            InsertNewImplant(implant);
        }

    }

    public ICollection<Implant> ViewImplant()
    {

        List<Implant> viewImplant = new List<Implant>();
        foreach (var implant in _implants.Values)
        {
            if (implant is SelfImplant)
            {
                viewImplant.Add(implant);
            }
        }

        foreach (var implant in _implants.Values)
        {
            if (implant is AutoImplant)
            {
                viewImplant.Add(implant);
            }
        }
        return viewImplant;
    }

    public Implant ViewImplantByID(string ID)
    {
        return _implants[ID];
    }

    public ICollection<Implant> SearchStatusMaintenance()
    {
        List<Implant> maintenance = new();
        foreach (var implant in _implants.Values)
        {
            if (implant.CurrentState == Implant.States.M) { maintenance.Add(implant); }
        }

        return maintenance;
    }

}


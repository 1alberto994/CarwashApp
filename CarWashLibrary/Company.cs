using System.Reflection.Metadata.Ecma335;

public class Company
{
    private Dictionary<string, Implant> _implants = new();

    private Implant _mostBrokenImplant = null;

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
        return _mostBrokenImplant;
    }

    public AutoImplant SearchMostUsedAutoImplant()
    {
        if (_implants.Count == 0) throw new NoImplantsLoaded("There isn't any Washing Implant in this Company");
        return _mostUsedAutoImplant;

    }

    public bool InsertNewImplant(Implant implant)
    {
        try
        {
            if (_implants.ContainsKey(implant.ID)) { return true; }
            _implants[implant.ID] = implant;

            if (_mostBrokenImplant == null || implant.HowManyTimeBroken > _mostBrokenImplant.HowManyTimeBroken) _mostBrokenImplant = implant;
            if (implant is AutoImplant && (_mostUsedAutoImplant == null || ((AutoImplant)implant).CountWash > _mostUsedAutoImplant.CountWash)) _mostUsedAutoImplant = (AutoImplant)implant;

            // subrscribe to the status changed event on implant
            implant.StateChangedEvent += StateChangedHandler;
            // subrscribe to the update countWash event on implant
            if (implant is AutoImplant) { ((AutoImplant)implant).WashDoneEvent += WashIncrementHandler; }
            
            RaiseImplantUpdateEvent(EventArgs.Empty, implant);
     
            return true;
        }
        catch (Exception e) when (e is ArgumentException || e is KeyNotFoundException)
        {
            return false;
        }
    }

    public void StateChangedHandler(object implant, EventArgs e)
    {
        RaiseImplantStatusChangedEvent(EventArgs.Empty);
        if (((Implant)implant).CurrentState == Implant.States.B && ((Implant)implant).HowManyTimeBroken > _mostBrokenImplant.HowManyTimeBroken)
        {
            _mostBrokenImplant = (Implant)implant;
        }
    }

    public void WashIncrementHandler(object implant, EventArgs e)
    {
        RaiseImplantStatusChangedEvent(EventArgs.Empty);
        if (((AutoImplant)implant).CountWash > _mostUsedAutoImplant.CountWash) { _mostUsedAutoImplant = (AutoImplant)implant; }
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


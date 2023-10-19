using System.Collections;
using System.Runtime.Serialization;
using System.Xml.XPath;

public class Company
{
    private Dictionary<string, Implant> _implants;
    public ICollection<Implant> ViewImplant()
    {
        
       List<Implant> viewImplant= new List<Implant>();
        foreach (var implant in _implants.Values)
        {
            if (implant is SelfImplant )
            {
                viewImplant.Add(implant);
            }
        }

        foreach (var implant in _implants.Values)
        {
            if (implant is AutoImplant )
            {
                viewImplant.Add(implant);
            }
        }
        return viewImplant;
    }

    public Implant ViewImplantByID(string ID)
    {

        // RITORNARE OGGETTO
        return _implants[ID];
    }
    public ICollection<Implant> SearchSatusMaintenance()
    {
        List<Implant> maintenance = new();
        foreach (var implant in _implants.Values)
        {
            if (implant.CurrentState == Implant.States.M) { maintenance.Add(implant); }
        }

            return maintenance;



    }

}


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

    public string ViewImplantByID(string ID)
    {

        // RITORNARE OGGETTO
        Implant implant = _implants[ID];
        string result = "ID" + implant.ID;
        result += "Current state:" + implant.CurrentState;


        if (implant is AutoImplant)
        {
            AutoImplant autoImplant = (AutoImplant)implant;
            result += "Counter wash:" + autoImplant.CountWash;
        }
        else
        {
            SelfImplant selfImplant = (SelfImplant)implant;
            result += "Compressor counter:" + selfImplant.CompressorCounter + "\n" + "Washing lance counter:" + selfImplant.WashingCounter + "\n" + "Brush waxing counter:" + selfImplant.BrushWaxingCounter;
        }
        return result;

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


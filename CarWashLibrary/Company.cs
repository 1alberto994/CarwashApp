using System.Xml.XPath;

public class Company
{
    private Dictionary<string, Implant> _implants;

    public string ViewImplant()
    {
        string autoImplant = "";
        string selfImplant = "";
        foreach (var implants in _implants)
        {
            if (implants.Value is SelfImplant)
            {
                selfImplant += implants.Value.ToString();
            }
            else
            {
                autoImplant += implants.Value.ToString();
            }
        }
        return selfImplant + autoImplant;
    }

    public string ViewImplantByID(string ID)
    {
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
    public List<Implant> SearchSatusMaintenance()
    {
        List<Implant> maintenance = new();
        foreach (var implant in _implants.Values)
        {
            if (implant.CurrentState == Implant.States.M) { maintenance.Add(implant); }
        }

            return maintenance;



    }

}
using System.Text;
public class Company
{
    private Dictionary<string,Implant> _implants;
    private Dictionary<string,int> _counters;
    public string ViewImplant()
    {
          StringBuilder result= new StringBuilder();
        result.AppendLine("SelfImplant:");
        foreach ( var implants in _implants)
        {
            if (implants.Value is SelfImplant)
            {
                string code=implants.Key;
                string CurrentState=implants.Value.CurrentState;//tostring?
                int counter= 0;
                if (_counters.ContainsKey(code))
                {
                    counter = _counters[code];
                }
                result.AppendLine($"Code:{code},Type:Self,State:{CurrentState},Counter:{counter}");
            }
        }

        foreach ( var implants in _implants)
        {
            if (implants.Value is AutoImplant)
            {
                string code=implants.Key;
                string CurrentState=implants.Value.CurrentState;//tostring?
                int counter= 0;
                if (_counters.ContainsKey(code))
                {
                    counter = _counters[code];
                }
                result.AppendLine($"Code:{code},Type:Auto,State:{CurrentState},Counter:{counter}");
            }
        }
        return result.ToString();
    }
}
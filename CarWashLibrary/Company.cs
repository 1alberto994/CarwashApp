using System.Text;
public class Company
{
    private Dictionary<string,Implant> _implants;
  
    public string ViewImplant()
    {
        string autoImplant = "";
        string selfImplant="";
        foreach ( var implants in _implants)
        {
            if (implants.Value is SelfImplant)
            {
                selfImplant += implants.Value.ToString();
            }
            else
            {
                autoImplant +=implants.Value.ToString();
            }
        }
        return selfImplant + autoImplant;
    }
}
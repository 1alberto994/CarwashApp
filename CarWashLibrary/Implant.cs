


public class Implant
{
    private enum States { O,M,B};
    private States _currentState;
    private double _costSinglewash;
    private List<Tuple<DateTime,States>>_Logprevstates;
    private string _id;

    public string ID {get=>_id;}
    public States CurrentState
    {
        get
        {
            
        }
    }
    
}
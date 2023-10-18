using System.Diagnostics.Metrics;

public class Implant
{
    private enum States { O, M, G }

    private string _id;

    private States _currentState;

    private List<States> _statesLog = new(); //non so se manterrò una lista

    public string ID { get => _id; }

    public string CurrentState
    {
        get
        {
            switch (_currentState)
            {
                case States.O:
                    return "Operative";
                case States.M:
                    return "In Maintenance";
                case States.G:
                    return "Broken Down";
                default:
                    throw new NotImplementedException("non è possibile che non abbia uno stato, o che lostato non sia uno di quelli indicati sopra");
            }
        }
    }
}
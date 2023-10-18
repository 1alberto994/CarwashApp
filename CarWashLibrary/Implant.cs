public class Implant
{
    private enum States { O, M, B };
    private States _currentState;
    private double _costSinglewash;
    private List<Tuple<DateOnly, States>> _logPrevStates;
    private string _id;

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
                case States.B:
                    return "Broken Down";
                default:
                    throw new NotImplementedException("Invalid states");
            }
        }
    }
    public double CostSingleWash { get => _costSinglewash; }


}
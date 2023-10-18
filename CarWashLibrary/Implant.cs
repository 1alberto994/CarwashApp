public class Implant
{
    public enum States { O, M, B };
    private States _currentState;
    private double _costSinglewash;
    private List<Tuple<DateOnly, States>> _logPrevStates;
    private string _id;

    public string ID { get => _id; }
    public States CurrentState { get => _currentState; }
    public double CostSingleWash { get => _costSinglewash; }


}
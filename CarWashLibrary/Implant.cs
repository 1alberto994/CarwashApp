
public class Implant
{

    public enum States { O, M, B };

    private States _currentState = States.O;

    private double _costSinglewash;

    private List<(DateOnly date, States state)> _logPrevStates = new();

    private string _id;

    private int _howManyTimeBroken = 0;

    public int HowManyTimeBroken { get => _howManyTimeBroken; }

    public string ID { get => _id; }

    public States CurrentState { get => _currentState; }

    public double CostSingleWash { get => _costSinglewash; }

    public bool ChangeState(States state, DateOnly date)
    {
        if(state == _currentState) return false; 
        if (date < DateOnly.FromDateTime(DateTime.Now)) throw new InvalidDateExcepetion($"{date} inserted is in the past!");

        _currentState = state;
        _logPrevStates.Add((date, _currentState));

        if(_currentState != States.B) return true;

        _howManyTimeBroken++;
        return true;
    }

    public Implant(string id, double costSingleWash)
    {
        _id = id;
        _costSinglewash = costSingleWash;
        _logPrevStates.Add((DateOnly.FromDateTime(DateTime.Now), _currentState));
    }
    
}
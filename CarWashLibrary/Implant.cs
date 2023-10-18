using System.Diagnostics.Metrics;

public class Implant
{
<<<<<<< HEAD
    private enum States { O, M, G }

    private string _id;

    private States _currentState;

    private List<States> _statesLog = new(); //non so se manterrò una lista

    public string ID { get => _id; }

=======
    private enum States { O, M, B };
    private States _currentState;
    private double _costSinglewash;
    private List<Tuple<DateOnly, States>> _logPrevStates;
    private string _id;

    public string ID { get => _id; }
>>>>>>> 8bf765c22930da62196959e3513b60e60dad157d
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
<<<<<<< HEAD
                case States.G:
                    return "Broken Down";
                default:
                    throw new NotImplementedException("non è possibile che non abbia uno stato, o che lostato non sia uno di quelli indicati sopra");
            }
        }
    }
=======
                case States.B:
                    return "Broken Down";
                default:
                    throw new NotImplementedException("Invalid states");
            }
        }
    }
    public double CostSingleWash { get => _costSinglewash; }


>>>>>>> 8bf765c22930da62196959e3513b60e60dad157d
}
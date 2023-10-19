public class InvalidDateExcepetion : Exception
{
    public InvalidDateExcepetion(string msg) : base(msg) { }
}

public class NoImplantsLoaded : Exception
{
    public NoImplantsLoaded(string msg) : base(msg) { }
}
public class AutoImplant : Implant
{
    private int _countWash = 0;

    public event EventHandler<EventArgs> WashDoneEvent;

    protected virtual void RaiseWashDoneEvent(EventArgs e)
    {
        EventHandler<EventArgs> washDone = WashDoneEvent;
        if (washDone != null)
        {
            washDone(this, e);
        }
    }


    public int CountWash { get => _countWash; }

    public void MakeWash()
    {
        _countWash++;
        RaiseWashDoneEvent(EventArgs.Empty);
    }

    public AutoImplant(string id, double washCost) : base(id, washCost) { }

}
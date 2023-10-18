public class AutoImplant : Implant
{
    private int _countWash = 0;
    public int CountWash { get => _countWash; }

    public void MakeWash() { _countWash++; }

    public AutoImplant(string id, double washCost) : base(id, washCost) { }

}
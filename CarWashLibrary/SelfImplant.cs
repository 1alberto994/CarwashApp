public class SelfImplant : Implant
{
    private int _compressorCounter = 0;
    private int _washingCounter = 0;
    private int _brushwaxingCounter = 0;

    public int CompressorCounter { get => _compressorCounter; }
    public int WashingCounter { get => _washingCounter; }
    public int BrushWaxingCounter { get => _brushwaxingCounter; }

    public SelfImplant(string id, double washCost) : base(id, washCost){}
}
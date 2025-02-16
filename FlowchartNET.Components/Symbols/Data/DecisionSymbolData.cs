namespace FlowchartNET.Components.Symbols.Data;

public sealed class DecisionSymbolData : SymbolData
{
    public static double DefaultHeight { get; } = 80;
    public static double DefaultScaleX { get; } = 2.5;

    public override Type ComponentType => typeof(DecisionSymbol);

    public double Width => Height * DefaultScaleX;
    public double Height { get; set; } = DefaultHeight;
    public double ScaleX { get; set; } = DefaultScaleX;
}
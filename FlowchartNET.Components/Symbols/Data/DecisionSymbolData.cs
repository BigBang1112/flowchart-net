namespace FlowchartNET.Components.Symbols.Data;

public sealed class DecisionSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 220;

    public override Type ComponentType => typeof(DecisionSymbol);

    public double Width { get; set; } = DefaultWidth;
}
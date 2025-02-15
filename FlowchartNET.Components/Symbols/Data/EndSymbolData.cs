namespace FlowchartNET.Components.Symbols.Data;

public sealed class EndSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 220;

    public override Type ComponentType => typeof(EndSymbol);

    public double Width { get; set; } = DefaultWidth;
}

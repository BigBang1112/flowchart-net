namespace FlowchartNET.Components.Symbols.Data;

public sealed class IOSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 240;
    public static double DefaultHeight { get; } = 80;

    public override Type ComponentType => typeof(IOSymbol);

    public double Width { get; set; } = DefaultWidth;
}

namespace FlowchartNET.Components.Symbols.Data;

public sealed class IOSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 220;

    public override Type ComponentType => typeof(IOSymbol);

    public double Width { get; set; } = DefaultWidth;
}

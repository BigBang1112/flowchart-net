namespace FlowchartNET.Components.Symbols.Data;

public sealed class StartSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 220;

    public override Type ComponentType => typeof(StartSymbol);

    public double Width { get; set; } = DefaultWidth;
}

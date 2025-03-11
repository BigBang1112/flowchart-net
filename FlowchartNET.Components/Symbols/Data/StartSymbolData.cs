namespace FlowchartNET.Components.Symbols.Data;

public sealed class StartSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 240;
    public static double DefaultHeight { get; } = 80;

    public override Type ComponentType => typeof(StartSymbol);

    public double Width { get; set; } = DefaultWidth;

    public Guid? NextSymbol { get; set; }
}

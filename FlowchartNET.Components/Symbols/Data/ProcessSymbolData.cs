namespace FlowchartNET.Components.Symbols.Data;

public sealed class ProcessSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 220;

    public override Type ComponentType => typeof(ProcessSymbol);

    public double Width { get; set; } = DefaultWidth;
}

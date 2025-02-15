namespace FlowchartNET.Components.Symbols.Data;

public abstract class SymbolData
{
    public abstract Type ComponentType { get; }

    public double X { get; set; }
    public double Y { get; set; }
}

namespace FlowchartNET.Components.Symbols.Data;

public abstract class SymbolData
{
    public abstract Type ComponentType { get; }

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

    public double X { get; set; }
    public double Y { get; set; }
}

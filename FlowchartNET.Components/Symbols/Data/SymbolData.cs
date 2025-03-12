using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Symbols.Data;

[JsonDerivedType(typeof(DecisionSymbolData), "decision")]
[JsonDerivedType(typeof(EndSymbolData), "end")]
[JsonDerivedType(typeof(IOSymbolData), "io")]
[JsonDerivedType(typeof(ProcessSymbolData), "process")]
[JsonDerivedType(typeof(StartSymbolData), "start")]
public abstract class SymbolData
{
    public abstract Type ComponentType { get; }

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

    public double X { get; set; }
    public double Y { get; set; }

    public abstract IEnumerable<Guid> GetConnectedSymbolIds();
    public abstract void RemoveConnection(Guid symbolId);
}

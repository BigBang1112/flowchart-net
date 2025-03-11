using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Symbols.Data;

[JsonDerivedType(typeof(DecisionSymbolData))]
[JsonDerivedType(typeof(EndSymbolData))]
[JsonDerivedType(typeof(IOSymbolData))]
[JsonDerivedType(typeof(ProcessSymbolData))]
[JsonDerivedType(typeof(StartSymbolData))]
public abstract class SymbolData
{
    public abstract Type ComponentType { get; }

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

    public double X { get; set; }
    public double Y { get; set; }
}

using FlowchartNET.Components.Simulation;
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
    public abstract Type EditionComponentType { get; }

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

    public double X { get; set; }
    public double Y { get; set; }

    public string? DisplayName { get; set; }

    public abstract string GetLabel();
    public abstract IEnumerable<Guid> GetConnectedSymbolIds();
    public abstract void RemoveConnection(Guid symbolId);
    public abstract HashSet<Guid> Simulate(SimulationState simulation);
}

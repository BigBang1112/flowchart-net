using FlowchartNET.Components.Simulation;
using FlowchartNET.Components.Symbols.Edition;
using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Symbols.Data;

public sealed class StartSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 240;
    public static double DefaultHeight { get; } = 80;

    [JsonIgnore]
    public override Type ComponentType => typeof(StartSymbol);

    [JsonIgnore]
    public override Type EditionComponentType => typeof(StartSymbolEdition);

    public double Width { get; set; } = DefaultWidth;

    public HashSet<Guid> NextSymbols { get; set; } = [];

    public override string GetLabel() => DisplayName ?? "Start";

    public override IEnumerable<Guid> GetConnectedSymbolIds() => NextSymbols;

    public override void RemoveConnection(Guid symbolId)
    {
        NextSymbols.Remove(symbolId);
    }

    public override HashSet<Guid> Simulate(SimulationState simulation)
    {
        return NextSymbols;
    }
}

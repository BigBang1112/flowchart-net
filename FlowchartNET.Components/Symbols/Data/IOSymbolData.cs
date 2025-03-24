using FlowchartNET.Components.Simulation;
using FlowchartNET.Components.Symbols.Edition;
using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Symbols.Data;

public sealed class IOSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 240;
    public static double DefaultHeight { get; } = 80;

    [JsonIgnore]
    public override Type ComponentType => typeof(IOSymbol);

    [JsonIgnore]
    public override Type EditionComponentType => typeof(IOSymbolEdition);

    public double Width { get; set; } = DefaultWidth;

    public string? VariableName { get; set; }

    /// <summary>
    /// The string format to output the variable in. If null, the symbol is considered an input symbol.
    /// </summary>
    public string? OutputFormat { get; set; }

    /// <summary>
    /// The value to simulate for this symbol. This value will be modified if the symbol is an output.
    /// </summary>
    public string? SimulationValue { get; set; }

    public HashSet<Guid> NextSymbols { get; set; } = [];

    public override string GetLabel() => DisplayName ?? VariableName ?? (OutputFormat is null ? "Input" : "Output");

    public override IEnumerable<Guid> GetConnectedSymbolIds() => NextSymbols;

    public override void RemoveConnection(Guid symbolId)
    {
        NextSymbols.Remove(symbolId);
    }

    public override HashSet<Guid> Simulate(SimulationState simulation)
    {
        if (OutputFormat is null)
        {
            var variableName = VariableName ?? "Input";

            if (double.TryParse(SimulationValue, out var value))
            {
                simulation.Variables[variableName] = value;
            }
            else
            {
                simulation.Variables[variableName] = SimulationValue;
            }
        }
        else
        {
            var variableName = VariableName ?? "Output";

            SimulationValue = simulation.Variables[variableName]?.ToString();
        }

        return NextSymbols;
    }
}

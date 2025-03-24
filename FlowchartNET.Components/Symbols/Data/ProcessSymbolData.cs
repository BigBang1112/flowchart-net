using FlowchartNET.Components.Simulation;
using FlowchartNET.Components.Symbols.Edition;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FlowchartNET.Components.Symbols.Data;

public sealed partial class ProcessSymbolData : SymbolData
{
    [GeneratedRegex(@"^(([a-zA-Z_]+)\((.*)\))")]
    private static partial Regex FunctionCallRegex();

    public static double DefaultWidth { get; } = 240;
    public static double DefaultHeight { get; } = 80;

    [JsonIgnore]
    public override Type ComponentType => typeof(ProcessSymbol);

    [JsonIgnore]
    public override Type EditionComponentType => typeof(ProcessSymbolEdition);

    public double Width { get; set; } = DefaultWidth;

    /// <summary>
    /// Variable name to store the result of the process.
    /// </summary>
    public string? VariableName { get; set; }

    /// <summary>
    /// Process string that Regex will resolve.
    /// </summary>
    public string? Process { get; set; }

    public HashSet<Guid> NextSymbols { get; set; } = [];

    public bool IsBottomToTop { get; set; }

    public override string GetLabel() => DisplayName ?? (VariableName is null ? Process : $"{VariableName} = {Process}") ?? "Process";

    public override IEnumerable<Guid> GetConnectedSymbolIds() => NextSymbols;

    public override void RemoveConnection(Guid symbolId)
    {
        NextSymbols.Remove(symbolId);
    }

    public override HashSet<Guid> Simulate(SimulationState simulation)
    {
        if (string.IsNullOrEmpty(Process))
        {
            return NextSymbols;
        }

        var matchProcess = FunctionCallRegex().Match(Process);

        if (matchProcess.Success)
        {
            simulation.CalledFunctions.Add(matchProcess.Groups[1].Value);

            if (VariableName is not null)
            {
                simulation.Variables[VariableName] = null;
            }
            
            return NextSymbols;
        }

        if (VariableName is not null)
        {
            // in case the process has math instead of a function call:
            var expression = new NCalc.Expression(Process)
            {
                Parameters = simulation.Variables
            };

            simulation.Variables[VariableName] = expression.Evaluate();
        }

        return NextSymbols;
    }
}

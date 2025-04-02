using FlowchartNET.Components.State;
using FlowchartNET.Components.Symbols.Edition;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FlowchartNET.Components.Symbols.Data;

public sealed partial class DecisionSymbolData : SymbolData
{
    [GeneratedRegex(@"^([a-zA-Z_]+)\s*(!=|<=|<|>=|>|==|=)\s*([a-zA-Z_]+)")]
    private static partial Regex ConditionRegex();

    public static double DefaultHeight { get; } = 100;
    public static double DefaultScaleX { get; } = 2.5;

    [JsonIgnore]
    public override Type ComponentType => typeof(DecisionSymbol);

    [JsonIgnore]
    public override Type EditionComponentType => typeof(DecisionSymbolEdition);

    public double Width => Height * DefaultScaleX;
    public double Height { get; set; } = DefaultHeight;
    public double ScaleX { get; set; } = DefaultScaleX;

    /// <summary>
    /// Condition string that Regex will resolve.
    /// </summary>
    public string? Condition { get; set; }

    public HashSet<Guid> TrueSymbols { get; set; } = [];
    public HashSet<Guid> FalseSymbols { get; set; } = [];

    public override string GetLabel() => DisplayName ?? Condition ?? "Decision";

    public override IEnumerable<Guid> GetConnectedSymbolIds()
    {
        foreach (var trueBranch in TrueSymbols)
        {
            yield return trueBranch;
        }

        foreach (var falseBranch in FalseSymbols)
        {
            yield return falseBranch;
        }
    }

    public override void RemoveConnection(Guid symbolId)
    {
        TrueSymbols.Remove(symbolId);
        FalseSymbols.Remove(symbolId);
    }

    public override HashSet<Guid> Simulate(SimulationState simulation)
    {
        if (string.IsNullOrEmpty(Condition))
        {
            throw new Exception("Condition is required for Decision.");
        }

        var matchCondition = ConditionRegex().Match(Condition);

        if (!matchCondition.Success)
        {
            throw new Exception("Invalid condition format.");
        }

        var expression = new NCalc.Expression(Condition)
        {
            Parameters = simulation.Variables
        };

        return expression.Evaluate() is true ? TrueSymbols : FalseSymbols;
    }
}
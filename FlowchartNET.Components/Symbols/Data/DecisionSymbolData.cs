using FlowchartNET.Components.Symbols.Edition;
using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Symbols.Data;

public sealed class DecisionSymbolData : SymbolData
{
    public static double DefaultHeight { get; } = 80;
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

    public HashSet<Guid> TrueBranches { get; set; } = [];
    public HashSet<Guid> FalseBranches { get; set; } = [];

    public override string GetLabel() => DisplayName ?? Condition ?? "Decision";

    public override IEnumerable<Guid> GetConnectedSymbolIds()
    {
        foreach (var trueBranch in TrueBranches)
        {
            yield return trueBranch;
        }

        foreach (var falseBranch in FalseBranches)
        {
            yield return falseBranch;
        }
    }

    public override void RemoveConnection(Guid symbolId)
    {
        TrueBranches.Remove(symbolId);
        FalseBranches.Remove(symbolId);
    }
}
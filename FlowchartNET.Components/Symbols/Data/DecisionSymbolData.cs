namespace FlowchartNET.Components.Symbols.Data;

public sealed class DecisionSymbolData : SymbolData
{
    public static double DefaultHeight { get; } = 80;
    public static double DefaultScaleX { get; } = 2.5;

    public override Type ComponentType => typeof(DecisionSymbol);

    public double Width => Height * DefaultScaleX;
    public double Height { get; set; } = DefaultHeight;
    public double ScaleX { get; set; } = DefaultScaleX;

    /// <summary>
    /// Condition string that Regex will resolve.
    /// </summary>
    public string? Condition { get; set; }

    public string? DisplayName { get; set; }

    public Guid? TrueBranch { get; set; }
    public Guid? FalseBranch { get; set; }
}
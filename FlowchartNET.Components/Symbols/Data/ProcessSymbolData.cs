namespace FlowchartNET.Components.Symbols.Data;

public sealed class ProcessSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 240;
    public static double DefaultHeight { get; } = 80;

    public override Type ComponentType => typeof(ProcessSymbol);

    public double Width { get; set; } = DefaultWidth;

    /// <summary>
    /// Variable name to store the result of the process.
    /// </summary>
    public string? VariableName { get; set; }

    /// <summary>
    /// Process string that Regex will resolve.
    /// </summary>
    public string? Process { get; set; }

    public Guid? NextSymbol { get; set; }
}

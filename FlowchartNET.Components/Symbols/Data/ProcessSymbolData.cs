using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Symbols.Data;

public sealed class ProcessSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 240;
    public static double DefaultHeight { get; } = 80;

    [JsonIgnore]
    public override Type ComponentType => typeof(ProcessSymbol);

    public double Width { get; set; } = DefaultWidth;

    /// <summary>
    /// Variable name to store the result of the process.
    /// </summary>
    public string? VariableName { get; set; }

    public string? DisplayName { get; set; }

    /// <summary>
    /// Process string that Regex will resolve.
    /// </summary>
    public string? Process { get; set; }

    public Guid? NextSymbol { get; set; }

    public override IEnumerable<Guid> GetConnectedSymbolIds()
    {
        if (NextSymbol.HasValue)
        {
            yield return NextSymbol.Value;
        }
    }

    public override void RemoveConnection(Guid symbolId)
    {
        if (NextSymbol == symbolId)
        {
            NextSymbol = null;
        }
    }
}

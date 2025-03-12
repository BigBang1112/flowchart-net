using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Symbols.Data;

public sealed class IOSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 240;
    public static double DefaultHeight { get; } = 80;

    [JsonIgnore]
    public override Type ComponentType => typeof(IOSymbol);

    public double Width { get; set; } = DefaultWidth;

    public string? VariableName { get; set; }

    public string? DisplayName { get; set; }

    /// <summary>
    /// The string format to output the variable in. If null, the symbol is considered an input symbol.
    /// </summary>
    public string? OutputFormat { get; set; }

    public HashSet<Guid> NextSymbols { get; set; } = [];

    public override IEnumerable<Guid> GetConnectedSymbolIds() => NextSymbols;

    public override void RemoveConnection(Guid symbolId)
    {
        NextSymbols.Remove(symbolId);
    }
}

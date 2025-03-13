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

    public HashSet<Guid> NextSymbols { get; set; } = [];

    public override string GetLabel() => DisplayName ?? VariableName ?? (OutputFormat is null ? "Input" : "Output");

    public override IEnumerable<Guid> GetConnectedSymbolIds() => NextSymbols;

    public override void RemoveConnection(Guid symbolId)
    {
        NextSymbols.Remove(symbolId);
    }
}

using FlowchartNET.Components.Symbols.Edition;
using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Symbols.Data;

public sealed class ProcessSymbolData : SymbolData
{
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

    public override string GetLabel() => DisplayName ?? (VariableName is null ? Process : $"{VariableName} = {Process}") ?? "Process";

    public override IEnumerable<Guid> GetConnectedSymbolIds() => NextSymbols;

    public override void RemoveConnection(Guid symbolId)
    {
        NextSymbols.Remove(symbolId);
    }
}

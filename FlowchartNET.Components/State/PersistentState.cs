using FlowchartNET.Components.Symbols.Data;

namespace FlowchartNET.Components.State;

public sealed class PersistentState
{
    public int Version { get; set; }
    public string? MenuSelectedSymbolId { get; set; }
    public Guid? SelectedSymbolId { get; set; }
    public bool IsPropertiesOpen { get; set; }
    public double Zoom { get; set; } = 0.75;
    public Language Language { get; set; } = Language.CSharp;

    public List<SymbolData> Symbols { get; set; } = [];
}

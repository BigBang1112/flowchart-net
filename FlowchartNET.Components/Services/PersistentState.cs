using FlowchartNET.Components.Symbols.Data;

namespace FlowchartNET.Components.Services;

public sealed class PersistentState
{
    public string? MenuSelectedSymbolId { get; set; }
    public Guid? SelectedSymbolId { get; set; }
    public bool IsPropertiesOpen { get; set; }
    public double Zoom { get; set; } = 0.75;

    public List<SymbolData> Symbols { get; set; } = [];
}

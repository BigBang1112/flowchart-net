using FlowchartNET.Components.Symbols.Data;

namespace FlowchartNET.Components.Services;

public sealed class AppState
{
    public string? SelectedSymbolId { get; set; }
    public List<SymbolData> Symbols { get; set; } = [];
}

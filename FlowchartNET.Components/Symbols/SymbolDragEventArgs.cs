using Microsoft.AspNetCore.Components.Web;

namespace FlowchartNET.Components.Symbols;

public sealed record SymbolDragEventArgs(IDraggable Draggable, MouseEventArgs Mouse);

using FlowchartNET.Components.Symbols;

namespace FlowchartNET.Components.Events;

public sealed record SymbolDragEventArgs(IDraggable Draggable, double ClientX, double ClientY);

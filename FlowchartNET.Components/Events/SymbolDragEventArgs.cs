using FlowchartNET.Components.Symbols;

namespace FlowchartNET.Components.Events;

public sealed record SymbolDragEventArgs(ISymbol Draggable, double ClientX, double ClientY);

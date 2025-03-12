using FlowchartNET.Components.Symbols;
using Microsoft.AspNetCore.Components;

namespace FlowchartNET.Components.Events;

public sealed record PointClickEventArgs(IDraggable Symbol, ElementReference Element, string Socket, Action<LineConnection>? Connector);

using FlowchartNET.Components.Symbols;
using Microsoft.AspNetCore.Components;

namespace FlowchartNET.Components.Events;

public sealed record PointClickEventArgs(
    IDraggable Symbol, 
    ElementReference Element, 
    string Socket, 
    Func<bool> ConnectFrom, 
    Func<bool> ConnectTo, 
    Action<LineConnection>? Connection);

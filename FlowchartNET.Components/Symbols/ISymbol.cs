using Microsoft.AspNetCore.Components;

namespace FlowchartNET.Components.Symbols;

public interface ISymbol
{
    public Guid Id { get; }
    public bool IsDragging { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public ElementReference Shape { get; }
}

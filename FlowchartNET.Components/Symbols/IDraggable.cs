namespace FlowchartNET.Components.Symbols;

public interface IDraggable
{
    public bool IsDragging { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
}

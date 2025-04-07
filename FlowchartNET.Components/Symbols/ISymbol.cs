using FlowchartNET.Components.Symbols.Data;
using Microsoft.AspNetCore.Components;

namespace FlowchartNET.Components.Symbols;

public interface ISymbol
{
    Guid Id => Data.Id;
    double X { get => Data.X; set => Data.X = value; }
    double Y { get => Data.Y; set => Data.Y = value; }
    bool IsDragging { get; set; }
    SymbolData Data { get; }
    ElementReference Shape { get; }
    string? GetSocketIn();
    string? GetSocketOut(Guid nextSymbolId);
}

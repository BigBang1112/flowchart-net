using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Symbols.Data;

public sealed class EndSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 240;
    public static double DefaultHeight { get; } = 80;

    [JsonIgnore]
    public override Type ComponentType => typeof(EndSymbol);

    public double Width { get; set; } = DefaultWidth;

    public override IEnumerable<Guid> GetConnectedSymbolIds() => [];

    public override void RemoveConnection(Guid symbolId) { }
}

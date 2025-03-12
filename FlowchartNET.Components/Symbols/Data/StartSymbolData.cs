using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Symbols.Data;

public sealed class StartSymbolData : SymbolData
{
    public static double DefaultWidth { get; } = 240;
    public static double DefaultHeight { get; } = 80;

    [JsonIgnore]
    public override Type ComponentType => typeof(StartSymbol);

    public double Width { get; set; } = DefaultWidth;

    public Guid? NextSymbol { get; set; }

    public override IEnumerable<Guid> GetConnectedSymbolIds()
    {
        if (NextSymbol.HasValue)
        {
            yield return NextSymbol.Value;
        }
    }

    public override void RemoveConnection(Guid symbolId)
    {
        if (NextSymbol == symbolId)
        {
            NextSymbol = null;
        }
    }
}

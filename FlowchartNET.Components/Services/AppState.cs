using Blazored.LocalStorage;
using FlowchartNET.Components.Simulation;
using FlowchartNET.Components.Symbols.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FlowchartNET.Components.Services;

public sealed class AppState
{
    private readonly IServiceProvider serviceProvider;

    public string? MenuSelectedSymbolId { get; set; }
    public Guid? SelectedSymbolId { get; set; }
    public bool IsPropertiesOpen { get; set; }
    public double Zoom { get; set; } = 0.75;

    public List<SymbolData> Symbols { get; set; } = [];

    public SimulationState Simulation { get; set; } = new();

    public AppState(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task PersistAsync(CancellationToken cancellationToken = default)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var localStorage = scope.ServiceProvider.GetRequiredService<ILocalStorageService>();
        await localStorage.SetItemAsync("state", this, cancellationToken);
    }

    public SymbolData? GetSelectedSymbol()
    {
        return Symbols.FirstOrDefault(s => s.Id == SelectedSymbolId);
    }

    public IEnumerable<IOSymbolData> GetInputVariables(StartSymbolData startSymbol)
    {
        return RecurseConnectedIOSymbols(startSymbol, Symbols)
            .Where(s => s.OutputFormat is null);
    }

    private static IEnumerable<IOSymbolData> RecurseConnectedIOSymbols(SymbolData symbol, List<SymbolData> symbols)
    {        
        foreach (var connectedSymbolId in symbol.GetConnectedSymbolIds())
        {
            var connectedSymbol = symbols.FirstOrDefault(s => s.Id == connectedSymbolId);

            if (connectedSymbol is null)
            {
                continue;
            }

            if (connectedSymbol is IOSymbolData ioSymbol)
            {
                yield return ioSymbol;
            }

            foreach (var s in RecurseConnectedIOSymbols(connectedSymbol, symbols))
            {
                yield return s;
            }
        }
    }
}

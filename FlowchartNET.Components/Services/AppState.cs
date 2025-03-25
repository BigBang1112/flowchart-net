using Blazored.LocalStorage;
using FlowchartNET.Components.Simulation;
using FlowchartNET.Components.Symbols.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlowchartNET.Components.Services;

public sealed class AppState
{
    private readonly IServiceProvider serviceProvider;

    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public PersistentState Persistent { get; set; } = new PersistentState();

    public SimulationState? Simulation { get; set; }

    public bool IsCodeGenerationOpen { get; set; }

    public AppState(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public async Task PersistAsync(CancellationToken cancellationToken = default)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var localStorage = scope.ServiceProvider.GetRequiredService<ILocalStorageService>();
        await localStorage.SetItemAsync("persistent", Persistent, cancellationToken);
    }

    public async Task LoadAsync(CancellationToken cancellationToken = default)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var localStorage = scope.ServiceProvider.GetRequiredService<ILocalStorageService>();
        Persistent = await localStorage.GetItemAsync<PersistentState>("persistent", cancellationToken) ?? new PersistentState();
    }

    public async Task SaveAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        await JsonSerializer.SerializeAsync(stream, Persistent, jsonSerializerOptions, cancellationToken);
    }

    public async Task LoadAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        Persistent = await JsonSerializer.DeserializeAsync<PersistentState>(stream, jsonSerializerOptions, cancellationToken) ?? new PersistentState();
    }

    public SymbolData? GetSelectedSymbol()
    {
        return Persistent.Symbols.FirstOrDefault(s => s.Id == Persistent.SelectedSymbolId);
    }

    public IEnumerable<IOSymbolData> GetInputVariables(StartSymbolData startSymbol)
    {
        var alreadyVisited = new HashSet<Guid>();

        return RecurseConnectedIOSymbols(startSymbol, Persistent.Symbols, alreadyVisited)
            .Where(s => s.OutputFormat is null);
    }

    private static IEnumerable<IOSymbolData> RecurseConnectedIOSymbols(SymbolData symbol, List<SymbolData> symbols, HashSet<Guid> alreadyVisited)
    {
        foreach (var connectedSymbolId in symbol.GetConnectedSymbolIds())
        {
            var connectedSymbol = symbols.FirstOrDefault(s => s.Id == connectedSymbolId);

            if (connectedSymbol is null)
            {
                continue;
            }

            if (!alreadyVisited.Add(connectedSymbol.Id))
            {
                continue;
            }

            if (connectedSymbol is IOSymbolData ioSymbol)
            {
                yield return ioSymbol;
            }

            foreach (var s in RecurseConnectedIOSymbols(connectedSymbol, symbols, alreadyVisited))
            {
                yield return s;
            }
        }
    }
}

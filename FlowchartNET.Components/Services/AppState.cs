using Blazored.LocalStorage;
using FlowchartNET.Components.Symbols.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FlowchartNET.Components.Services;

public sealed class AppState
{
    private readonly IServiceProvider serviceProvider;

    public string? MenuSelectedSymbolId { get; set; }
    public Guid? SelectedSymbolId { get; set; }
    public bool IsPropertiesOpen { get; set; }

    public List<SymbolData> Symbols { get; set; } = [];

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
}

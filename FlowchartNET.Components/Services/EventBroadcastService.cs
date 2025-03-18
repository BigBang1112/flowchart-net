﻿using FlowchartNET.Components.Symbols.Data;

namespace FlowchartNET.Components.Services;

internal sealed class EventBroadcastService
{
    public event Action? MenuUpdate;
    public event Action? WorkspaceUpdate;
    public event Action? PropertiesUpdate;
    public event Func<SymbolData, Task>? SymbolDelete;
    public event Action<StartSymbolData>? SimulationStart;

    public void UpdateMenu()
    {
        MenuUpdate?.Invoke();
    }

    public void UpdateWorkspace()
    {
        WorkspaceUpdate?.Invoke();
    }

    public void UpdateProperties()
    {
        PropertiesUpdate?.Invoke();
    }

    public async Task DeleteSymbolAsync(SymbolData symbol)
    {
        if (SymbolDelete is not null)
        {
            await SymbolDelete.Invoke(symbol);
        }
    }

    public void StartSimulation(StartSymbolData startSymbol)
    {
        SimulationStart?.Invoke(startSymbol);
    }
}

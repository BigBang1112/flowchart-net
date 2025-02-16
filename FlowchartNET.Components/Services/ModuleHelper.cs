using Microsoft.JSInterop;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace FlowchartNET.Components.Services;

internal sealed class ModuleHelper
{
    private readonly IJSRuntime js;

    public ModuleHelper(IJSRuntime js)
    {
        this.js = js;
    }

    [SupportedOSPlatform("browser")]
    public async Task<IJSObjectReference> ImportAsync(string moduleName, string? moduleType = null, CancellationToken cancellationToken = default)
    {
        var module = await js.InvokeAsync<IJSObjectReference>("import", cancellationToken, $"./_content/FlowchartNET.Components/{moduleName}.razor.js");

        if (moduleType is not null)
        {
            await JSHost.ImportAsync(moduleType, $"../_content/FlowchartNET.Components/{moduleName}.razor.js", cancellationToken);
        }

        return module;
    }
}

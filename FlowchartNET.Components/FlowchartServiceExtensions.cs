using Blazored.LocalStorage;
using FlowchartNET.Components.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace FlowchartNET.Components;

public static class FlowchartServiceExtensions
{
    public static IServiceCollection AddFlowchartNET(this IServiceCollection services)
    {
        services.AddBlazoredLocalStorage(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        services.AddSingleton<AppState>();
        services.AddSingleton<EventBroadcastService>();
        services.AddTransient<ModuleHelper>();

        return services;
    }
}

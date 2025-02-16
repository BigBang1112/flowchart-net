using Microsoft.Extensions.DependencyInjection;

namespace FlowchartNET.Components;

public static class FlowchartServiceExtensions
{
    public static IServiceCollection AddFlowchartNET(this IServiceCollection services)
    {
        services.AddSingleton<AppState>();
        services.AddSingleton<EventBroadcastService>();
        return services;
    }
}

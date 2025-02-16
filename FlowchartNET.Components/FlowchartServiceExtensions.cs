using Microsoft.Extensions.DependencyInjection;

namespace FlowchartNET.Components;

public static class FlowchartServiceExtensions
{
    public static IServiceCollection AddFlowchartNET(this IServiceCollection services)
    {
        services.AddSingleton<AppState>();
        return services;
    }
}

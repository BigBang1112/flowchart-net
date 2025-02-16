namespace FlowchartNET.Components.Services;

internal sealed class EventBroadcastService
{
    public event Action? MenuUpdate;

    public void UpdateMenu()
    {
        MenuUpdate?.Invoke();
    }
}

namespace FlowchartNET.Components;

internal sealed class EventBroadcastService
{
    public event Action? MenuUpdate;

    public void UpdateMenu()
    {
        MenuUpdate?.Invoke();
    }
}

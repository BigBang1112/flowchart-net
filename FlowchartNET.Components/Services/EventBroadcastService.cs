namespace FlowchartNET.Components.Services;

internal sealed class EventBroadcastService
{
    public event Action? MenuUpdate;
    public event Action? WorkspaceUpdate;
    public event Action? PropertiesUpdate;

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
}

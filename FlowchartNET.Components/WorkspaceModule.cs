using System.Runtime.InteropServices.JavaScript;

namespace FlowchartNET.Components;

// https://github.com/dotnet/aspnetcore/issues/52947
internal partial class WorkspaceModule
{
    [JSImport("getMouseX", nameof(WorkspaceModule))]
    public static partial double GetMouseX(double clientX);

    [JSImport("getMouseY", nameof(WorkspaceModule))]
    public static partial double GetMouseY(double clientY);
}

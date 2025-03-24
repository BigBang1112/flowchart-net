namespace FlowchartNET.Components.Simulation;

public sealed class SimulationState
{
    public Guid StartSymbolId { get; set; }
    public HashSet<Guid> CurrentSymbolIds { get; set; } = [];
    public Dictionary<Guid, HashSet<Guid>> NextSymbolIds { get; set; } = [];
    public HashSet<Guid> UsedSymbolIds { get; set; } = [];
    public int Step { get; set; }
    public TimeSpan StepTime { get; set; } = TimeSpan.FromSeconds(1);
    public TimeSpan IdleTime { get; set; } = TimeSpan.FromSeconds(1);
    public DateTimeOffset StartedAt { get; set; } = DateTimeOffset.Now;
    public bool IsFinished { get; set; }

    public Dictionary<string, object?> Variables { get; set; } = [];
    public List<string> CalledFunctions { get; set; } = [];
}

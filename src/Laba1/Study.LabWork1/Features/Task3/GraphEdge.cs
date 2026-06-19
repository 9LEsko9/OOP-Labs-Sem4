namespace Study.LabWork1.Features.Task3;

/// <summary>
/// Класс выполняющий роль ребра графа
/// </summary>
public class GraphEdge(GraphNode outgoing, GraphNode destination)
{
    /// <summary>
    /// Узел из которого исходит ребро
    /// </summary>
    public GraphNode Outgoing { get; } = outgoing;

    /// <summary>
    /// Узел куда приходит ребро
    /// </summary>
    public GraphNode Destination { get; } = destination;
}

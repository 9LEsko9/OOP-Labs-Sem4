
namespace Study.LabWork1.Features.Task3;


/// <summary>
/// Класс графа
/// </summary>
public class Graph
{
    private readonly List<GraphNode> _nodes = [];
    private readonly List<GraphEdge> _edges = [];

    public IReadOnlyList<GraphNode> Nodes { get => _nodes.AsReadOnly(); }
    public IReadOnlyList<GraphEdge> Edges { get => _edges.AsReadOnly(); }


    /// <summary>
    /// Метод добавления узлов в граф
    /// </summary>
    /// <param name="destinationNode"></param>
    /// <param name="outGoingNode"></param>
    public void AddNode(GraphNode destinationNode, GraphNode? outGoingNode = null)
    {
        if (outGoingNode == null)
        {
            _nodes.Add(destinationNode);
            return;
        }

        var edge = new GraphEdge(outGoingNode, destinationNode);

        if (!_nodes.Contains(outGoingNode))
        {
            _nodes.Add(outGoingNode);
        }

        if (!_nodes.Contains(destinationNode))
        {
            _nodes.Add(destinationNode);
        }

        if (!_edges.Contains(edge))
        {
            _edges.Add(edge);
        }

        outGoingNode.AddEdge(edge);
    }

}

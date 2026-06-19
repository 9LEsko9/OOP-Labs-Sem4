namespace Study.LabWork1.Features.Task3;

/// <summary>
/// Класс представляющий собой узел графа
/// </summary>
public class GraphNode(int weight)
{
    private readonly List<GraphEdge> _outGoingEdges = [];

    /// <summary>ß
    /// Вес узла графа
    /// </summary>
    public int Weight { get; private set; } = weight;

    /// <summary>
    /// Метод привязки ребра к узлу графа
    /// </summary>
    /// <param name="edge"></param>
    public void AddEdge(GraphEdge edge) => _outGoingEdges.Add(edge);

    /// <summary>
    /// Метод отвязки ребра от узла
    /// </summary>
    /// <param name="edge"></param>
    public void RemoveEdge(GraphEdge edge) => _outGoingEdges.Remove(edge);

    /// <summary>
    /// Метод получения ребер графа
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<GraphEdge> GetAllEdges() => _outGoingEdges.AsReadOnly();


    /// <summary>
    /// Функция вывода узла и всех его потомков
    /// </summary>
    public void Print()
    {
        Console.Write($" (ВЕС: {Weight} | КД: {_outGoingEdges.Count} ) ");

        foreach (var edge in _outGoingEdges)
        {
            edge.Destination.Print();
        }
    }
}

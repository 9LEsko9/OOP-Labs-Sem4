using Study.LabWork1.Features.Task3;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1() => throw new NotImplementedException();

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3()
    {
        Graph graph = new Graph();
        GraphNode n1 = new GraphNode(10), n2 = new GraphNode(20),
            n3 = new GraphNode(30), n4 = new GraphNode(40),
            n5 = new GraphNode(50), n6 = new GraphNode(60);

        graph.AddNode(n1);
        graph.AddNode(n2, n1);
        graph.AddNode(n3, n1);

        graph.AddNode(n4, n2);
        graph.AddNode(n5, n2);
        graph.AddNode(n6, n2);

        graph.Nodes.First().Print();
    }
}

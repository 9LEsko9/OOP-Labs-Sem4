using NUnit.Framework;
using Study.LabWork1.Features.Task3;

namespace Study.LabWork1.UnitTests.Features.Task3;

[TestFixture]
public class GraphTests
{
    private Graph _graph;

    [SetUp]
    public void SetUp()
    {
        _graph = new Graph();
    }

    [Test]
    public void Constructor_InitializesEmptyGraph()
    {
        Assert.That(_graph.Nodes.Count, Is.EqualTo(0));
        Assert.That(_graph.Edges.Count, Is.EqualTo(0));
    }

    [Test]
    public void AddNode_SingleNode_AddsToGraph()
    {
        var node = new GraphNode(10);

        _graph.AddNode(node);

        Assert.That(_graph.Nodes.Count, Is.EqualTo(1));
        Assert.That(_graph.Nodes[0], Is.EqualTo(node));
    }

    [Test]
    public void AddNode_WithOutgoing_CreatesEdge()
    {
        var node1 = new GraphNode(10);
        var node2 = new GraphNode(20);

        _graph.AddNode(node1);
        _graph.AddNode(node2, node1);

        Assert.That(_graph.Nodes.Count, Is.EqualTo(2));
        Assert.That(_graph.Edges.Count, Is.EqualTo(1));
        Assert.That(_graph.Edges[0].Outgoing, Is.EqualTo(node1));
        Assert.That(_graph.Edges[0].Destination, Is.EqualTo(node2));
    }

    [Test]
    public void AddNode_ComplexGraph_StructureIsCorrect()
    {
        var n1 = new GraphNode(10);
        var n2 = new GraphNode(20);
        var n3 = new GraphNode(30);
        var n4 = new GraphNode(40);

        _graph.AddNode(n1);
        _graph.AddNode(n2, n1);
        _graph.AddNode(n3, n1);
        _graph.AddNode(n4, n2);

        Assert.That(_graph.Nodes.Count, Is.EqualTo(4));
        Assert.That(_graph.Edges.Count, Is.EqualTo(3));

        var n1Edges = n1.GetAllEdges();
        Assert.That(n1Edges.Count, Is.EqualTo(2));
    }

    [Test]
    public void AddNode_CreatesEdgeAndRegistersWithNode()
    {
        var parent = new GraphNode(10);
        var child = new GraphNode(20);

        _graph.AddNode(parent);
        _graph.AddNode(child, parent);

        var parentEdges = parent.GetAllEdges();
        Assert.That(parentEdges.Count, Is.EqualTo(1));
        Assert.That(parentEdges[0].Destination, Is.EqualTo(child));
    }

    [Test]
    public void AddNode_MultipleChildren_AllRegistered()
    {
        var parent = new GraphNode(10);
        var child1 = new GraphNode(20);
        var child2 = new GraphNode(30);
        var child3 = new GraphNode(40);

        _graph.AddNode(parent);
        _graph.AddNode(child1, parent);
        _graph.AddNode(child2, parent);
        _graph.AddNode(child3, parent);

        var parentEdges = parent.GetAllEdges();
        Assert.That(parentEdges.Count, Is.EqualTo(3));
    }

    [Test]
    public void AddNode_TreeStructure_PrintsCorrectly()
    {
        var n1 = new GraphNode(10);
        var n2 = new GraphNode(20);
        var n3 = new GraphNode(30);
        var n4 = new GraphNode(40);

        _graph.AddNode(n1);
        _graph.AddNode(n2, n1);
        _graph.AddNode(n3, n1);
        _graph.AddNode(n4, n2);

        var output = new StringWriter();
        Console.SetOut(output);

        _graph.Nodes.First().Print();

        var result = output.ToString();
        Assert.That(result, Does.Contain("ВЕС: 10"));
        Assert.That(result, Does.Contain("ВЕС: 20"));
        Assert.That(result, Does.Contain("ВЕС: 30"));
        Assert.That(result, Does.Contain("ВЕС: 40"));
    }
}

using NUnit.Framework;
using Study.LabWork1.Features.Task3;

namespace Study.LabWork1.UnitTests.Features.Task3;

[TestFixture]
public class GraphNodeTests
{
    private GraphNode _node;

    [SetUp]
    public void SetUp()
    {
        _node = new GraphNode(10);
    }

    [Test]
    public void Constructor_SetsWeightCorrectly()
    {
        Assert.That(_node.Weight, Is.EqualTo(10));
    }

    [Test]
    public void AddEdge_AddsEdgeToNode()
    {
        var destination = new GraphNode(20);
        var edge = new GraphEdge(_node, destination);

        _node.AddEdge(edge);

        var edges = _node.GetAllEdges();
        Assert.That(edges.Count, Is.EqualTo(1));
        Assert.That(edges[0], Is.EqualTo(edge));
    }

    [Test]
    public void AddEdge_MultipleEdges_AllAdded()
    {
        var dest1 = new GraphNode(20);
        var dest2 = new GraphNode(30);
        var edge1 = new GraphEdge(_node, dest1);
        var edge2 = new GraphEdge(_node, dest2);

        _node.AddEdge(edge1);
        _node.AddEdge(edge2);

        var edges = _node.GetAllEdges();
        Assert.That(edges.Count, Is.EqualTo(2));
    }

    [Test]
    public void RemoveEdge_RemovesEdgeFromNode()
    {
        var destination = new GraphNode(20);
        var edge = new GraphEdge(_node, destination);
        _node.AddEdge(edge);

        _node.RemoveEdge(edge);

        var edges = _node.GetAllEdges();
        Assert.That(edges.Count, Is.EqualTo(0));
    }

    [Test]
    public void RemoveEdge_NonExistentEdge_DoesNotThrow()
    {
        var destination = new GraphNode(20);
        var edge = new GraphEdge(_node, destination);

        Assert.DoesNotThrow(() => _node.RemoveEdge(edge));
    }

    [Test]
    public void Print_WithNoEdges_PrintsNodeInfo()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        _node.Print();

        var result = output.ToString();
        Assert.That(result, Does.Contain("ВЕС: 10"));
        Assert.That(result, Does.Contain("КД: 0"));
    }

    [Test]
    public void Print_WithEdges_PrintsNodeAndChildren()
    {
        var child = new GraphNode(20);
        var edge = new GraphEdge(_node, child);
        _node.AddEdge(edge);

        var output = new StringWriter();
        Console.SetOut(output);

        _node.Print();

        var result = output.ToString();
        Assert.That(result, Does.Contain("ВЕС: 10"));
        Assert.That(result, Does.Contain("КД: 1"));
        Assert.That(result, Does.Contain("ВЕС: 20"));
    }
}

[TestFixture]
public class GraphEdgeTests
{
    [Test]
    public void Constructor_SetsOutgoingAndDestination()
    {
        var outgoing = new GraphNode(10);
        var destination = new GraphNode(20);

        var edge = new GraphEdge(outgoing, destination);

        Assert.That(edge.Outgoing, Is.EqualTo(outgoing));
        Assert.That(edge.Destination, Is.EqualTo(destination));
    }

    [Test]
    public void Properties_AreReadOnly()
    {
        var outgoing = new GraphNode(10);
        var destination = new GraphNode(20);
        var edge = new GraphEdge(outgoing, destination);

        var outgoingNode = edge.Outgoing;
        var destinationNode = edge.Destination;

        Assert.That(outgoingNode.Weight, Is.EqualTo(10));
        Assert.That(destinationNode.Weight, Is.EqualTo(20));
    }
}

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

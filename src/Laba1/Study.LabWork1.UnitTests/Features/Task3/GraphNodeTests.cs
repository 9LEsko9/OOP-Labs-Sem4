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

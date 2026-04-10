using NUnit.Framework;
using Study.LabWork1.Features.Task3;

namespace Study.LabWork1.UnitTests.Features.Task3;

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

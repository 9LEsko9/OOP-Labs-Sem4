using System.Numerics;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1;

[TestFixture]
public class MyVectorTests
{

    [Test]
    public void Addition_ShouldSumCoordinates()
    {
        var v1 = new MyVector(1.5, 2.0);
        var v2 = new MyVector(3.5, 4.0);

        var result = v1 + v2;

        Assert.That(result.DirectionX, Is.EqualTo(5.0));
        Assert.That(result.DirectionY, Is.EqualTo(6.0));
    }

    [Test]
    public void Subtraction_ShouldSubtractCoordinates()
    {
        var v1 = new MyVector(10, 5);
        var v2 = new MyVector(3, 2);

        var result = v1 - v2;

        Assert.That(result.DirectionX, Is.EqualTo(7));
        Assert.That(result.DirectionY, Is.EqualTo(3));
    }

    [Test]
    public void Multiplication_TwoVectors_ShouldReturnDotProduct()
    {
        var v1 = new MyVector(2, 3);
        var v2 = new MyVector(4, 5);

        double result = v1 * v2;

        Assert.That(result, Is.EqualTo(23)); // (2*4) + (3*5)
    }

    [TestCase(2, 3, 2, 4, 6)]
    [TestCase(-1, 5, 10, -10, 50)]
    public void Multiplication_ByScalar_ShouldScaleCoordinates(double x, double y, double scalar, double expX, double expY)
    {
        var v = new MyVector(x, y);

        var resultRight = v * scalar;
        var resultLeft = scalar * v;

        Assert.That(resultRight.DirectionX, Is.EqualTo(expX));
        Assert.That(resultRight.DirectionY, Is.EqualTo(expY));
        Assert.That(resultLeft, Is.EqualTo(resultRight), "Коммутативность поломана");
    }

    [Test]
    public void Equality_SameCoordinates_ShouldBeTrue()
    {
        var v1 = new MyVector(1.1, 2.2);
        var v2 = new MyVector(1.1, 2.2);
        var v3 = new MyVector(1.1, 3.3);

        Assert.Multiple(() =>
        {
            Assert.That(v1 == v2, Is.True);
            Assert.That(v1.Equals(v2), Is.True);
            Assert.That(v1 != v3, Is.True);
            Assert.That(v1.GetHashCode(), Is.EqualTo(v2.GetHashCode()));
        });
    }

    [Test]
    public void Equality_NullHandling_ShouldNotThrow()
    {
        MyVector v1 = new MyVector(1, 1);
        MyVector? v2 = null;

        Assert.Multiple(() =>
        {
            Assert.That(v1 == v2, Is.False);
            Assert.That(v2 == v1, Is.False);
            Assert.That(v1.Equals(null), Is.False);
        });
    }

    [Test]
    public void ToString_ShouldReturnCorrectFormat()
    {
        var v = new MyVector(5, 10);
        Assert.That(v.ToString(), Is.EqualTo("(5, 10)"));
    }


    [Test]
    public void UnaryPlus_ShouldReturnVectorLength()
    {
        var v = new MyVector(3, 4);

        double length = +v;

        Assert.That(length, Is.EqualTo(5.0));
    }

    [Test]
    public void UnaryPlus_ZeroVector_ShouldReturnZero()
    {
        var v = new MyVector(0, 0);
        Assert.That(+v, Is.EqualTo(0.0));
    }
}

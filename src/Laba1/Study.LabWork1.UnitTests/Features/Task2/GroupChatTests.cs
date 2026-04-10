using System.Text;
using Study.LabWork1.Features.Task2.Implementations.Colleguages;
using Study.LabWork1.Features.Task2.Implementations.Mediators;

namespace Study.LabWork1.UnitTests.Features.Task2;

[TestFixture]
public class GroupChatTests
{
    private GroupChatMediator _mediator;
    private StringBuilder _consoleOutput;

    [SetUp]
    public void Setup()
    {
        _mediator = new GroupChatMediator();
        _consoleOutput = new StringBuilder();

        // Перехватываем вывод консоли для проверки метода Notify
        Console.SetOut(new StringWriter(_consoleOutput));
    }

    [Test]
    public void AddParticipant_ShouldIncreaseParticipantsCount()
    {
        var user = new GroupChatColleague("Alice", _mediator);

        Assert.That(_mediator.ChatColleagues, Has.Count.EqualTo(1));
        Assert.That(_mediator.ChatColleagues[0].Name, Is.EqualTo("Alice"));
    }

    [Test]
    public void SendMessage_ShouldNotifyOtherParticipants()
    {
        var alice = new GroupChatColleague("Alice", _mediator);
        var bob = new GroupChatColleague("Bob", _mediator);
        string message = "Hello, everyone!";

        alice.SendMessage(message);

        var output = _consoleOutput.ToString();
        Assert.That(output, Does.Contain("Новое сообщение для Bob!"));
        Assert.That(output, Does.Contain("[Alice] : Hello, everyone!"));
    }

    [Test]
    public void SendMessage_ShouldNotNotifySender()
    {
        var alice = new GroupChatColleague("Alice", _mediator);
        string message = "Self message";

        alice.SendMessage(message);

        var output = _consoleOutput.ToString();

        // Проверяем, что отправитель не получил уведомление сам от себя
        Assert.That(output, Does.Not.Contain("Новое сообщение для Alice!"));
    }

    [Test]
    public void Constructor_WithNullName_ShouldThrowException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            new GroupChatColleague(null!, _mediator));
    }

    [TearDown]
    public void Cleanup()
    {
        // Возвращаем стандартный вывод консоли
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
    }
}

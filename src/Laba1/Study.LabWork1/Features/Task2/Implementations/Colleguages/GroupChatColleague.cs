using Study.LabWork1.Features.Task2.Abstractions;
using Study.LabWork1.Features.Task2.Implementations.Mediators;

namespace Study.LabWork1.Features.Task2.Implementations.Colleguages;


/// <summary>
/// Класс участника группового чатика
/// </summary>
public class GroupChatColleague : BaseColleague
{
    private string FormatMessage(string message) => $"[{Name}] : {message}";

    /// <summary>
    /// Имя участника
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Конструктор участинка чата, рассчитан на GroupChatMediator
    /// </summary>
    /// <param name="name"></param>
    /// <param name="mediator"></param>
    public GroupChatColleague(string name, GroupChatMediator mediator) : base(mediator)
    {
        if (name is null)
        {
            throw new InvalidOperationException("Cannot create user without name!");
        }
        Name = name;
        mediator.AddParticipant(this);
    }

    /// <summary>
    /// Метод отправки сообщения в групповой чатик
    /// </summary>
    /// <param name="message"></param>
    public void SendMessage(string message)
    {
        Mediator?.SendMessage(FormatMessage(message), this);
    }

    /// <summary>
    /// Метод с помощью которого посредник уведомляет о новом сообщении участника
    /// </summary>
    /// <param name="message"></param>
    public void Notify(string message)
    {
        if (Name is not null)
        {
            Console.WriteLine($"Новое сообщение для {Name}!");
            Console.WriteLine(message);
        }
    }
}

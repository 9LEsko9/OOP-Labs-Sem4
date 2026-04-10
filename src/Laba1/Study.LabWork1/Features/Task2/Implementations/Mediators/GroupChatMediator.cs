using Study.LabWork1.Features.Task2.Abstractions;
using Study.LabWork1.Features.Task2.Implementations.Colleguages;

namespace Study.LabWork1.Features.Task2.Implementations.Mediators;


/// <summary>
/// Посредник для группового чата
/// </summary>
public class GroupChatMediator : BaseMediator
{
    /// <summary>
    /// Участники группового чатика
    /// </summary>
    private List<GroupChatColleague> _chatParticipants = [];

    /// <summary>
    /// Контейнер только для чтения с участниками чатика
    /// </summary>
    public IReadOnlyList<GroupChatColleague> ChatColleagues { get => _chatParticipants.AsReadOnly(); }

    /// <summary>
    /// Метод добавления нового участника в чатик
    /// </summary>
    /// <param name="colleague"></param>
    public void AddParticipant(GroupChatColleague colleague) => _chatParticipants.Add(colleague);

    /// <summary>
    /// Метод отправки сообщения всем в чатик, с уведомлением
    /// </summary>
    /// <param name="message"></param>
    /// <param name="colleague"></param>
    public override void SendMessage(string message, BaseColleague colleague)
    {
        foreach (var chatPaticipant in _chatParticipants)
        {
            if (!chatPaticipant.Equals(colleague))
            {
                chatPaticipant.Notify(message);
            }
        }
    }
}

namespace Study.LabWork1.Features.Task2.Abstractions;

/// <summary>
/// Абстрактный класс посредника предоставляющий контракт на SendMessage
/// </summary>
public abstract class BaseMediator
{
    /// <summary>
    /// Метод отправки сообщения, участником, у которого есть доступ к посреднику
    /// </summary>
    /// <param name="message"></param>
    /// <param name="colleague"></param>
    public abstract void SendMessage(string message, BaseColleague colleague);
}

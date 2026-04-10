using Study.LabWork1.Features.Task2.Implementations.Colleguages;
using Study.LabWork1.Features.Task2.Implementations.Mediators;
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
    public void RunTask2()
    {
        Console.WriteLine("============================= Задача 2 ===============================");

        var mediator = new GroupChatMediator();

        var user1 = new GroupChatColleague("Реске", mediator);
        var user2 = new GroupChatColleague("Такуми", mediator);
        var user3 = new GroupChatColleague("Кеске", mediator);

        user1.SendMessage("Ночь обещает быть прохладной.");
        user2.SendMessage("Это может повлиять на сцепление шин на горной дороге.");
        user3.SendMessage("Думаю, на подъеме это вызовет больше проблем, чем на спуске.");

    }

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}

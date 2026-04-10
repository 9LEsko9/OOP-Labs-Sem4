namespace Study.LabWork1.Features.Task2.Abstractions;

/// <summary>
/// Абстрактный класс участника переписки
/// </summary>
/// <param name="mediator"></param>
public abstract class BaseColleague(BaseMediator mediator)
{
    /// <summary>
    /// Доступ к посреднику сообщений для классов наследников
    /// </summary>
    protected BaseMediator Mediator = mediator;
}

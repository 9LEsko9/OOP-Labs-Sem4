<a name='assembly'></a>
# Study.LabWork1

## Contents

- [BaseColleague](#T-Study-LabWork1-Features-Task2-Abstractions-BaseColleague 'Study.LabWork1.Features.Task2.Abstractions.BaseColleague')
  - [#ctor(mediator)](#M-Study-LabWork1-Features-Task2-Abstractions-BaseColleague-#ctor-Study-LabWork1-Features-Task2-Abstractions-BaseMediator- 'Study.LabWork1.Features.Task2.Abstractions.BaseColleague.#ctor(Study.LabWork1.Features.Task2.Abstractions.BaseMediator)')
  - [Mediator](#F-Study-LabWork1-Features-Task2-Abstractions-BaseColleague-Mediator 'Study.LabWork1.Features.Task2.Abstractions.BaseColleague.Mediator')
- [BaseMediator](#T-Study-LabWork1-Features-Task2-Abstractions-BaseMediator 'Study.LabWork1.Features.Task2.Abstractions.BaseMediator')
  - [SendMessage(message,colleague)](#M-Study-LabWork1-Features-Task2-Abstractions-BaseMediator-SendMessage-System-String,Study-LabWork1-Features-Task2-Abstractions-BaseColleague- 'Study.LabWork1.Features.Task2.Abstractions.BaseMediator.SendMessage(System.String,Study.LabWork1.Features.Task2.Abstractions.BaseColleague)')
- [GroupChatColleague](#T-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague 'Study.LabWork1.Features.Task2.Implementations.Colleguages.GroupChatColleague')
  - [#ctor(name,mediator)](#M-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague-#ctor-System-String,Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator- 'Study.LabWork1.Features.Task2.Implementations.Colleguages.GroupChatColleague.#ctor(System.String,Study.LabWork1.Features.Task2.Implementations.Mediators.GroupChatMediator)')
  - [Name](#P-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague-Name 'Study.LabWork1.Features.Task2.Implementations.Colleguages.GroupChatColleague.Name')
  - [Notify(message)](#M-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague-Notify-System-String- 'Study.LabWork1.Features.Task2.Implementations.Colleguages.GroupChatColleague.Notify(System.String)')
  - [SendMessage(message)](#M-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague-SendMessage-System-String- 'Study.LabWork1.Features.Task2.Implementations.Colleguages.GroupChatColleague.SendMessage(System.String)')
- [GroupChatMediator](#T-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator 'Study.LabWork1.Features.Task2.Implementations.Mediators.GroupChatMediator')
  - [_chatParticipants](#F-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator-_chatParticipants 'Study.LabWork1.Features.Task2.Implementations.Mediators.GroupChatMediator._chatParticipants')
  - [ChatColleagues](#P-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator-ChatColleagues 'Study.LabWork1.Features.Task2.Implementations.Mediators.GroupChatMediator.ChatColleagues')
  - [AddParticipant(colleague)](#M-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator-AddParticipant-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague- 'Study.LabWork1.Features.Task2.Implementations.Mediators.GroupChatMediator.AddParticipant(Study.LabWork1.Features.Task2.Implementations.Colleguages.GroupChatColleague)')
  - [SendMessage(message,colleague)](#M-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator-SendMessage-System-String,Study-LabWork1-Features-Task2-Abstractions-BaseColleague- 'Study.LabWork1.Features.Task2.Implementations.Mediators.GroupChatMediator.SendMessage(System.String,Study.LabWork1.Features.Task2.Abstractions.BaseColleague)')
- [IRunService](#T-Study-LabWork1-Shared-Abstractions-IRunService 'Study.LabWork1.Shared.Abstractions.IRunService')
  - [RunTask1()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask1 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask1')
  - [RunTask2()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask2 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask2')
  - [RunTask3()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask3 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask3')
- [Program](#T-Study-LabWork1-Program 'Study.LabWork1.Program')
  - [RUN_TASK_NUMBER](#F-Study-LabWork1-Program-RUN_TASK_NUMBER 'Study.LabWork1.Program.RUN_TASK_NUMBER')
  - [Main()](#M-Study-LabWork1-Program-Main 'Study.LabWork1.Program.Main')
- [RunService](#T-Study-LabWork1-Shared-Services-RunService 'Study.LabWork1.Shared.Services.RunService')
  - [RunTask1()](#M-Study-LabWork1-Shared-Services-RunService-RunTask1 'Study.LabWork1.Shared.Services.RunService.RunTask1')
  - [RunTask2()](#M-Study-LabWork1-Shared-Services-RunService-RunTask2 'Study.LabWork1.Shared.Services.RunService.RunTask2')
  - [RunTask3()](#M-Study-LabWork1-Shared-Services-RunService-RunTask3 'Study.LabWork1.Shared.Services.RunService.RunTask3')

<a name='T-Study-LabWork1-Features-Task2-Abstractions-BaseColleague'></a>
## BaseColleague `type`

##### Namespace

Study.LabWork1.Features.Task2.Abstractions

##### Summary

Абстрактный класс участника переписки

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediator | [T:Study.LabWork1.Features.Task2.Abstractions.BaseColleague](#T-T-Study-LabWork1-Features-Task2-Abstractions-BaseColleague 'T:Study.LabWork1.Features.Task2.Abstractions.BaseColleague') |  |

<a name='M-Study-LabWork1-Features-Task2-Abstractions-BaseColleague-#ctor-Study-LabWork1-Features-Task2-Abstractions-BaseMediator-'></a>
### #ctor(mediator) `constructor`

##### Summary

Абстрактный класс участника переписки

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mediator | [Study.LabWork1.Features.Task2.Abstractions.BaseMediator](#T-Study-LabWork1-Features-Task2-Abstractions-BaseMediator 'Study.LabWork1.Features.Task2.Abstractions.BaseMediator') |  |

<a name='F-Study-LabWork1-Features-Task2-Abstractions-BaseColleague-Mediator'></a>
### Mediator `constants`

##### Summary

Доступ к посреднику сообщений для классов наследников

<a name='T-Study-LabWork1-Features-Task2-Abstractions-BaseMediator'></a>
## BaseMediator `type`

##### Namespace

Study.LabWork1.Features.Task2.Abstractions

##### Summary

Абстрактный класс посредника предоставляющий контракт на SendMessage

<a name='M-Study-LabWork1-Features-Task2-Abstractions-BaseMediator-SendMessage-System-String,Study-LabWork1-Features-Task2-Abstractions-BaseColleague-'></a>
### SendMessage(message,colleague) `method`

##### Summary

Метод отправки сообщения, участником, у которого есть доступ к посреднику

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| colleague | [Study.LabWork1.Features.Task2.Abstractions.BaseColleague](#T-Study-LabWork1-Features-Task2-Abstractions-BaseColleague 'Study.LabWork1.Features.Task2.Abstractions.BaseColleague') |  |

<a name='T-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague'></a>
## GroupChatColleague `type`

##### Namespace

Study.LabWork1.Features.Task2.Implementations.Colleguages

##### Summary

Класс участника группового чатика

<a name='M-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague-#ctor-System-String,Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator-'></a>
### #ctor(name,mediator) `constructor`

##### Summary

Конструктор участинка чата, рассчитан на GroupChatMediator

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| mediator | [Study.LabWork1.Features.Task2.Implementations.Mediators.GroupChatMediator](#T-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator 'Study.LabWork1.Features.Task2.Implementations.Mediators.GroupChatMediator') |  |

<a name='P-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague-Name'></a>
### Name `property`

##### Summary

Имя участника

<a name='M-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague-Notify-System-String-'></a>
### Notify(message) `method`

##### Summary

Метод с помощью которого посредник уведомляет о новом сообщении участника

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague-SendMessage-System-String-'></a>
### SendMessage(message) `method`

##### Summary

Метод отправки сообщения в групповой чатик

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator'></a>
## GroupChatMediator `type`

##### Namespace

Study.LabWork1.Features.Task2.Implementations.Mediators

##### Summary

Посредник для группового чата

<a name='F-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator-_chatParticipants'></a>
### _chatParticipants `constants`

##### Summary

Участники группового чатика

<a name='P-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator-ChatColleagues'></a>
### ChatColleagues `property`

##### Summary

Контейнер только для чтения с участниками чатика

<a name='M-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator-AddParticipant-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague-'></a>
### AddParticipant(colleague) `method`

##### Summary

Метод добавления нового участника в чатик

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| colleague | [Study.LabWork1.Features.Task2.Implementations.Colleguages.GroupChatColleague](#T-Study-LabWork1-Features-Task2-Implementations-Colleguages-GroupChatColleague 'Study.LabWork1.Features.Task2.Implementations.Colleguages.GroupChatColleague') |  |

<a name='M-Study-LabWork1-Features-Task2-Implementations-Mediators-GroupChatMediator-SendMessage-System-String,Study-LabWork1-Features-Task2-Abstractions-BaseColleague-'></a>
### SendMessage(message,colleague) `method`

##### Summary

Метод отправки сообщения всем в чатик, с уведомлением

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| colleague | [Study.LabWork1.Features.Task2.Abstractions.BaseColleague](#T-Study-LabWork1-Features-Task2-Abstractions-BaseColleague 'Study.LabWork1.Features.Task2.Abstractions.BaseColleague') |  |

<a name='T-Study-LabWork1-Shared-Abstractions-IRunService'></a>
## IRunService `type`

##### Namespace

Study.LabWork1.Shared.Abstractions

##### Summary

Интерфейс для реализации заданий Л/Р

<a name='M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask1'></a>
### RunTask1() `method`

##### Summary

Запуск выполнения задания 1

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask2'></a>
### RunTask2() `method`

##### Summary

Запуск выполнения задания 2

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask3'></a>
### RunTask3() `method`

##### Summary

Запуск выполнения задания 3

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork1-Program'></a>
## Program `type`

##### Namespace

Study.LabWork1

##### Summary

Начальная точка входа

<a name='F-Study-LabWork1-Program-RUN_TASK_NUMBER'></a>
### RUN_TASK_NUMBER `constants`

##### Summary

Номер выполняемой задачи

<a name='M-Study-LabWork1-Program-Main'></a>
### Main() `method`

##### Summary

Старт программы

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork1-Shared-Services-RunService'></a>
## RunService `type`

##### Namespace

Study.LabWork1.Shared.Services

##### Summary

Реализация заданий Л/Р

<a name='M-Study-LabWork1-Shared-Services-RunService-RunTask1'></a>
### RunTask1() `method`

##### Summary

Задание 1

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Services-RunService-RunTask2'></a>
### RunTask2() `method`

##### Summary

Задание 2

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Services-RunService-RunTask3'></a>
### RunTask3() `method`

##### Summary

Задание 3

##### Parameters

This method has no parameters.

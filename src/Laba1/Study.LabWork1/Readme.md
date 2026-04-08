<a name='assembly'></a>
# Study.LabWork1

## Contents

- [Graph](#T-Study-LabWork1-Features-Task3-Graph 'Study.LabWork1.Features.Task3.Graph')
  - [AddNode(destinationNode,outGoingNode)](#M-Study-LabWork1-Features-Task3-Graph-AddNode-Study-LabWork1-Features-Task3-GraphNode,Study-LabWork1-Features-Task3-GraphNode- 'Study.LabWork1.Features.Task3.Graph.AddNode(Study.LabWork1.Features.Task3.GraphNode,Study.LabWork1.Features.Task3.GraphNode)')
- [GraphEdge](#T-Study-LabWork1-Features-Task3-GraphEdge 'Study.LabWork1.Features.Task3.GraphEdge')
  - [#ctor()](#M-Study-LabWork1-Features-Task3-GraphEdge-#ctor-Study-LabWork1-Features-Task3-GraphNode,Study-LabWork1-Features-Task3-GraphNode- 'Study.LabWork1.Features.Task3.GraphEdge.#ctor(Study.LabWork1.Features.Task3.GraphNode,Study.LabWork1.Features.Task3.GraphNode)')
  - [Destination](#P-Study-LabWork1-Features-Task3-GraphEdge-Destination 'Study.LabWork1.Features.Task3.GraphEdge.Destination')
  - [Outgoing](#P-Study-LabWork1-Features-Task3-GraphEdge-Outgoing 'Study.LabWork1.Features.Task3.GraphEdge.Outgoing')
- [GraphNode](#T-Study-LabWork1-Features-Task3-GraphNode 'Study.LabWork1.Features.Task3.GraphNode')
  - [#ctor()](#M-Study-LabWork1-Features-Task3-GraphNode-#ctor-System-Int32- 'Study.LabWork1.Features.Task3.GraphNode.#ctor(System.Int32)')
  - [Weight](#P-Study-LabWork1-Features-Task3-GraphNode-Weight 'Study.LabWork1.Features.Task3.GraphNode.Weight')
  - [AddEdge(edge)](#M-Study-LabWork1-Features-Task3-GraphNode-AddEdge-Study-LabWork1-Features-Task3-GraphEdge- 'Study.LabWork1.Features.Task3.GraphNode.AddEdge(Study.LabWork1.Features.Task3.GraphEdge)')
  - [GetAllEdges()](#M-Study-LabWork1-Features-Task3-GraphNode-GetAllEdges 'Study.LabWork1.Features.Task3.GraphNode.GetAllEdges')
  - [Print()](#M-Study-LabWork1-Features-Task3-GraphNode-Print 'Study.LabWork1.Features.Task3.GraphNode.Print')
  - [RemoveEdge(edge)](#M-Study-LabWork1-Features-Task3-GraphNode-RemoveEdge-Study-LabWork1-Features-Task3-GraphEdge- 'Study.LabWork1.Features.Task3.GraphNode.RemoveEdge(Study.LabWork1.Features.Task3.GraphEdge)')
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

<a name='T-Study-LabWork1-Features-Task3-Graph'></a>
## Graph `type`

##### Namespace

Study.LabWork1.Features.Task3

##### Summary

Класс графа

<a name='M-Study-LabWork1-Features-Task3-Graph-AddNode-Study-LabWork1-Features-Task3-GraphNode,Study-LabWork1-Features-Task3-GraphNode-'></a>
### AddNode(destinationNode,outGoingNode) `method`

##### Summary

Метод добавления узлов в граф

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| destinationNode | [Study.LabWork1.Features.Task3.GraphNode](#T-Study-LabWork1-Features-Task3-GraphNode 'Study.LabWork1.Features.Task3.GraphNode') |  |
| outGoingNode | [Study.LabWork1.Features.Task3.GraphNode](#T-Study-LabWork1-Features-Task3-GraphNode 'Study.LabWork1.Features.Task3.GraphNode') |  |

<a name='T-Study-LabWork1-Features-Task3-GraphEdge'></a>
## GraphEdge `type`

##### Namespace

Study.LabWork1.Features.Task3

##### Summary

Класс выполняющий роль ребра графа

<a name='M-Study-LabWork1-Features-Task3-GraphEdge-#ctor-Study-LabWork1-Features-Task3-GraphNode,Study-LabWork1-Features-Task3-GraphNode-'></a>
### #ctor() `constructor`

##### Summary

Класс выполняющий роль ребра графа

##### Parameters

This constructor has no parameters.

<a name='P-Study-LabWork1-Features-Task3-GraphEdge-Destination'></a>
### Destination `property`

##### Summary

Узел куда приходит ребро

<a name='P-Study-LabWork1-Features-Task3-GraphEdge-Outgoing'></a>
### Outgoing `property`

##### Summary

Узел из которого исходит ребро

<a name='T-Study-LabWork1-Features-Task3-GraphNode'></a>
## GraphNode `type`

##### Namespace

Study.LabWork1.Features.Task3

##### Summary

Класс представляющий собой узел графа

<a name='M-Study-LabWork1-Features-Task3-GraphNode-#ctor-System-Int32-'></a>
### #ctor() `constructor`

##### Summary

Класс представляющий собой узел графа

##### Parameters

This constructor has no parameters.

<a name='P-Study-LabWork1-Features-Task3-GraphNode-Weight'></a>
### Weight `property`

##### Summary

ß
Вес узла графа

<a name='M-Study-LabWork1-Features-Task3-GraphNode-AddEdge-Study-LabWork1-Features-Task3-GraphEdge-'></a>
### AddEdge(edge) `method`

##### Summary

Метод привязки ребра к узлу графа

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| edge | [Study.LabWork1.Features.Task3.GraphEdge](#T-Study-LabWork1-Features-Task3-GraphEdge 'Study.LabWork1.Features.Task3.GraphEdge') |  |

<a name='M-Study-LabWork1-Features-Task3-GraphNode-GetAllEdges'></a>
### GetAllEdges() `method`

##### Summary

Метод получения ребер графа

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task3-GraphNode-Print'></a>
### Print() `method`

##### Summary

Функция вывода узла и всех его потомков

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task3-GraphNode-RemoveEdge-Study-LabWork1-Features-Task3-GraphEdge-'></a>
### RemoveEdge(edge) `method`

##### Summary

Метод отвязки ребра от узла

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| edge | [Study.LabWork1.Features.Task3.GraphEdge](#T-Study-LabWork1-Features-Task3-GraphEdge 'Study.LabWork1.Features.Task3.GraphEdge') |  |

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

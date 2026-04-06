<a name='assembly'></a>
# Study.LabWork1

## Contents

- [IRunService](#T-Study-LabWork1-Shared-Abstractions-IRunService 'Study.LabWork1.Shared.Abstractions.IRunService')
  - [RunTask1()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask1 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask1')
  - [RunTask2()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask2 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask2')
  - [RunTask3()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask3 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask3')
- [MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector')
  - [#ctor(x,y)](#M-Study-LabWork1-Features-Task1-MyVector-#ctor-System-Double,System-Double- 'Study.LabWork1.Features.Task1.MyVector.#ctor(System.Double,System.Double)')
  - [DirectionX](#P-Study-LabWork1-Features-Task1-MyVector-DirectionX 'Study.LabWork1.Features.Task1.MyVector.DirectionX')
  - [DirectionY](#P-Study-LabWork1-Features-Task1-MyVector-DirectionY 'Study.LabWork1.Features.Task1.MyVector.DirectionY')
  - [Equals(obj)](#M-Study-LabWork1-Features-Task1-MyVector-Equals-System-Object- 'Study.LabWork1.Features.Task1.MyVector.Equals(System.Object)')
  - [GetHashCode()](#M-Study-LabWork1-Features-Task1-MyVector-GetHashCode 'Study.LabWork1.Features.Task1.MyVector.GetHashCode')
  - [ToString()](#M-Study-LabWork1-Features-Task1-MyVector-ToString 'Study.LabWork1.Features.Task1.MyVector.ToString')
  - [op_Addition(lhs,rhs)](#M-Study-LabWork1-Features-Task1-MyVector-op_Addition-Study-LabWork1-Features-Task1-MyVector,Study-LabWork1-Features-Task1-MyVector- 'Study.LabWork1.Features.Task1.MyVector.op_Addition(Study.LabWork1.Features.Task1.MyVector,Study.LabWork1.Features.Task1.MyVector)')
  - [op_Equality(lhs,rhs)](#M-Study-LabWork1-Features-Task1-MyVector-op_Equality-Study-LabWork1-Features-Task1-MyVector,Study-LabWork1-Features-Task1-MyVector- 'Study.LabWork1.Features.Task1.MyVector.op_Equality(Study.LabWork1.Features.Task1.MyVector,Study.LabWork1.Features.Task1.MyVector)')
  - [op_Inequality(lhs,rhs)](#M-Study-LabWork1-Features-Task1-MyVector-op_Inequality-Study-LabWork1-Features-Task1-MyVector,Study-LabWork1-Features-Task1-MyVector- 'Study.LabWork1.Features.Task1.MyVector.op_Inequality(Study.LabWork1.Features.Task1.MyVector,Study.LabWork1.Features.Task1.MyVector)')
  - [op_Multiply(lhs,rhs)](#M-Study-LabWork1-Features-Task1-MyVector-op_Multiply-Study-LabWork1-Features-Task1-MyVector,Study-LabWork1-Features-Task1-MyVector- 'Study.LabWork1.Features.Task1.MyVector.op_Multiply(Study.LabWork1.Features.Task1.MyVector,Study.LabWork1.Features.Task1.MyVector)')
  - [op_Multiply(lhs,rhs)](#M-Study-LabWork1-Features-Task1-MyVector-op_Multiply-Study-LabWork1-Features-Task1-MyVector,System-Double- 'Study.LabWork1.Features.Task1.MyVector.op_Multiply(Study.LabWork1.Features.Task1.MyVector,System.Double)')
  - [op_Multiply(lhs,rhs)](#M-Study-LabWork1-Features-Task1-MyVector-op_Multiply-System-Double,Study-LabWork1-Features-Task1-MyVector- 'Study.LabWork1.Features.Task1.MyVector.op_Multiply(System.Double,Study.LabWork1.Features.Task1.MyVector)')
  - [op_Subtraction(lhs,rhs)](#M-Study-LabWork1-Features-Task1-MyVector-op_Subtraction-Study-LabWork1-Features-Task1-MyVector,Study-LabWork1-Features-Task1-MyVector- 'Study.LabWork1.Features.Task1.MyVector.op_Subtraction(Study.LabWork1.Features.Task1.MyVector,Study.LabWork1.Features.Task1.MyVector)')
- [Program](#T-Study-LabWork1-Program 'Study.LabWork1.Program')
  - [RUN_TASK_NUMBER](#F-Study-LabWork1-Program-RUN_TASK_NUMBER 'Study.LabWork1.Program.RUN_TASK_NUMBER')
  - [Main()](#M-Study-LabWork1-Program-Main 'Study.LabWork1.Program.Main')
- [RunService](#T-Study-LabWork1-Shared-Services-RunService 'Study.LabWork1.Shared.Services.RunService')
  - [RunTask1()](#M-Study-LabWork1-Shared-Services-RunService-RunTask1 'Study.LabWork1.Shared.Services.RunService.RunTask1')
  - [RunTask2()](#M-Study-LabWork1-Shared-Services-RunService-RunTask2 'Study.LabWork1.Shared.Services.RunService.RunTask2')
  - [RunTask3()](#M-Study-LabWork1-Shared-Services-RunService-RunTask3 'Study.LabWork1.Shared.Services.RunService.RunTask3')

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

<a name='T-Study-LabWork1-Features-Task1-MyVector'></a>
## MyVector `type`

##### Namespace

Study.LabWork1.Features.Task1

##### Summary

Двумерный вектор. Вариант 5

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [T:Study.LabWork1.Features.Task1.MyVector](#T-T-Study-LabWork1-Features-Task1-MyVector 'T:Study.LabWork1.Features.Task1.MyVector') |  |

<a name='M-Study-LabWork1-Features-Task1-MyVector-#ctor-System-Double,System-Double-'></a>
### #ctor(x,y) `constructor`

##### Summary

Двумерный вектор. Вариант 5

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |
| y | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='P-Study-LabWork1-Features-Task1-MyVector-DirectionX'></a>
### DirectionX `property`

##### Summary

Направление вектора по оси абцисс

<a name='P-Study-LabWork1-Features-Task1-MyVector-DirectionY'></a>
### DirectionY `property`

##### Summary

Направление вектора по оси ординат

<a name='M-Study-LabWork1-Features-Task1-MyVector-Equals-System-Object-'></a>
### Equals(obj) `method`

##### Summary

Проверяет равны ли объекты вызывая оператор равенства

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| obj | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |

<a name='M-Study-LabWork1-Features-Task1-MyVector-GetHashCode'></a>
### GetHashCode() `method`

##### Summary

Получение хэша объекта, комбинирует направление по x и направление по y

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-MyVector-ToString'></a>
### ToString() `method`

##### Summary

Форматирует вектор в качестве строки в вид (x, y)

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-MyVector-op_Addition-Study-LabWork1-Features-Task1-MyVector,Study-LabWork1-Features-Task1-MyVector-'></a>
### op_Addition(lhs,rhs) `method`

##### Summary

Перегрузка оператора сложения, складывает координаты вектора

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |
| rhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |

<a name='M-Study-LabWork1-Features-Task1-MyVector-op_Equality-Study-LabWork1-Features-Task1-MyVector,Study-LabWork1-Features-Task1-MyVector-'></a>
### op_Equality(lhs,rhs) `method`

##### Summary

Проверяет равенство векторов, через высчитывание дельт координат и сравнения их с заданной точностью epsilon

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |
| rhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |

<a name='M-Study-LabWork1-Features-Task1-MyVector-op_Inequality-Study-LabWork1-Features-Task1-MyVector,Study-LabWork1-Features-Task1-MyVector-'></a>
### op_Inequality(lhs,rhs) `method`

##### Summary

Проверяет неравенство векторов, через вызов отрицания оператора равно

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |
| rhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |

<a name='M-Study-LabWork1-Features-Task1-MyVector-op_Multiply-Study-LabWork1-Features-Task1-MyVector,Study-LabWork1-Features-Task1-MyVector-'></a>
### op_Multiply(lhs,rhs) `method`

##### Summary

Перегрузка опрератора умножения, выполняет скалярное произведение двух векторов

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |
| rhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |

<a name='M-Study-LabWork1-Features-Task1-MyVector-op_Multiply-Study-LabWork1-Features-Task1-MyVector,System-Double-'></a>
### op_Multiply(lhs,rhs) `method`

##### Summary

Перегрузка оператора умножения, выполняет скалярное умножение вектора на число

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |
| rhs | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |

<a name='M-Study-LabWork1-Features-Task1-MyVector-op_Multiply-System-Double,Study-LabWork1-Features-Task1-MyVector-'></a>
### op_Multiply(lhs,rhs) `method`

##### Summary

Перегрузка оператора умножения, выполняет скалярное умножение вектора на число

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lhs | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') |  |
| rhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |

<a name='M-Study-LabWork1-Features-Task1-MyVector-op_Subtraction-Study-LabWork1-Features-Task1-MyVector,Study-LabWork1-Features-Task1-MyVector-'></a>
### op_Subtraction(lhs,rhs) `method`

##### Summary

Перегрузка оператора вычитания, вычитает координаты второго вектора из первого

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| lhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |
| rhs | [Study.LabWork1.Features.Task1.MyVector](#T-Study-LabWork1-Features-Task1-MyVector 'Study.LabWork1.Features.Task1.MyVector') |  |

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

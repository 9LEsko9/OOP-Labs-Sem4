using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Study.LabWork1.Features.Task1;

/// <summary>
/// Двумерный вектор. Вариант 5
/// </summary>
/// <param name="x"></param>
/// <param name="y"></param>
public class MyVector(double x, double y)
{
    /// <summary>
    /// Направление вектора по оси абцисс
    /// </summary>
    public double DirectionX { get;  } = x;

    /// <summary>
    /// Направление вектора по оси ординат
    /// </summary>
    public double DirectionY { get; } = y;

    /// <summary>
    /// Перегрузка оператора сложения, складывает координаты вектора
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static MyVector operator +(MyVector lhs, MyVector rhs)
    {
        return new MyVector(lhs.DirectionX + rhs.DirectionX,
            lhs.DirectionY + rhs.DirectionY);
    }

    /// <summary>
    /// Перегрузка оператора вычитания, вычитает координаты второго вектора из первого
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static MyVector operator -(MyVector lhs, MyVector rhs)
    {
        return new MyVector(lhs.DirectionX - rhs.DirectionX,
            lhs.DirectionY - rhs.DirectionY);
    }

    /// <summary>
    /// Перегрузка опрератора умножения, выполняет скалярное произведение двух векторов
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>

    public static double operator *(MyVector lhs, MyVector rhs)
    {
        return (lhs.DirectionX * rhs.DirectionX)
               + (lhs.DirectionY * rhs.DirectionY);
    }

    /// <summary>
    /// Перегрузка оператора умножения, выполняет скалярное умножение вектора на число
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static MyVector operator *(MyVector lhs, double rhs)
    {
        return new MyVector(lhs.DirectionX * rhs, lhs.DirectionY * rhs);
    }

    /// <summary>
    /// Перегрузка оператора умножения, выполняет скалярное умножение вектора на число
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static MyVector operator *(double lhs, MyVector rhs) => rhs * lhs;

    /// <summary>
    /// Получение хэша объекта, комбинирует направление по x и направление по y
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(DirectionX, DirectionY);
    }

    /// <summary>
    /// Проверяет равны ли объекты вызывая оператор равенства
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>

    public override bool Equals(object obj)
    {
        if (obj is MyVector otherVector)
        {
            return this == otherVector;
        }
        return false;
    }

    /// <summary>
    /// Проверяет равенство векторов, через высчитывание дельт координат и сравнения их с заданной точностью epsilon
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool operator ==(MyVector lhs, MyVector rhs)
    {
        if (ReferenceEquals(lhs, rhs))
        {
            return true;
        }

        if (lhs is null || rhs is null)
        {
            return false;
        }

        return lhs.DirectionX.Equals(rhs.DirectionX) && lhs.DirectionY.Equals(rhs.DirectionY);
    }

    /// <summary>
    /// Проверяет неравенство векторов, через вызов отрицания оператора равно
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool operator !=(MyVector lhs, MyVector rhs) => !(lhs == rhs);

    /// <summary>
    /// Форматирует вектор в качестве строки в вид (x, y)
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"({DirectionX}, {DirectionY})";
    }
}

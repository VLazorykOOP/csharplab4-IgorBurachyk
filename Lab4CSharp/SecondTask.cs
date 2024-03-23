using System;

public class VectorShort
{
    protected short[] ShortArray;
    protected uint n;
    protected uint codeError;
    protected static uint num_v;

    // Конструктор без параметрів
    public VectorShort()
    {
        ShortArray = new short[1];
        n = 1;
        codeError = 0;
        num_v++;
    }

    // Конструктор з одним параметром - розмір вектора
    public VectorShort(uint size)
    {
        ShortArray = new short[size];
        n = size;
        codeError = 0;
        num_v++;
    }

    // Конструктор з двома параметрами - розмір вектора та значення ініціалізації
    public VectorShort(uint size, short value)
    {
        ShortArray = new short[size];
        n = size;
        for (int i = 0; i < size; i++)
        {
            ShortArray[i] = value;
        }
        codeError = 0;
        num_v++;
    }

    // Деструктор
    ~VectorShort()
    {
        Console.WriteLine("Destructor called");
    }

    // Метод для введення елементів вектора з клавіатури
    public void Input()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter element {i}: ");
            ShortArray[i] = short.Parse(Console.ReadLine());
        }
    }

    // Метод для виведення елементів вектора на екран
    public void Display()
    {
        Console.Write("Vector: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{ShortArray[i]} ");
        }
        Console.WriteLine();
    }

    // Метод для присвоєння всім елементам масиву деякого значення
    public void Assign(short value)
    {
        for (int i = 0; i < n; i++)
        {
            ShortArray[i] = value;
        }
    }

    // Статичний метод, що підраховує кількість векторів даного типу
    public static uint CountVectors()
    {
        return num_v;
    }

    // Властивість для повернення розмірності вектора (тільки для читання)
    public uint Size
    {
        get { return n; }
    }

    // Властивість для отримання-встановлення значення поля codeError
    public uint ErrorCode
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор, що дозволяє звертатися до масиву
    public short this[int index]
    {
        get
        {
            if (index >= 0 && index < n)
            {
                codeError = 0;
                return ShortArray[index];
            }
            else
            {
                codeError = 10;
                return 0;
            }
        }
        set
        {
            codeError = 10;
        }
    }

    // Перевантаження унарних операцій ++ і --
    public static VectorShort operator ++(VectorShort v)
    {
        for (int i = 0; i < v.n; i++)
        {
            v.ShortArray[i]++;
        }
        return v;
    }

    public static VectorShort operator --(VectorShort v)
    {
        for (int i = 0; i < v.n; i++)
        {
            v.ShortArray[i]--;
        }
        return v;
    }

    // Перевантаження сталих true і false
    public static bool operator true(VectorShort v)
    {
        if (v.n == 0)
            return false;

        foreach (short s in v.ShortArray)
        {
            if (s == 0)
                return false;
        }
        return true;
    }

    public static bool operator false(VectorShort v)
    {
        if (v.n == 0)
            return true;

        foreach (short s in v.ShortArray)
        {
            if (s != 0)
                return false;
        }
        return true;
    }

    // Перевантаження операторів == і !=
    public static bool operator ==(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n)
            return false;

        for (int i = 0; i < v1.n; i++)
        {
            if (v1.ShortArray[i] != v2.ShortArray[i])
                return false;
        }
        return true;
    }

    public static bool operator !=(VectorShort v1, VectorShort v2)
    {
        return !(v1 == v2);
    }

    // Перевантаження арифметичних операторів
    public static VectorShort operator +(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n)
            throw new ArgumentException("Vectors must have the same size");

        VectorShort result = new VectorShort(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result.ShortArray[i] = (short)(v1.ShortArray[i] + v2.ShortArray[i]);
        }
        return result;
    }

    // Перевантаження арифметичних операторів (продовження)
    public static VectorShort operator -(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n)
            throw new ArgumentException("Vectors must have the same size");

        VectorShort result = new VectorShort(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result.ShortArray[i] = (short)(v1.ShortArray[i] - v2.ShortArray[i]);
        }
        return result;
    }

    public static VectorShort operator *(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result.ShortArray[i] = (short)(v.ShortArray[i] * scalar);
        }
        return result;
    }

    public static VectorShort operator /(VectorShort v, ushort divisor)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result.ShortArray[i] = (short)(v.ShortArray[i] / divisor);
        }
        return result;
    }

    public static VectorShort operator %(VectorShort v, short divisor)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result.ShortArray[i] = (short)(v.ShortArray[i] % divisor);
        }
        return result;
    }

    // Перевантаження побітових операторів
    public static VectorShort operator |(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n)
            throw new ArgumentException("Vectors must have the same size");

        VectorShort result = new VectorShort(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result.ShortArray[i] = (short)(v1.ShortArray[i] | v2.ShortArray[i]);
        }
        return result;
    }

    public static VectorShort operator ^(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n)
            throw new ArgumentException("Vectors must have the same size");

        VectorShort result = new VectorShort(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result.ShortArray[i] = (short)(v1.ShortArray[i] ^ v2.ShortArray[i]);
        }
        return result;
    }

    public static VectorShort operator &(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n)
            throw new ArgumentException("Vectors must have the same size");

        VectorShort result = new VectorShort(v1.n);
        for (int i = 0; i < v1.n; i++)
        {
            result.ShortArray[i] = (short)(v1.ShortArray[i] & v2.ShortArray[i]);
        }
        return result;
    }

    public static VectorShort operator >>(VectorShort v, int shift)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result.ShortArray[i] = (short)(v.ShortArray[i] >> shift);
        }
        return result;
    }

    public static VectorShort operator <<(VectorShort v, int shift)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
        {
            result.ShortArray[i] = (short)(v.ShortArray[i] << shift);
        }
        return result;
    }

    // Перевантаження операторів порівняння
    public static bool operator >(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n)
            throw new ArgumentException("Vectors must have the same size");

        for (int i = 0; i < v1.n; i++)
        {
            if (v1.ShortArray[i] <= v2.ShortArray[i])
                return false;
        }
        return true;
    }

    public static bool operator >=(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n)
            throw new ArgumentException("Vectors must have the same size");

        for (int i = 0; i < v1.n; i++)
        {
            if (v1.ShortArray[i] < v2.ShortArray[i])
                return false;
        }
        return true;
    }

    public static bool operator <(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n)
            throw new ArgumentException("Vectors must have the same size");

        for (int i = 0; i < v1.n; i++)
        {
            if (v1.ShortArray[i] >= v2.ShortArray[i])
                return false;
        }
        return true;
    }

    public static bool operator <=(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n)
            throw new ArgumentException("Vectors must have the same size");

        for (int i = 0; i < v1.n; i++)
        {
            if (v1.ShortArray[i] > v2.ShortArray[i])
                return false;
        }
        return true;
    }
}


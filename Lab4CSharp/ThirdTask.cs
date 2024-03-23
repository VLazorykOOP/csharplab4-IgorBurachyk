using System;

public class MatrixShort
{
    protected short[,] ShortArray;
    protected int n, m;
    protected int codeError;
    protected static int num_m;

    // Конструктор без параметрів
    public MatrixShort()
    {
        ShortArray = new short[1, 1];
        n = 1;
        m = 1;
        codeError = 0;
        num_m++;
    }

    // Конструктор з двома параметрами - розмірами матриці
    public MatrixShort(int sizeN, int sizeM)
    {
        ShortArray = new short[sizeN, sizeM];
        n = sizeN;
        m = sizeM;
        codeError = 0;
        num_m++;
    }

    // Конструктор з трема параметрами - розмірами матриці та значенням ініціалізації
    public MatrixShort(int sizeN, int sizeM, short initValue)
    {
        ShortArray = new short[sizeN, sizeM];
        n = sizeN;
        m = sizeM;
        for (int i = 0; i < sizeN; i++)
        {
            for (int j = 0; j < sizeM; j++)
            {
                ShortArray[i, j] = initValue;
            }
        }
        codeError = 0;
        num_m++;
    }

    // Деструктор
    ~MatrixShort()
    {
        Console.WriteLine("Destructor called");
    }

    // Метод для введення елементів матриці з клавіатури
    public void Input()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Enter element [{i},{j}]: ");
                ShortArray[i, j] = short.Parse(Console.ReadLine());
            }
        }
    }

    // Метод для виведення елементів матриці на екран
    public void Display()
    {
        Console.WriteLine("Matrix:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{ShortArray[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    // Метод для присвоєння всім елементам масиву матриці деякого значення
    public void Assign(short value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ShortArray[i, j] = value;
            }
        }
    }

    // Статичний метод, що підраховує кількість матриць даного типу
    public static int CountMatrices()
    {
        return num_m;
    }

    // Властивість для повернення розмірності матриці (доступна тільки для читання)
    public int[] Size
    {
        get { return new int[] { n, m }; }
    }

    // Властивість для отримання-встановлення значення поля codeError (доступні для читання і запису)
    public int ErrorCode
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор з двома індексами, що відповідають індексам масиву
    public short this[int i, int j]
    {
        get
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                codeError = 0;
                return ShortArray[i, j];
            }
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            codeError = -1;
        }
    }

    // Індексатор з одним індексом, що дозволяє звертатися за індексом k до двомірного масиву (k = i*m + j)
    public short this[int k]
    {
        get
        {
            int i = k / m;
            int j = k % m;

            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                codeError = 0;
                return ShortArray[i, j];
            }
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            codeError = -1;
        }
    }

    // Перевантаження унарних операцій
    public static MatrixShort operator ++(MatrixShort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixShort operator --(MatrixShort matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                matrix.ShortArray[i, j]--;
            }
        }
        return matrix;
    }

    // Перевантаження сталих true і false
    public static bool operator true(MatrixShort matrix)
    {
        return matrix.n != 0 && matrix.m != 0;
    }

    public static bool operator false(MatrixShort matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    // Перевантаження логічної операції !
    public static bool operator !(MatrixShort matrix)
    {
        return matrix.n == 0 || matrix.m == 0;
    }

    // Перевантаження побітової операції ~
    public static MatrixShort operator ~(MatrixShort matrix)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortArray[i, j] = (short)~matrix.ShortArray[i, j];
            }
        }
        return result;
    }

    // Перевантаження арифметичних бінарних операцій
    public static MatrixShort operator +(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return matrix1;

        MatrixShort result = new MatrixShort(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix1.ShortArray[i, j] + matrix2.ShortArray[i, j]);
            }
        }
        return result;
    }

    public static MatrixShort operator +(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix.ShortArray[i, j] + scalar);
            }
        }
        return result;
    }

    public static MatrixShort operator -(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return matrix1;

        MatrixShort result = new MatrixShort(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix1.ShortArray[i, j] - matrix2.ShortArray[i, j]);
            }
        }
        return result;
    }

    public static MatrixShort operator -(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix.ShortArray[i, j] - scalar);
            }
        }
        return result;
    }

    public static MatrixShort operator *(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.m != matrix2.n)
            return matrix1;

        MatrixShort result = new MatrixShort(matrix1.n, matrix2.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix2.m; j++)
            {
                for (int k = 0; k < matrix1.m; k++)
                {
                    result.ShortArray[i, j] += (short)(matrix1.ShortArray[i, k] * matrix2.ShortArray[k, j]);
                }
            }
        }
        return result;
    }

    public static MatrixShort operator *(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix.ShortArray[i, j] * scalar);
            }
        }
        return result;
    }

    public static MatrixShort operator /(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.m != matrix2.n)
            return matrix1;

        MatrixShort result = new MatrixShort(matrix1.n, matrix2.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix2.m; j++)
            {
                for (int k = 0; k < matrix1.m; k++)
                {
                    result.ShortArray[i, j] += (short)(matrix1.ShortArray[i, k] / matrix2.ShortArray[k, j]);
                }
            }
        }
        return result;
    }

    public static MatrixShort operator /(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix.ShortArray[i, j] / scalar);
            }
        }
        return result;
    }

    public static MatrixShort operator %(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.m != matrix2.n)
            return matrix1;

        MatrixShort result = new MatrixShort(matrix1.n, matrix2.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                for (int k = 0; k < matrix1.m; k++)
                {
                    result.ShortArray[i, j] += (short)(matrix1.ShortArray[i, k] % matrix2.ShortArray[k, j]);
                }
            }
        }
        return result;
    }

    public static MatrixShort operator %(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix.ShortArray[i, j] % scalar);
            }
        }
        return result;
    }

    public static MatrixShort operator |(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return matrix1;

        MatrixShort result = new MatrixShort(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix1.ShortArray[i, j] | matrix2.ShortArray[i, j]);
            }
        }
        return result;
    }

    public static MatrixShort operator |(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix.ShortArray[i, j] | scalar);
            }
        }
        return result;
    }

    public static MatrixShort operator ^(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return matrix1;

        MatrixShort result = new MatrixShort(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix1.ShortArray[i, j] ^ matrix2.ShortArray[i, j]);
            }
        }
        return result;
    }

    public static MatrixShort operator ^(MatrixShort matrix, short scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix.ShortArray[i, j] ^ scalar);
            }
        }
        return result;
    }

    public static MatrixShort operator >>(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return matrix1;

        MatrixShort result = new MatrixShort(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix1.ShortArray[i, j] >> matrix2.ShortArray[i, j]);
            }
        }
        return result;
    }

    public static MatrixShort operator >>(MatrixShort matrix, uint scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix.ShortArray[i, j] >> (int)scalar);
            }
        }
        return result;
    }

    public static MatrixShort operator <<(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return matrix1;

        MatrixShort result = new MatrixShort(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix1.ShortArray[i, j] << matrix2.ShortArray[i, j]);
            }
        }
        return result;
    }

    public static MatrixShort operator <<(MatrixShort matrix, uint scalar)
    {
        MatrixShort result = new MatrixShort(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result.ShortArray[i, j] = (short)(matrix.ShortArray[i, j] << (int)scalar);
            }
        }
        return result;
    }

    // Перевантаження операцій == та !=
    public static bool operator ==(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return false;

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix1.ShortArray[i, j] != matrix2.ShortArray[i, j])
                    return false;
            }
        }
        return true;
    }
    public static bool operator !=(MatrixShort matrix1, MatrixShort matrix2)
    {
        return !(matrix1 == matrix2);
    }

    // Перевантаження операцій порівняння
    public static bool operator >(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return false;

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix1.ShortArray[i, j] <= matrix2.ShortArray[i, j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator >=(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return false;

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix1.ShortArray[i, j] < matrix2.ShortArray[i, j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator <(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return false;

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix1.ShortArray[i, j] >= matrix2.ShortArray[i, j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator <=(MatrixShort matrix1, MatrixShort matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return false;

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix1.ShortArray[i, j] > matrix2.ShortArray[i, j])
                    return false;
            }
        }
        return true;
    }

    // Метод для підрахунку кількості матриць
    public static int CountMatrices()
    {
        return num_m;
    }

    // Виведення матриці на екран
    public void DisplayMatrix()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(ShortArray[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}



using System;

public class Rectangle
{
    protected int a; // сторона a
    protected int b; // сторона b
    private int color;

    // Конструктор
    public Rectangle(int a, int b, int color)
    {
        this.a = a;
        this.b = b;
        this.color = color;
    }

    // Індексатор
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return a;
                case 1: return b;
                case 2: return color;
                default: throw new IndexOutOfRangeException("Invalid index. Valid indexes are 0, 1, and 2.");
            }
        }
        set
        {
            switch (index)
            {
                case 0: a = value; break;
                case 1: b = value; break;
                case 2: color = value; break;
                default: throw new IndexOutOfRangeException("Invalid index. Valid indexes are 0, 1, and 2.");
            }
        }
    }

    // Перевантаження операторів ++ та --
    public static Rectangle operator ++(Rectangle rect)
    {
        rect.a++;
        rect.b++;
        return rect;
    }

    public static Rectangle operator --(Rectangle rect)
    {
        rect.a--;
        rect.b--;
        return rect;
    }

    // Перевантаження операторів true та false
    public static bool operator true(Rectangle rect)
    {
        return rect.a == rect.b;
    }

    public static bool operator false(Rectangle rect)
    {
        return rect.a != rect.b;
    }

    // Перевантаження оператора *
    public static Rectangle operator *(Rectangle rect, int scalar)
    {
        rect.a *= scalar;
        rect.b *= scalar;
        return rect;
    }

    // Перетворення типу Rectangle в string
    public static implicit operator string(Rectangle rect)
    {
        return $"Rectangle: a = {rect.a}, b = {rect.b}, color = {rect.color}";
    }

    // Перетворення string в тип Rectangle
    public static explicit operator Rectangle(string str)
    {
        string[] parts = str.Split(':');
        string[] dimensions = parts[1].Split(',');
        int a = int.Parse(dimensions[0].Trim().Split('=')[1]);
        int b = int.Parse(dimensions[1].Trim().Split('=')[1]);
        int color = int.Parse(dimensions[2].Trim().Split('=')[1]);
        return new Rectangle(a, b, color);
    }

    // Метод для виведення інформації про прямокутник
    public void Show()
    {
        Console.WriteLine($"Rectangle: a = {a}, b = {b}, color = {color}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rect = new Rectangle(5, 7, 10);
        Console.WriteLine(rect[0]); // Виведе значення сторони а
        Console.WriteLine(rect[1]); // Виведе значення сторони b
        Console.WriteLine(rect[2]); // Виведе значення кольору
        // Console.WriteLine(rect[3]); // Генерує помилку: Invalid index. Valid indexes are 0, 1, and 2.

        rect++;
        rect.Show(); // Виведе збільшені значення сторін a і b

        rect *= 2;
        rect.Show(); // Виведе значення сторін, помножені на 2

        // Перетворення об'єкта типу Rectangle в рядок
        string rectStr = rect;
        Console.WriteLine(rectStr);

        // Перетворення рядка в об'єкт типу Rectangle
        Rectangle rectFromString = (Rectangle)"Rectangle: a = 10, b = 15, color = 20";
        rectFromString.Show();
    }
}

using System;
using System.Text;

public class Program
{
    public struct MyFrac
    {
        public long nom;
        public long denom;

        public MyFrac(long nom_, long denom_)
        {
            if (denom_ < 0)
            {
                nom_ = -nom_;
                denom_ = -denom_;
            }
            long gcd = GCD(Math.Abs(nom_), Math.Abs(denom_));
            nom = nom_ / gcd; 
            denom = denom_ / gcd;
        }
        public override string ToString()
        {
            return $"{nom}/{denom}";
        }
        private static long GCD(long a, long b) //НСД
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
    public static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.Write("Введіть чисельник першого дробу:");
        long nom1 = long.Parse(Console.ReadLine());
        Console.Write("Введіть знаменник першого дробу:");
        long denom1 = long.Parse(Console.ReadLine());
        MyFrac f1 = new MyFrac(nom1, denom1);

        Console.Write("Введіть чисельник другого дробу:");
        long nom2 = long.Parse(Console.ReadLine());
        Console.Write("Введіть знаменник другого дробу:");
        long denom2 = long.Parse(Console.ReadLine());
        MyFrac f2 = new MyFrac(nom2, denom2);

        Console.WriteLine($"{f1} + {f2} = {Plus(f1, f2)}");
        Console.WriteLine($"{f1} - {f2} = {Minus(f1, f2)}");
        Console.WriteLine($"{f1} * {f2} = {Multiply(f1, f2)}");
        Console.WriteLine($"{f1} / {f2} = {Divide(f1, f2)}");

        Console.WriteLine($"Рядкове представлення: {f1}");
        Console.WriteLine($"Рядкове представлення з цілою частиною {f1} = {ToStringWithLongPart(f1)}");
        Console.WriteLine($"Дійсне значення {f1} = {DoubleValue(f1)}");

        Console.WriteLine("Введіть значення для обчислення результату CalcExpr1:");
        long number1 = long.Parse(Console.ReadLine());
        Console.WriteLine($"Результат CalcExpr1({number1}): {CalcExpr1(number1)}");

        Console.WriteLine("Введіть значення для обчислення результату CalcExpr2:");
        long number2 = long.Parse(Console.ReadLine());
        Console.WriteLine($"Результат CalcExpr2({number2}): {CalcExpr2(number2)}");
    }
    public static string ToStringWithLongPart(MyFrac f)
    {
        long integerPart = f.nom / f.denom;
        if (integerPart != 0)
        {
            if (f.nom < 0)
            {
                f.nom *= -1;
            }
            else if (f.denom < 0)
            {
                f.denom *= -1;
            }
        }
        MyFrac fractionalPart = new MyFrac(f.nom % f.denom, f.denom);

        if (f.nom % f.denom == 0)
        {
            return $"({integerPart})";
        }
        else if (integerPart == 0)
        {
            return $"({fractionalPart})";
        }
        else return $"({integerPart} {fractionalPart})";
    }
    public static double DoubleValue(MyFrac f)
    {
        return (double)f.nom / f.denom;
    }

    public static MyFrac Plus(MyFrac f1, MyFrac f2)
    {
        long numerator = f1.nom * f2.denom + f1.denom * f2.nom;
        long denominator = f1.denom * f2.denom;
        return new MyFrac(numerator, denominator);
    }

    public static MyFrac Minus(MyFrac f1, MyFrac f2)
    {
        long numerator = f1.nom * f2.denom - f1.denom * f2.nom;
        long denominator = f1.denom * f2.denom;
        return new MyFrac(numerator, denominator);
    }

    public static MyFrac Multiply(MyFrac f1, MyFrac f2)
    {
        long numerator = f1.nom * f2.nom;
        long denominator = f1.denom * f2.denom;
        return new MyFrac(numerator, denominator);
    }

    public static MyFrac Divide(MyFrac f1, MyFrac f2)
    {
        long numerator = f1.nom * f2.denom;
        long denominator = f1.denom * f2.nom;
        return new MyFrac(numerator, denominator);
    }

    public static MyFrac CalcExpr1(long n)
    {
        return new MyFrac(n, n + 1);
    }

    public static MyFrac CalcExpr2(long n)
    {
        return new MyFrac(n + 1, 2 * n);
    }
}


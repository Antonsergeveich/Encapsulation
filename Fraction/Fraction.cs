using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    internal class Fraction
    {
        public int Integer { get; set; }
        //Автосвойства, не требуют объявления переменной, поскольку сами неявно её объявляют.
        public int Numerator { get; set; }
        int denominator;
        // Обычные свойства, которые применяются к переменной 'denominator':
        public int Denominator
        {
            get => denominator;
            set => denominator = value == 0 ? 1 : value;
            // Если метод реализуется одним выражением его можно реализовать без фигурных скобок
            // Реализация пишется после знака '=>'
            // https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/lambda-operator
            // '=>' подразумевает возврат указанного значения
        }

        //            Constructors:

        public Fraction()
        {
            Console.WriteLine($"DefConstructor:\t{GetHashCode()}");
        }
        public Fraction(int integer)
        {
            this.Integer = integer;
            Console.WriteLine($"1ArgConstructor:{GetHashCode()}");
            //https://learn.microsoft.com/ru-ru/dotnet/api/system.object.gethashcode?view=net-8.0
        }
        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
            Console.WriteLine($"Constructor:\t{GetHashCode()}");
        }
        public Fraction(int integer, int numerator, int denominator) 
        {
            this.Integer = integer;
            this.Numerator = numerator;
            this.Denominator = denominator;
            Console.WriteLine($"Constructor:\t{GetHashCode()}");
        }
        public Fraction(Fraction other)
        {
            this.Integer = other.Integer;
            this.Numerator = other.Numerator;
            this.Denominator = other.Denominator;
            Console.WriteLine($"CopyConstructor:{GetHashCode()}");
        }

        ~Fraction()
        {
            Console.WriteLine($"Destructor:\t{GetHashCode()}");
        }

        //              Operators:
        public static Fraction operator* (Fraction l, Fraction r)
        {
            Fraction left = l.Improper();
            Fraction right = r.Improper();
            Fraction res = new Fraction
                (
                left.Numerator * right.Numerator,
                left.Denominator * right.Denominator
                );
            return res;
        }
        public static Fraction operator /(Fraction l, Fraction r)
        {
            return l.Division(r);
        }
        public static Fraction operator +(Fraction l, Fraction r)
        {
            return  l.Plus(r);    
        }
        public static Fraction operator -(Fraction l, Fraction r)
        {
            return l.Subtraction(r);
        }

        //              Methods:
        public Fraction Division(Fraction other)
        {
            if(Integer > 0)this.Improper();
            if(other.Integer > 0)other.Improper();
            int resNumerator = Numerator * other.Denominator;
            int resDenominator = Denominator * other.Numerator;
            return new Fraction(resNumerator,resDenominator);
        }
        public Fraction Plus(Fraction other)
        {
            if (Integer > 0) this.Improper();
            if (other.Integer > 0) other.Improper();
            int resNumerator;
            int resDenominator = Denominator;
            if (Denominator == other.Denominator) 
            {
                resNumerator = Numerator + other.Numerator;        
            }
            else 
            {
                resDenominator = Denominator * other.Denominator;
                resNumerator = Numerator * other.Denominator + other.Numerator * Denominator;
            }
            return new Fraction(resNumerator, resDenominator);
        }
        public Fraction Subtraction(Fraction other)
        {
            if (Integer > 0) this.Improper();
            if (other.Integer > 0) other.Improper();
            int resNumerator;
            int resDenominator = Denominator;
            if (Denominator == other.Denominator)
            {
                resNumerator = Numerator - other.Numerator;
            }
            else
            {
                resDenominator = Denominator * other.Denominator;
                resNumerator = Numerator * other.Denominator - other.Numerator * Denominator;
            }
            return new Fraction(resNumerator, resDenominator);
        }
        Fraction Proper()
        {
            Fraction copy = new Fraction(this);
            copy.Integer += copy.Numerator / copy.Denominator;
            copy.Numerator %= copy.Denominator;
            return copy;
        }
        Fraction Improper() 
        {
            Fraction copy = new Fraction(this);
            copy.Numerator += copy.Integer * copy.Denominator;
            copy.Integer = 0;
            return copy;
        }
        public void Print()
        {
            if (Integer != 0) Console.Write(Integer);
            if (Numerator != 0)
            {
                if (Integer != 0) Console.Write("(");
                Console.Write($"{Numerator} / {Denominator}");
                if (Integer != 0) Console.Write(")");
            }
            else if (Integer == 0) Console.Write(0);
            Console.WriteLine();
        }
        public override string ToString()
        {
            // return base.ToString();
            string print = "";
            if (Integer != 0) print += Integer;
            if (Numerator != 0)
            {
                if (Integer != 0) print += "(";
                print += $"{Numerator} / {Denominator}";
                if (Integer != 0) print += ")";
            }
            else if (Integer == 0) print += 0;
            return print;
        }
    }
}

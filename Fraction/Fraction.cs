using System;
using System.Collections.Generic;
using System.Linq;
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
            this.Integer=integer;
            this.Numerator = numerator;
            this.Denominator = denominator;
            Console.WriteLine($"Constructor:\t{GetHashCode()}");
        }

        ~Fraction()
        {
            Console.WriteLine($"Destructor:\t{GetHashCode()}");
        }

        //              Methods:
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

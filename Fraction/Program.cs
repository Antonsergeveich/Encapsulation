//#define CONSTRUCTORS_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if CONSTRUCTORS_CHECK
            Fraction A = new Fraction();
            A.Print();
            Console.WriteLine(A);

            Fraction B = new Fraction(5);
            B.Print();
            Console.WriteLine(B);

            Fraction C = new Fraction(1, 2);
            C.Print();
            Console.WriteLine(C);

            Fraction D = new Fraction(2, 3, 4);
            D.Print();
            Console.WriteLine(D); 
#endif

            Fraction A = new Fraction(2, 3, 4);
            Fraction B = new Fraction(3, 4, 5);
            Fraction C = new Fraction(A * B);
            Fraction D = new Fraction();
            Fraction E = new Fraction();
            A.Print();
            B.Print();
            C.Print();
            Console.WriteLine($"Умножение: \t{E = B * A}");
            Console.WriteLine($"Умножение: \t{E = B * 2}");
            Console.WriteLine($"Деление: \t{D = A / B} ");
            Console.WriteLine($"Сложение: \t{C = A + B}"); 
            Console.WriteLine($"Вычитание: \t{C = B - A}");
            Console.WriteLine($"Increment = \t{A++}");
            Console.WriteLine($"Decrement = \t{--A}");
            Console.WriteLine($" += \t{A += B}");
            Console.WriteLine($" -= \t{A -= B}");
            Console.WriteLine($" *= \t{A *= B}");
            Console.WriteLine($" /= \t{A /= B}");
            Console.WriteLine($" == \t{A == C}");
            Console.WriteLine($" != \t{A != C}");
            Console.WriteLine($" >  \t{A > C}");
            Console.WriteLine($" <  \t{A < C}");
            Console.WriteLine($" >= \t{A >= C}");
            Console.WriteLine($" <= \t{A <= C}");
        }
    }
}

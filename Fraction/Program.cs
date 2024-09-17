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
            Fraction A = new Fraction();
            A.Print();

            Fraction B = new Fraction(5);
            B.Print();

            Fraction C = new Fraction(1,2);
            C.Print();
        }
    }
}

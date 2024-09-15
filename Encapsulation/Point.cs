using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    internal class Point
    {
        double x;
        double y;
        public double X
        {
            get { return x; }
            set
            { //if(value...)...
                x = value;      //value открывает доступ к переданному значению
            }
        }
        public double Y { get { return y; } set { y = value; } }
        public double GetX()
        { return x; }
        public double GetY() { return y; }
        public void SetX(double x) { this.x = x; } // В языке C# отсутствуют указатели, а следовательно отсутствует оператор '->'
        public void SetY(double y) { this.y = y; }

        //           Methods:
        public void Print() { Console.WriteLine($"X = {x}, Y = {y}"); }

    }
}
/*
  ------------------------------
prived
public
protected
internal
protected internal
  -------------------------------
Properties(Свойства)
Cвойства - это синтаксическая конструкция которая объединяет в себе Get и Set методы.
Свойства называют так же как и переменную для которой оно предназначено, но переменная член называется с маленькой буквы а свойства с большой
Свойства также используется ключевое слово value, которое означает принимаемое значение
Свойства позволяйт использовать get set методы как обычные переменные в классе и при этом использовать фильтрацию данных

  -------------------------------
*/
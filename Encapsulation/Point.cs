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
        //public double X
        //{
        //    get { return x; }
        //    set
        //    { //if(value...)...
        //        x = value;      //value открывает доступ к переданному значению
        //    }
        //}
        //Если фильтрация данных не требуется можно использовать авто свойства.
        //При этом переменная член не объявляется явным образом,
        //а компилятор создаёт её не явным образом при объявлении свойств
        public double X { get; set; } // Автосвойства для 'X'
        //public double Y { get { return y; } set { y = value; } }
        public double Y { get; set; } // Автосвойства для 'Y'
        //public double GetX()
        //{ return x; }
        //public double GetY() { return y; }
        //public void SetX(double x) { this.x = x; } // В языке C# отсутствуют указатели, а следовательно отсутствует оператор '->'
        //public void SetY(double y) { this.y = y; }

        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
            Console.WriteLine($"Constructor:{this.GetHashCode()}");
        }
        public Point(Point other)
        {
            this.X = other.X;
            this.Y = other.Y;
            Console.WriteLine($"CopyConstructor:{this.GetHashCode()}");
        }
        ~Point() //Destructor in C# is always private
        {
            Console.WriteLine($"Destructor:\t{this.GetHashCode()}");
        }

        //            Operators:

        public static Point operator+(Point left, Point right)
        {
            Point res = new Point();
            res.X = left.X + right.X;
            res.Y = left.Y + right.Y;
            return res;
        }
        public static Point operator ++(Point obj)
        {
            obj.X++;
            obj.Y++;
            return obj;
        }
        public static Point operator --(Point obj)
        {
            obj.X--;
            obj.Y--;
            return obj;
        }

        //https://learn.microsoft.com/ru-ru/dotnet/api/system.gc.collect?view=net-8.0
        //Когда на динамическую память не остаётся ни единой ссылки её грохает Garbage Collector
        //Т.е. берёт эту динамическую память и помечает что она свободна,
        //её можно использовать другим приложением;
        //https://learn.microsoft.com/ru-ru/dotnet/standard/garbage-collection/fundamentals

        //           Methods:
        public void Print() { Console.WriteLine($"X = {X}, Y = {Y}"); }
        public double Distance(Point other)
        {
            double x_distance = this.X - other.X;
            double y_distance = this.Y - other.Y;
            //https://learn.microsoft.com/ru-ru/dotnet/api/system.math?view=net-8.0
            double distance = Math.Sqrt(x_distance * x_distance + y_distance * y_distance);
            return distance;
        }

        public static double Distance2(Point A, Point B)
        {
            double x_distance = A.X - B.X;
            double y_distance = A.Y - B.Y;
            double distance = Math.Sqrt(x_distance * x_distance + y_distance * y_distance);
            return distance;
        }
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
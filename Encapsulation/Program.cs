//#define CONSTRUCTORS_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if CONSTRUCTORS_CHECK
            //Stack - статическая память;
            //Heap - динамическая память;
            //В C# объекты хранятся только в динамической памяти => объект можно создать только при помощи оператора new
            //Ссылка - это разъименованный указатель;
            // Оператор new вызывает конструктор класса и
            // возвращает ссылку на выделенную память(адрес выделенной памяти)
            //A.SetX(2);
            //A.SetY(3);
            //Console.WriteLine($"X = {A.GetX()}, Y = {A.GetY()}");
            //A.Print();
            //Не явный конструктор по умолчанию сразу же удаляется из класса
            //если мы написали хотя бы один явный конструктор(не важно какой);

            Point A = new Point(10, 8);
            A.Print();
            Point B = new Point(10, 12);
            B.Print();
            Console.WriteLine($"Расстояние от 'A' до 'B' = {A.Distance(B)}");
            Console.WriteLine($"Расстояние между точками 'A' и 'B' = {Distance2(A, B)}");
            Point C = new Point(10, 8);
            C.Print();
            Point D = C; // Здесь копируется не объект, а ссылка на него
            D.Print();
            D.X = 111;
            D.Print();
            // Объекты копируются следующим образом:
            // Скопировать объект можно толь ко через оператор 'new'
            Point E = new Point(D);// Здесь вызывается конструктор копирования
            E.Print();
            E.X = 11;
            D.Print();

            E = new Point(B);
            E.Print(); 
#endif
            Point A = new Point(2, 3);
            Point B = new Point(7, 8);
            Point C = new Point(A + B);
            C.Print();
            for (Point i = new Point(); i.X < 10; ++i) { i.Print(); }
            for (Point i = new Point(20,20); i.X > 10; --i) { i.Print(); }

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

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
           
            Point A = new Point(10,8);
            A.Print();
            Point B = new Point(10,12);
            B.Print();
            Console.WriteLine($"Расстояние от 'A' до 'B' = {A.Distance(B)}");
            Console.WriteLine($"Расстояние между точками 'A' и 'B' = {Distance2(A, B)}");
        }

        static public double Distance2(Point A, Point B)
        {
            double x_distance = A.X - B.X;
            double y_distance = A.Y - B.Y;
            double distance = Math.Sqrt(x_distance * x_distance + y_distance * y_distance);
            return distance;
        }
       
    }
}

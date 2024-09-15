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
            Point A = new Point();
            // Оператор new вызывает конструктор класса и
            // возвращает ссылку на выделенную память(адрес выделенной памяти)
            A.SetX(2);
            A.SetY(3);
            Console.WriteLine($"X = {A.GetX()}, Y = {A.GetY()}");
            A.Print();

            Point B = new Point();
            B.X = 7;
            B.Y = 8;
            B.Print();  
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        public static Fraction operator *(Fraction l, Fraction r)
        {
            //Fraction left = l.Improper();
            //Fraction right = r.Improper();
            //Fraction res = new Fraction
            //    (
            //    left.Numerator * right.Numerator,
            //    left.Denominator * right.Denominator
            //    );
            //return res;
            return new Fraction
            (
                l.Improper().Numerator * r.Improper().Numerator,
                l.Improper().Denominator * r.Improper().Denominator
            ).Reduce().Proper();
        }
        public static Fraction operator *(Fraction l, int value)
        {
            Fraction res = new Fraction(value * l.Numerator, l.Denominator);
            return res;
        }
        //public static Fraction operator /(Fraction l, Fraction r)
        //{
        //    Fraction left = l.Improper();
        //    Fraction right = r.Improper();
        //    int resNumerator = left.Numerator * right.Denominator;
        //    int resDenominator = left.Denominator * right.Numerator;
        //    return new Fraction(resNumerator, resDenominator);
        //}
        public static Fraction operator /(Fraction l, Fraction r)
        {
            return l * r.Inverted();
        }
        public static Fraction operator +(Fraction l, Fraction r)
        {
            Fraction left = l.Improper();
            Fraction right = r.Improper();
            int resNumerator;
            int resDenominator = left.Denominator;
            if (left.Denominator == right.Denominator)
            {
                resNumerator = left.Numerator + right.Numerator;
            }
            else
            {
                resDenominator = left.Denominator * right.Denominator;
                resNumerator = left.Numerator * right.Denominator + right.Numerator * left.Denominator;
            }
            return new Fraction(resNumerator, resDenominator);
        }
        public static Fraction operator -(Fraction l, Fraction r)
        {
            Fraction left = l.Improper();
            Fraction right = r.Improper();
            int resNumerator;
            int resDenominator = left.Denominator;
            if (l.Denominator == right.Denominator)
            {
                resNumerator = left.Numerator - right.Numerator;
            }
            else
            {
                resDenominator = left.Denominator * right.Denominator;
                resNumerator = left.Numerator * right.Denominator - right.Numerator * left.Denominator;
            }
            return new Fraction(resNumerator, resDenominator);
        }
        public static Fraction operator ++(Fraction obj)
        {
            obj.Proper();
            obj.Integer++;
            return obj;
        }
        public static Fraction operator --(Fraction obj)
        {
            obj.Proper();
            obj.Integer--;
            return obj;
        }
        //https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading
        //                Comparison operators:
        public static bool operator >(Fraction left, Fraction right)
        {
            return
                left.Improper().Numerator * right.Improper().Denominator > 
                right.Improper().Numerator * left.Improper().Denominator;
        }
        public static bool operator <(Fraction left, Fraction right)
        {
            return
                left.Improper().Numerator * right.Improper().Denominator <
                right.Improper().Numerator * left.Improper().Denominator;
        }
        //public static bool operator ==(Fraction left, Fraction right)
        //{
        //    return
        //        left.Improper().Numerator * right.Improper().Denominator ==
        //        right.Improper().Numerator * left.Improper().Denominator;
        //}
        //public static bool operator !=(Fraction left, Fraction right)
        //{
        //    return
        //        left.Improper().Numerator * right.Improper().Denominator !=
        //        right.Improper().Numerator * left.Improper().Denominator;
        //}
        public static bool operator ==(Fraction left, Fraction right)
            => ((double)left.Numerator / (double)left.Denominator == (double)right.Numerator / (double)right.Denominator);
        public static bool operator !=(Fraction left, Fraction right)
            => ((double)left.Numerator / (double)left.Denominator != (double)right.Numerator / (double)right.Denominator);
        //public static bool operator >(Fraction left, Fraction right)
        //    => (left.Numerator / left.Denominator > right.Numerator / right.Denominator);
        //public static bool operator <(Fraction left, Fraction right)
        //    => (left.Numerator / left.Denominator < right.Numerator / right.Denominator);
        public static bool operator >=(Fraction left, Fraction right)
            => !(left < right);//(left > right || left == right);
        public static bool operator <=(Fraction left, Fraction right)
            => !(left > right);//(left < right || left == right);
        //              Methods:
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
        Fraction Inverted()
        {
            Fraction inverted = new Fraction(this).Improper();
            (inverted.Numerator, inverted.Denominator) = (inverted.Denominator, inverted.Numerator);
            return inverted;
        }
        public Fraction Reduce()
        {
            int more, less, rest;
            if (Numerator > Denominator)
            {
                more = Numerator;
                less = Denominator;
            }
            else
            {
                less = Numerator;
                more = Denominator;
            }
            do 
            {
                rest = more % less;
                more = less;
                less = rest;
            }while(rest > 0);
            int GCD = more; //Greatest Common Divisor - Наибольший общий делитель

            Numerator/=GCD;
            Denominator/=GCD;

            return this;

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

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
        public double GetX()
        { return x; }
        public double GetY() { return y; }
        public void SetX(double x) { this.x = x; }
        public void SetY(double y) {  this.y = y; }
    }
}

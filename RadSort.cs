using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull_3
{
    class RadSort : IComparer<Point>
    {
        Point a;

        public RadSort(Point a)
        {
            this.a = a;
        }
        
        public int Compare(Point b, Point c)
        {
            int cw = a.X * b.Y - b.X * a.Y + b.X * c.Y - c.X * b.Y + c.X * a.Y - a.X * c.Y;
            if(cw == 0)
            {
                double d1 = GetDistTo(b);
                double d2 = GetDistTo(c);
                return d1.CompareTo(d2);
            }
            return cw;
        }

        public double GetDistTo(Point p)
        {
            int dX = p.X - a.X;
            int dY = p.Y - a.Y;
            return Math.Sqrt(dX * dX + dY * dY);
        }
    }
}

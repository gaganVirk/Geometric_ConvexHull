using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();
            List<Point> hull = new List<Point>();
            Point pivot = new Point(int.MaxValue, int.MaxValue);

            TextReader stdIn = Console.In;
            Console.SetIn(new StreamReader("data.txt"));

            int nA = int.Parse(Console.ReadLine());
            for(int i = 0; i < nA; i++)
            {
                string line = Console.ReadLine();
                string[] parts = line.Split(' ');
                int one = int.Parse(parts[0]);
                int two = int.Parse(parts[1]);
                if(pivot.X > one)
                {
                    if(pivot.Y > one)
                    {
                        pivot = new Point(one, two);
                    }
                }
                points.Add(new Point(one, two));
            }
            points.Sort(new RadSort(pivot));

            hull.Clear();
            hull.Add(pivot);
            hull.Add(points[0]);
            points.Remove(points[0]);

            while(points.Count > 0)
            {
                hull.Add(points[0]);
                points.Remove(points[0]);
                while(!IsValid())
                {
                    hull.Remove(hull[hull.Count - 2]);
                }
            }
            hull.Add(pivot);

            for(int i = hull.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(hull[i].X + " " + hull[i].Y);
            }
            

            bool IsValid()
            {
                while(hull.Count < 3)
                {
                    return true;
                }
                Point a = hull[hull.Count - 3];
                Point b = hull[hull.Count - 2];
                Point c = hull[hull.Count - 1];
                int cw = a.X * b.Y - b.X * a.Y + b.X * c.Y - c.X * b.Y + c.X * a.Y - a.X * c.Y;
                return cw < 0;
            }

            Console.SetIn(stdIn);
            Console.ReadLine();
        }
    }
}

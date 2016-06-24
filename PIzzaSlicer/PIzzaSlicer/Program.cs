using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIzzaSlicer
{
    class Program
    {
        static void Main(string[] args)
        {

            var numFourSlices = 0;
            var numThreeSlices = 0;
            Random Random = new Random(Guid.NewGuid().GetHashCode());
            //we will imagine that the pizza circumfrence is 1, we will pick 4 points from the start 0 to the end 1
            for (int i = 0; i < 100000000; i++)
            {
                var p1 = Random.NextDouble(); var p2 = Random.NextDouble(); var p3 = Random.NextDouble(); var p4 = Random.NextDouble();

                //second line intersects first line
                if (p3.IsBetween(p1, p2) && p4.OutSide(p1, p2))
                    numFourSlices++;
                if (p3.OutSide(p1, p2) && p4.IsBetween(p1, p2))
                    numFourSlices++;

                //Second line does not intersect first line
                if (p3.IsBetween(p1, p2) && p4.IsBetween(p1, p2))
                    numThreeSlices++;
                if (p3.OutSide(p1, p2) && p4.OutSide(p1, p2))
                    numThreeSlices++;
            }
            var ratio = (double)numThreeSlices / (double)numFourSlices;
            Console.WriteLine($"Three Slices to Four is {ratio}:1");
            Console.ReadLine();
        }


    }
    public static class DoubleExtensions
    {
        public static bool IsBetween(this double x, double first, double second)
        {
            var bigger = first > second ? first : second;
            var smaller = first < second ? first : second;
            return (smaller < x) && (x < bigger);
        }

        public static bool OutSide(this double x, double first, double second)
        {
            var bigger = first > second ? first : second;
            var smaller = first < second ? first : second;
            return (smaller > x) || (x > bigger);
        }

    }
}

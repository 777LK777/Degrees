using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryLib;

namespace Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Angle> angles = new List<Angle>
            {
                new Angle(0),
                new Angle(90),
                new Angle(180),
                new Angle(270),
                new Angle(360)
            };

            string pr = "\t\t";
            Console.WriteLine($"Angle{pr}SIN{pr}COS");
            angles.ForEach(ang =>
            {
                Console.WriteLine(ang.ToString() + pr + ang.Sin + pr + ang.Cos);
            });


            



            Console.ReadKey();
        }
    }
}

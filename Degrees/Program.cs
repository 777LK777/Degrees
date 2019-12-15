using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Degree;

namespace Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Angle obj1 = new Angle(0, 0, 0);
            Console.WriteLine(obj1.ToString());



            Console.WriteLine();

            Angle[] obj =
            {
                new Angle(0, 0, 0),
                new Angle(30, 0, 0),
                new Angle(60, 0, 0),
                new Angle(90, 0, 0),
            };

            string result = string.Empty;

            foreach (var g in obj)
            {
                Console.WriteLine(
                    g.Sin + "\t" +
                    g.Cos + "\t" +
                    g.ToString());
            }

            Angle angle = new Angle(415, 55, 30);

            

            Console.WriteLine(angle.ToString());

            Angle angle1 = new Angle(415.5);

            Console.WriteLine(angle1.ToString());

            Angle ang1 = new Angle(15);
            Angle ang2 = new Angle(15, 20, 30);

            Console.WriteLine("That " + (ang1 + ang2).ToString());

            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("That " + (ang1 - ang2).ToString());

            Console.ReadKey();

            double a = 0;

            for(int i = 0; i < 100000; i++)
            {
                if (i % 100 == 0) Console.ReadKey();
                Angle a1 = new Angle(a);
                Console.WriteLine(a1.ToString() + "\t\t" + a1.Sin + "\t\t" + a1.Cos);
                a += 0.1;
            }

            

            Console.ReadKey();
        }
    }
}

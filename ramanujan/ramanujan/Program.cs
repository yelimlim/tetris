using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ramanujan
{
    class Program
    {
        static void Main(string[] args)
        {

            int a;
            int b;
            int c;
            int d;

            int ramanujan;

            for (a = 0; a < 100; a++)
            {
                for (c = 0; c < a; c++)
                {
                    /*if (a == c)
                    {
                        continue;
                    }*/

                    for (b = 0; b < a; b++)
                    {
                        for (d = 0; d < c; d++)
                        {

                            int x = a * a * a + b * b * b;
                            int y = c * c * c + d * d * d;

                            if (x == y)
                            {
                                ramanujan = x;

                                Console.WriteLine("{0} {1} {2} {3} {4}", a, b, c, d, ramanujan);
                                Console.WriteLine("");
                                Thread.Sleep(500);

                            }
                        }
                    }

                }
            }
        }
    }
}

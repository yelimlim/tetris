using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,]mainB=new int[4,4];
            int count=1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mainB[i,j]=count;
                    count++;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0}\t", mainB[i, j]);
                }
                Console.WriteLine();
            }



            int[,] temp = new int[4, 4];
            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b < 4; b++)
                {
                    temp[a, b] = mainB[3 - b, a];
                }
            }
            mainB = temp;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0}\t",mainB[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}

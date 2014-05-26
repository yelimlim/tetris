using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        public static Stack track = new Stack();

        public static bool check(int right, int down, int left, int up)
        {
            if (right != 0 && down != 0 && left != 0 && up != 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        static void Main(string[] args)
        {
            int[,] num = new int[,] {
				{-1,-1,-1,-1,-1,-1,-1,-1},
				{-1,1,0,0,0,0,0,-1},
				{-1,0,0,0,0,0,0,-1},
				{-1,0,0,0,0,0,0,-1},
				{-1,0,0,0,0,0,0,-1},
				{-1,0,0,0,0,0,0,-1},
				{-1,-1,-1,-1,-1,-1,-1,-1}
			};

            int x = 1;
            int y = 1;

            int loop = 1;

            Random Random = new Random();

            int random = -1;


            while (x < 6 && y < 7)
            {
                Console.Clear();
                for (int i = 0; i < 7; i++)
                {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0}\t", num[i, j]);
                }
                Console.WriteLine("");
                }
                Console.WriteLine("");
 
                Thread.Sleep(500);

                int p = x;
                int q = y;

                int right = num[p, ++q];
                q--;
                int down = num[++p, q];
                p--;
                int left = num[p, --q];
                q++;
                int up = num[--p, q];
                p++;



                /*Console.WriteLine("");
                Console.Write(right);
                Console.Write(down);
                Console.Write(left);
                Console.Write(up);
                Console.WriteLine("");*/

                bool look = check(right, down, left, up);

                /* Console.WriteLine("");
                 Console.WriteLine(look);
                 Console.WriteLine("");*/

                if (x == 5 && y == 6 && loop == 30)
                {
                    Console.WriteLine("End");
                    return; 
                }


                if (look == false)
                {

                    loop--;

                    int back = (int)track.Pop();

                    if (back == 0)
                    {
                        y--;
                    }
                    else if (back == 1)
                    {
                        x--;
                    }
                    else if (back == 2)
                    {
                        y++;
                    }
                    else if (back == 3)
                    {
                        x++;
                    }
                    else if (back == -1)
                    {
                        break;
                    }

                    

                }

                else if (look == true)
                {
                    random = Random.Next(0, 4);

                    int a = x;
                    int b = y;

                    if (random == 0)
                    {
                        b++;
                    }
                    else if (random == 1)
                    {
                        a++;
                    }
                    else if (random == 2)
                    {
                        b--;
                    }
                    else if (random == 3)
                    {
                        a--;
                    }

                    if (num[a, b] == 0)
                    {
                        x = a;
                        y = b;

                        loop++;

                        num[x, y] = loop;

                        track.Push(random);

                        
                    }



                }


            }


        }
    }
}

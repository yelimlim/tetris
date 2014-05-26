using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class MainClass
    {
        public static int[] track = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        public static void push(int direction, int loop)
        {
            track[loop] = direction;
        }

        public static int Out(int loop)
        {
            if (loop > -1)
            {
                return track[loop];
            }
            else
            {
                return 7;
            }
        }

        public static bool check(string right, string down, string left, string up)
        {
            if (right != "0" && down != "0" && left != "0" && up != "0")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static void Main(string[] args)
        {
            string[,] maze = new string[,] {
				{"1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1"},
				{"1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1"},
				{"1", "0", "1", "1", "1", "1", "1", "1", "1", "0", "1"},
				{"1", "0", "0", "0", "0", "0", "0", "0", "1", "0", "1"},
				{"1", "0", "1", "1", "1", "1", "1", "1", "1", "0", "1"},
				{"1", "0", "1", "0", "0", "0", "0", "0", "0", "0", "1"},
				{"1", "0", "1", "0", "1", "0", "1", "1", "1", "0", "1"},
				{"1", "0", "1", "0", "1", "0", "1", "0", "0", "0", "1"},
				{"1", "0", "1", "1", "1", "0", "1", "1", "1", "0", "1"},
				{"1", "0", "0", "0", "0", "0", "0", "0", "1", "9", "1"},
				{"1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1"}
			};

            int a = 1;
            int b = 1;

            maze[a, b] = "*";

            int random = 0;

            int loop = 0;

            Random Random = new Random();

            while (a < 10 && b < 10)
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        Console.Write("{0}", maze[i, j]);

                    }
                    Console.WriteLine("");
                }
                Thread.Sleep(30);
                Console.WriteLine("");

                int p = a;
                int q = b;

                string right = maze[p, ++q];
                q--;
                string down = maze[++p, q];
                p--;
                string left = maze[p, --q];
                q++;
                string up = maze[--p, q];
                p++;



                /*Console.WriteLine("");
                Console.Write(right);
                Console.Write(down);
                Console.Write(left);
                Console.Write(up);
                Console.WriteLine("");*/

                if (down == "9")
                {
                    break;
                }

                bool look = check(right, down, left, up);

                /* Console.WriteLine("");
                 Console.WriteLine(look);
                 Console.WriteLine("");*/

                if (a == 10 && b == 10)
                { return; }






                if (look == false)
                {
                    maze[a, b] = "1";

                    loop--;

                    int back = Out(loop);

                    if (back == 0)
                    {
                        b--;
                    }
                    else if (back == 1)
                    {
                        a--;
                    }
                    else if (back == 2)
                    {
                        b++;
                    }
                    else if (back == 3)
                    {
                        a++;
                    }
                    else if (back == -1)
                    {
                        break;
                    }

                }

                else if (look == true)
                {
                    random = Random.Next(0, 4);

                    int x = a;
                    int y = b;

                    if (random == 0)
                    {
                        y++;
                    }
                    else if (random == 1)
                    {
                        x++;
                    }
                    else if (random == 2)
                    {
                        y--;
                    }
                    else if (random == 3)
                    {
                        x--;
                    }

                    if (maze[x, y] == "0")
                    {
                        a = x;
                        b = y;

                        maze[a, b] = "*";

                        push(random, loop);

                        loop++;
                    }



                }


            }

            Console.WriteLine("End");

        }
    }
}


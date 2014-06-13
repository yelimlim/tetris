using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{

   /* class turn
    {
        public int garo;
        public int sero;
        public int color;

        public void turn(int garo, int sero, int num)
        {
            this.garo = garo;
            this.sero = sero;

            if (num % 2 == 1)
            {
                this.color = 1;
            }
            else if (num % 2 == 0)
            {
                this.color = 2;
            }
        }
    }*/

    class Program
    {
        public static int[,]  board = new int[19,19];

        static void Main(string[] args)
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    board[i, j] = 0;
                }
            }

            string win = "시작";
            
            int num = 1;


            while (win == "시작")
            {
            Console.WriteLine("가로?");
            int garo = int.Parse(Console.ReadLine());
            Console.WriteLine("세로?");
            int sero = int.Parse(Console.ReadLine());

            

            if (num % 2 == 1)
            {
                board[garo, sero] = 1;
            }
            else if (num % 2 == 0)
            {
                board[garo, sero] = 2;
            }
            
            num++;

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    if (board[i, j] != 0)
                    {
                        int p = board[i, j];

                        int x = i + 5;
                        int y = j + 5;
                        int z = i - 5;
                        
                        int a;
                        int b;

                        for (a = i; a < x; a++)
                        {
                            bool re = p == board[a, j];
                            if (re == false)
                            {
                                break;
                            }

                            
                        }

                        if (a == x)
                        {
                            win = "끝";
                            break;

                        }
                        
                        for (b = j; b < y; b++)
                        {
                            bool re = p == board[i, b];
                            if (re == false)
                            {
                                break;
                            }
                            
                        }

                        if (b == y)
                        {
                            win = "끝";
                            break;
                        }

                        a = i;
                        b = j;

                        

                        for (a = j; a < x; a++)
                        { 
                            bool re = p == board[a, b];
                            if (re == false)
                            {
                                break;
                            }
                            b++;

                        }

                        if (a == x)
                        {
                            win = "끝";
                            break;
                        }

                        a = i;
                        b = j;

                        for (a = j; a > z; a--)
                        {
                            bool re = p == board[a, b];
                            if (re == false)
                            {
                                break;
                            }
                            b--;
                        }

                        if (a == z)
                        {
                            win = "끝";
                            break;
                        }

                    }

                    
                }
                if (win == "끝")
                    {
                        break;
                    }
            }

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine("");

            }
            if (win == "끝")
            {
                Console.WriteLine(win);
            }
        }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace 오목
{
    class rule
    {
        public int [,] board = new int[19,19];

        public rule(int [,]board, int turn)
        {
            this.board = board;

            if (turn == 0)
            {
                for (int i = 0; i < 19; i++)
                {
                    for (int j = 0; j < 19; j++)
                    {
                        board[i, j] = 0;
                    }
                }
            }
        }

        public int on(int x, int y, int turn)
        {
            //bool gameover = false;

            int gameover = 0;

            if (turn % 2 == 1)
            {
                board[x, y] = 1;
            }
            else if (turn % 2 == 0)
            {
                board[x, y] = 2;
            }

            gameover = check();

            if (gameover == 3)
            {
                board[x, y] = 0;
            }

            return gameover;

            /*int p = board[x, y];
            
            int r = x + 5;
            int l = x - 5;
            int d = y + 5;
            int u = y - 5;
            

            int a;
            int b;

            int right = 0;
            int left = 0;
            int up = 0;
            int down = 0;
            int up_right = 0;
            int down_right = 0;
            int down_left = 0;
            int up_left = 0;

            //가로
            for (a = x; a < r; a++)
            {
                if (r > 19) break;

                if (p != board[a, y])
                {
                    break;
                }

                right++;


            }

            for (a = x; a > l; a--)
            {
                if (l < 0) break;

                if (p != board[a, y])
                {
                    break;
                }

                left++;
            }

            

            

            //세로
            for (b = y; b < d; b++)
            {
                if (d > 19) break;
                if (p != board[x, b])
                {
                    break;
                }

                down++;

            }

            for (b = y; b > u; b--)
            {
                if (u < 0) break;
                if (p != board[x, b])
                {
                    break;
                }

                up++;
            }

            

            a = x;
            b = y;


            //대각선1
            for (a = x; a < r; a++)
            {

                if (r > 19) break;
                if (p != board[a, b])
                {
                    break;
                }
                
                b++;

                down_right++;


            }

            b = y;

            for (a = x; a > l; a--)
            {
                if (l < 0) break;
                if (p != board[a, b])
                {
                    break;
                }

                b--;

                up_left++;
            }

            

            a = x;
            b = y;


            //대각선2
            for (a = x; a < r; a++)
            {
                if (r > 19) break;
                if (p != board[a, b])
                {
                    break;
                }
                b--;

                up_right++;
            }

            b = y;

            for (a = x; a > l; a--)
            {
                if (l < 0) break;
                if (p != board[a, b])
                {
                    break;
                }

                b++;

                down_left++;
            }

            if (right + left - 1 == 5)
            {
                gameover = true;
                return gameover;

            }

            if (up + down - 1 == 5)
            {
                gameover = true;
                return gameover;
            }

            if (down_right + up_left - 1 == 5)
            {
                gameover = true;
                return gameover;
            }



            if (up_right + down_left -1 == 5)
            {
                gameover = true;
                return gameover;
            }

            return gameover;*/
        }

        public int check()
        {
            int gameover = 0;

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    int p = board[i, j];

                    if (p != 0)
                    {

                        int r = i + 5;
                        int l = i - 5;
                        int d = j + 5;
                        int u = j - 5;

                        int a;
                        int b;

                        int right = 0;
                        int left = 0;
                        int up = 0;
                        int down = 0;
                        int up_right = 0;
                        int down_right = 0;
                        int down_left = 0;
                        int up_left = 0;

                        

                        ArrayList log = new ArrayList();

                        
                        for (a = i; a < r; a++)
                        {
                            if (r > 19) break;

                            if (p != board[a, j])
                            {
                                break;
                            }

                            right++; 

                        }

                        log.Add(right);

                        b = j;

                        for (a = i; a < r; a++)
                        {

                            if (r > 19 || b > 19) break;
                            if (p != board[a, b])
                            {
                                break;
                            }

                            b++;

                            down_right++;

                        }

                        log.Add(down_right);

                        b = j;

                        for (b = j; b < d; b++)
                        {
                            if (d > 19) break;
                            if (p != board[i, b])
                            {
                                break;
                            }

                            down++;

                        }

                        log.Add(down);

                        b = j;

                        for (a = i; a > l; a--)
                        {
                            if (l < 0 || b > 19) break;
                            if (p != board[a, b])
                            {
                                break;
                            }

                            b++;

                            down_left++;

                        }

                        log.Add(down_left);

                        b = j;

                        for (a = i; a > l; a--)
                        {
                            if (l < 0) break;

                            if (p != board[a, j])
                            {
                                break;
                            }

                            left++;
 
                        }

                        log.Add(left);

                        for (a = i; a > l; a--)
                        {
                            if (l < 0 || b < 0) break;
                            if (p != board[a, b])
                            {
                                break;
                            }

                            b--;

                            up_left++;

                        }

                        log.Add(up_left);

                        a = i;
                        b = j;

                        for (b = j; b > u; b--)
                        {
                            if (u < 0) break;
                            if (p != board[i, b])
                            {
                                break;
                            }

                            up++;

                            if (up > 2)
                            {
                                log.Add(up);
                            }
                        }

                        a = i;
                        b = j;


                        for (a = i; a < r; a++)
                        {
                            if (r > 19 || b < 0) break;
                            if (p != board[a, b])
                            {
                                break;
                            }
                            b--;

                            up_right++;

                            if (up_right > 2)
                            {
                                log.Add(up_right);
                            }
                        }

                        b = j;

                        ArrayList log2 = new ArrayList();
                        log2 = log;

                        for (int g = 0; g < log.Count; g++)
                        {
                            int x = (int)log[g];

                            
                            for (int h = 0; h < log2.Count; h++)
                            {
                                int y = (int)log2[h];
                                if (g == h)
                                {
                                    continue;
                                }

                                else if (x == 1 || y == 1)
                                {
                                    continue;
                                }

                                else if (x + y - 1 > 4)
                                {

                                    gameover = 2;
                                }
                            }
                        }

                        int sum = 0;

                        foreach (int x in log)
                        {
                            sum += x-1;
                        }

                        if (sum +1== 4)
                        {
                            gameover = 0;
                        }

                        int garo = right + left - 1;
                        int sero = up + down + -1;
                        int degac1 = down_right + up_left - 1;
                        int degac2 = down_left + up_right - 1;

                       /*if (garo < 5 || degac1 < 5 || sero < 5 || degac2 < 5)
                        {
                            gameover = 0;
                        }*/

                        if (garo == 5)
                        {
                            gameover = 1;
                            //return gameover;

                        }

                        else if (sero == 5)
                        {
                            gameover = 1;
                            //return gameover;
                        }

                        else if (degac1 == 5)
                        {
                            gameover = 1;
                            //return gameover;
                        }



                        else if (degac2 == 5)
                        {
                            gameover = 1;
                            //return gameover;
                        }

                        

                        /*else if (log.Count > 1 && sum > 3)
                        {
                            gameover = 2;
                            //return gameover;
                        }*/

                    }

                    

                }
            }

            

            return gameover;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tetris
{
    class board
    {
        public int[,] boards = new int[10, 15];

        public board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    boards[i, j] = 0;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tetris
{
    class block
    {
        public int[,] tile = new int[4, 4];

        public block(int [,]tile)
        {
            this.tile = tile;
        }

        public void Put(int[,]Map)
        {
        }

        public block Turn()
        {
            int[,] turn_tile = tile;

            block change = new block(turn_tile);

            return change;
        }
    }

	class tile1 : block
	{
		private int[,] t1 = new int[4, 4]{
			{0,0,0,0},
			{1,1,1,1},
			{0,0,0,0},
			{0,0,0,0}
		};

		private override int[,] Put(int[,] Map)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 3; j < 7; j++)
				{
					Map[i, j] = b1[i, j - 3];
				}
			}
		}
	}

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        //private int[] doingwhat = 
        private int[,] map = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1}
        };

        private Bitmap[] tiles = new Bitmap[]
        {
			
            Properties.Resources.그림1,
            Properties.Resources.그림2,
            Properties.Resources.그림3,
            Properties.Resources.그림4,
            Properties.Resources.그림5,
            Properties.Resources.그림6,
            Properties.Resources.그림7
        };

		private Mainfunction tile = new Mainfunction(0);

		private int[,] block = new int[4, 4];

		private int time = 0;

		private int move = 0;

		private int bottom = 0;

        public Form1()
        {
            InitializeComponent();
			block[0, 0] = -1;
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
			
            
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
					if(map[row,col] !=0)
					{
                    e.Graphics.DrawRectangle(new Pen(Brushes.DeepSkyBlue), 20, 20, 120, 190);
                    
                    e.Graphics.DrawImage(tiles[map[row, col]],
                        new Rectangle(col*12+20,row*12+20,12,12));
					}
                }
            }

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (block[i, j] < 0){
				
						break;
					}
					if (block[i, j] != 0)
					{
						e.Graphics.DrawImage(tiles[block[i, j]],
							new Rectangle( j* 12 + 20, (i - 4 + time)* 12 + 20, 12, 12));
					}
				}
			}


        }

		private void timer1_Tick(object sender, EventArgs e)
        {
			Random random = new Random();
			
			

			if (block[0, 0] == -1)
			{
				tile = new Mainfunction(random.Next(1,7));
				this.block = tile.mainB;
			}

			int check = tile.check(map, time, move, bottom);

			if (check == 2)
			{
				tile.put(ref map, time, move);
				block[0, 0] = -1;
				time = 0;
				bottom = 0;
			}
			else if (check == 1)
			{
				bottom++;
				time++;
			}
			else
			{
				bottom = 0;
				time++;
			}



            
           
            //Form1_Paint(null,null);
            Invalidate();
            
           
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

 
    }
}

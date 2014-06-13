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
            {0,0,0,0,0,0,0,0,0,0}
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

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    e.Graphics.DrawRectangle(new Pen(Brushes.DeepSkyBlue), 20, 20, 120, 190);
                    
                    e.Graphics.DrawImage(tiles[map[row, col]],
                        new Rectangle(col*12+20,row*12+20,12,12));
                }
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int i=0,j=3;
           
            //Form1_Paint(null,null);
            Invalidate();
            
            do{
                Mainfunction Basemain= new Mainfunction(random.Next(1,7));

                Basemain.put(ref map,i,j);
                i++;
            }while(check)

           
            checked();
            
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

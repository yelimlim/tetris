using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tetris
{
    public partial class Form1 : Form
    {
        public int[,] tile = new int[4, 4]{
            {0,0,0,0},
            {0,0,0,0},
            {0,0,0,0},
            {1,1,1,1}
        };

        public Bitmap[] color = new Bitmap[]{
            Properties.Resources.block,
            Properties.Resources.block2
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    e.Graphics.DrawImage(color[tile[j, i]],
                        new Rectangle(i * 20, j * 20, 20, 20));
                }
            }
        }
    }
}

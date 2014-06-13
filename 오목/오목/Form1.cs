using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace 오목
{
    public partial class Form1 : Form
    {
        public ArrayList doles = new ArrayList();
        public int turn = 0;
        public int[,] board = new int[19, 19];

        public Form1()
        {
            InitializeComponent();

            
            
            

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    board[i, j] = 0;
                }
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            board B = new board();
            using (Graphics g = this.CreateGraphics())
            {
                B.show(g);

                foreach(dole D in doles)
                {
                    D.show(g);
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            rule R = new rule(board, turn);
            
            turn++;
            
            Point P = e.Location;

            P.X = e.X / 15 * 15;
            P.Y = e.Y / 15 * 15;

            if (P.X % 30 != 0)
            {
                P.X += 15;
            }
            if (P.Y % 30 != 0)
            {
                P.Y += 15;
            }

            int x = P.X / 30;
            int y = P.Y / 30;

            int gameover = R.on(x, y, turn);

            if (gameover == 2)
            {
                MessageBox.Show("쌍삼임");
            }
            
            dole D = new dole(P, turn);
                doles.Add(D);


            Form1_Paint(null, null);

            if (gameover == 1)
                {
                    if (turn % 2 == 1)
                    {
                        MessageBox.Show("흑 승리");
                    }
                    else if (turn % 2 == 0)
                    {
                        MessageBox.Show("백 승리");
                    }

                    
                }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 오목
{
    class dole
    {
        public Point location;
        public Brush color;

        public dole(Point location, int turn)
        {
            this.location = location;

            if (turn % 2 == 1)
            {
                this.color = Brushes.Black;
            }
            else if (turn % 2 == 0)
            {
                this.color = Brushes.White;
            }


        }

        public void show(Graphics g)
        {
            g.FillEllipse (color, location.X - 10, location.Y - 10, 20, 20);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace lab2
{
    public partial class Form1 : Form
    {
        private Rectangle[] rectangles = new Rectangle[]
        {
            new Rectangle(10, 10, 100, 100),
            //new Square(30, 30, 70),
            new Rectangle(30, 30, 120, 120),
            //new Square(100, 100, 20)
        };

        private Rectangle CreateRectangle()
        {
            Random random = new Random();
            int left = random.Next(1, 100);
            int top = random.Next(1, 100);
            int right = random.Next(200, 300);
            int bottom = random.Next(200, 300);

            return new Rectangle(left, top, right, bottom);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                foreach (Rectangle rectangle in rectangles)
                {
                    rectangle.Show(g);
                }
            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Rectangle rectangle = CreateRectangle();

            Rectangle[] newArray = new Rectangle[rectangles.Length + 1];
            Array.Copy(rectangles, newArray, rectangles.Length);
            newArray[newArray.Length - 1] = newArray[newArray.Length - 2];
            newArray[newArray.Length - 2] = rectangle;

            rectangles = newArray;

            Form1_Paint(null, null);
        }
    }
}

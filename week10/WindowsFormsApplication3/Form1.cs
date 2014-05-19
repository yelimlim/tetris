using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ArrayList Rectangles = new ArrayList();
        private ArrayList Squares = new ArrayList();
        private ArrayList Circles = new ArrayList();
        private ArrayList Triangles = new ArrayList();
        

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Random random = new Random();
            
            int left = random.Next(1, 150);  //a_y
            int top = random.Next(1, 150);  //b_x
            int right = random.Next(150, 300); //b_y
            int bottom = random.Next(150, 300); //c_x

            int width = random.Next(1, 150);

            int a_x = random.Next(1, 300);
            int c_y = random.Next(150, 300);

            Rectangle rectangle = new Rectangle(left, top, right, bottom);
            Square square = new Square(left, top, width);
            Circle circle = new Circle(left, top, width);
            Triangle triangle = new Triangle(a_x, left, top, right, bottom, c_y);

            int Random = random.Next(0, 4);

            switch (Random)
            {
                case 0:
                    Rectangles.Add(rectangle);
                    break;
                
                case 1:
                    Squares.Add(square);
                    break;

                case 2:
                    Circles.Add(circle);
                    break;

                case 3:
                    Triangles.Add(triangle);
                    break;

                default:
                    break;

            }

            

            Form1_Paint(null, null);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                foreach (Rectangle rectangle in Rectangles)
                {
                    rectangle.Show(g);
                }

                foreach (Square square in Squares)
                {
                    square.Show(g);
                }

                foreach (Circle circle in Circles)
                {
                    circle.Show(g);
                }

                foreach (Triangle triangle in Triangles)
                {
                    triangle.Show(g);
                }
            }
        }
    }
}

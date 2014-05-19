using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication3
{
    class Figure
    {
    }

    class Rectangle : Figure
    {
        protected Point LeftTop;
        protected Point RightBottom;

        public Rectangle(int Left, int Top, int Right, int Bottom)
        {
            this.LeftTop = new Point(Left, Top);
            this.RightBottom = new Point(Right, Bottom);
        }

        public virtual void Show(Graphics Rec)
        {
            Rec.DrawRectangle(Pens.Black,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);
            
            Rec.FillRectangle(Brushes.Cyan,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);
        }
    }

    class Square : Rectangle
    {
        public Square(int Left, int Top, int Width)
            : base(Left, Top, Left + Width, Top + Width)
        {
        }

        public override void Show(Graphics squ)
        {
            squ.DrawRectangle(Pens.Black,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            squ.FillRectangle(Brushes.Brown,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);
        }
    }

    class Circle : Square
    {
        public Circle(int Left, int Top, int Width)
            : base(Left, Top, Width)
        {
        }

        public override void Show(Graphics cir)
        {
            cir.DrawEllipse(Pens.Black,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);

            cir.FillEllipse(Brushes.DarkGoldenrod,
                LeftTop.X, LeftTop.Y,
                RightBottom.X - LeftTop.X,
                RightBottom.Y - LeftTop.Y);
        }
    }

    class Triangle : Figure
    {
        private Point x;
        private Point y;
        private Point z;
        
        public Point[] Points = new Point[]{

           new Point (0,0),
           new Point (0,0),
           new Point (0,0)
        };

        public Triangle(int a, int b, int c, int d, int e, int f)
        {
            this.x = new Point(a, b);
            this.y = new Point(c, d);
            this.z = new Point(e, f);

            Points[0] = x;
            Points[1] = y;
            Points[2] = z;
        }


        public virtual void Show(Graphics tri)
        {
            tri.DrawPolygon(Pens.Black, Points);

            tri.FillPolygon(Brushes.CornflowerBlue, Points);
        }
    }
}

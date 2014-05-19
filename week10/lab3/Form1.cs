using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GUIRectangle
{
    public partial class Form1 : Form
    {
        private ArrayList rectangles = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                foreach (Rectangle rectangle in rectangles)
                {
                    rectangle.Show(g);
                }
            }
        }

        private void Form2_DoubleClick(object sender, EventArgs e)
        {


            Random random = new Random();

            int left = random.Next(1, 100);
            int top = random.Next(1, 100);
            int right = random.Next(200, 300);
            int bottom = random.Next(200, 300);

            Rectangle rectangle = new Rectangle(left, top, right, bottom);

            rectangles.Add(rectangle);

            Form2_Paint(null, null);
        }
    }
}

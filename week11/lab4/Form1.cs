﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ArrayList Figures = new ArrayList();

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
                    Figures.Add(rectangle);
                    break;

                case 1:
                    Figures.Add(square);
                    break;

                case 2:
                    Figures.Add(circle);
                    break;

                case 3:
                    Figures.Add(triangle);
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
                foreach (Figure figure in Figures)
                {
                    figure.Show(g);
                }

            }
        }

        private void 저장하기SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream bw = new FileStream(saveFileDialog.FileName, FileMode.Create);

                BinaryFormatter serializer = new BinaryFormatter();

                serializer.Serialize(bw, Figures);

                bw.Close();
                
            }
        }

        private void 불러오기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream br = new FileStream(openFileDialog.FileName, FileMode.Open);

                BinaryFormatter deserializer = new BinaryFormatter();

                Figures = (ArrayList)deserializer.Deserialize(br);

                Form1_Paint(null, null);

                br.Close();
            }


        }

        


        
    }
}

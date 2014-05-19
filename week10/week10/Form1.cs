using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace calc
{
    public partial class Form1 : Form
    {
        
        private int sum = 0;

        public void where()
        {
           if (textBox1.Text == "+")
            {
                textBox1.Text = "";
                
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            sum = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            where();
            textBox1.Text = textBox1.Text + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            where();
            textBox1.Text = textBox1.Text + 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            where();
            textBox1.Text = textBox1.Text + 3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            where();
            textBox1.Text = textBox1.Text + 6;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            where();
            textBox1.Text = textBox1.Text + 5;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            where();
            textBox1.Text = textBox1.Text + 4;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            where();
            textBox1.Text = textBox1.Text + 7;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            where();
            textBox1.Text = textBox1.Text + 9;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            where();
            textBox1.Text = textBox1.Text + 8;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            where();
            textBox1.Text = textBox1.Text + 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            sum = sum + int.Parse(textBox1.Text);
            textBox1.Text = "+";

        }

        private void button13_Click(object sender, EventArgs e)
        {
            sum = sum + int.Parse(textBox1.Text);
            textBox1.Text = sum.ToString();
        }
    }
}

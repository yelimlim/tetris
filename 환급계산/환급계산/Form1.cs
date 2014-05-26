using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 환급계산
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            calculate();
            message();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            calculate();
            message();
        }

        private void calculate()
        {
            int amount = (int)numericUpDown2.Value - (int)numericUpDown1.Value;

            label4.Text = amount.ToString();
        }

        private void message()
        {
            if ((int)numericUpDown2.Value - (int)numericUpDown1.Value < 0)
            {
                MessageBox.Show("시작시 주행거리는 도착시 주행거리보다 클 수 없습니다");
            }
        }
    }
}

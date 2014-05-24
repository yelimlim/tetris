using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;


namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 불러오기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList students_print = new ArrayList();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                BinaryReader br = new BinaryReader(new FileStream(openFileDialog.FileName, FileMode.Open));

                while (br.PeekChar() != -1)
                {

                    Student student = new Student(br.ReadString(), br.ReadString(), br.ReadInt32());

                    students_print.Add(student);


                }
                
                br.Close();

                foreach (Student stu in students_print)
                {

                    listBox1.Items.Add(stu.GetName() + "\t" + stu.GetSubject() + "\t" + stu.GetScore());

                }
                
            }
        }
    }
}

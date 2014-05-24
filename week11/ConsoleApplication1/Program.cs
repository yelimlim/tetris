using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace ConsoleApplication1
{

    class Student
    {
        private string Name;
        private string Subject;
        private int Score;

        public Student(string Name, string Subject, int Score)
        {
            this.Name = Name;
            this.Subject = Subject;
            this.Score = Score;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetSubject()
        {
            return Subject;
        }

        public int GetScore()
        {
            return Score;
        }
    }

    class Program
    {
        private static ArrayList students = new ArrayList();
        private static ArrayList students_print = new ArrayList();

        static void Main(string[] args)
        {
            string check;

           do
            {

                Console.WriteLine("name?");
                string name = Console.ReadLine();

                Console.WriteLine("subject?");
                string subject = Console.ReadLine();

                Console.WriteLine("score?");
                int score = int.Parse(Console.ReadLine());

                Student student = new Student(name, subject, score);

                students.Add(student);

                Console.WriteLine("더 입력하시겠습니까?(진행:g, 입력X:n");
                check = Console.ReadLine();

            }while(check == "g");
            
           

            
                BinaryWriter bw = new BinaryWriter(new FileStream("수업.bat", FileMode.Create));
                foreach (Student stu in students)
                {

                    bw.Write(stu.GetName());
                    bw.Write(stu.GetSubject());
                    bw.Write(stu.GetScore());
                   
                }
                 
                bw.Close();

                BinaryReader br = new BinaryReader(new FileStream("수업.bat", FileMode.Open));

                while (br.PeekChar() != -1)
                {

                    Student student = new Student(br.ReadString(), br.ReadString(), br.ReadInt32());

                    students_print.Add(student);

                    
                }

                foreach (Student stu in students_print)
                {

                    Console.WriteLine("{0}\t{1}\t{2}", stu.GetName(), stu.GetSubject(), stu.GetScore());

                }
            br.Close();


            

           


        }
    }
}

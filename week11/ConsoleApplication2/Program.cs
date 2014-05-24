using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace ConsoleApplication2
{
    [Serializable]
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
        static void Main(string[] args)
        {
            FileStream ws = new FileStream("a.dat", FileMode.Create);
            
            BinaryFormatter serializer = new BinaryFormatter();

            ArrayList students = new ArrayList();
            
            students.Add(new Student("조영호", "국어", 80));
            students.Add(new Student("임예림", "국어", 100));
            students.Add(new Student("임예준", "국어", 50));
            students.Add(new Student("임예주", "국어", 70));
            
            serializer.Serialize(ws, students);

            ws.Close();

            FileStream rs = new FileStream("a.bat", FileMode.Open);
            
            BinaryFormatter deserializer = new BinaryFormatter();

            students = (ArrayList)deserializer.Deserialize(rs);

            foreach (Student student in students)
            {

                Console.WriteLine("{0}\t{1}\t{2}", student.GetName(), student.GetSubject(), student.GetScore());

            }
            rs.Close();


        }
    }
}

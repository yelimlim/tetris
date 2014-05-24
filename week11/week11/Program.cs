using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(new FileStream("C:/Users/mong/Desktop/pp.txt", FileMode.Create));
            sw.WriteLine("프로그래밍 연습");
            sw.WriteLine("C# 오전 분반");
            sw.WriteLine("--... 피곤 하다");
            sw.Close();

            StreamReader sr = new StreamReader(new FileStream("pp.txt", FileMode.Open));

            while (sr.EndOfStream == false)
            {
                Console.WriteLine(sr.ReadLine());
            }

            sr.Close();
        }
    }
}

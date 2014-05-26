using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linked = new LinkedList<string>();
            linked.AddLast("one");
            linked.AddLast("two");
            linked.AddLast("three");
            LinkedListNode<string> node = linked.Find("one");
            linked.AddAfter(node, "inserted");
            foreach (var value in linked)
            {
                Console.WriteLine(value);
            }

            Thread.Sleep(10000);
        }



    }
}

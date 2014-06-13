using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N03
{
	class Node
	{
		public virtual double Val() { return 0; }
		public virtual void Print()
		{
		}
	}
	class NumNode :Node{
		public double number;
		public override double Val()
		{
			return number;
		}
		public NumNode(double number)
		{
			this.number =number;
		}
		public override void Print()
		{
			Console.Write("{0}", number);
		}
	}

	class OpNode : Node
	{
		public char op;
		public Node left;
		public Node right;
		public OpNode(char op)
		{
			this.op = op;
		}
		public override double Val()
		{
			switch (op)
			{
				case '*':
					return left.Val() * right.Val();
				case '+':
					return left.Val() + right.Val();
				default:
					Console.WriteLine("unknown");
					return 0;
			}
		}
		public override void Print()
		{
			left.Print();
			Console.Write(" {0} ", op);
			
			right.Print();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			OpNode op1 = new OpNode('+');
			OpNode op = new OpNode('*');
			NumNode a = new NumNode(4);
			NumNode b = new NumNode(2);
			NumNode c = new NumNode(3);
			op1.left = op;
			op1.right = c;
			op.left = a;
			op.right = b;

			op1.Print();
			Console.WriteLine("={0}", op1.Val());
			Console.WriteLine("{0}", int.Parse("12") + int.Parse("13"));
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N02
{
    class Elem
    {
        public int rid, cid;
        public double val;

        public Elem(int rid, int cid, double val)
        {
            this.rid = rid;
            this.cid = cid;
            this.val = val;
        }

    }
    
    class SparseMatrix
    {
        public int rows;
        public int cols;

        public Elem[] buffer = new Elem[1];

        public int valnum = 0;

        public void Create(int rid, int cid, double val)
        {
            while(valnum >= buffer.Length)
            {
                Console.WriteLine("buffer increase! {0} --> {1}", valnum, valnum * 2);
                Elem[] tmp = new Elem[buffer.Length *2];
                for (int i = 0; i < buffer.Length; i++)
                {
                    tmp[i] = buffer[i];
                }

                buffer = tmp;
            }
            buffer[valnum] = new Elem(rid, cid, val);
            valnum++;
        }

        public void print()
        {
            Console.WriteLine("SparseMatrix({0},{1})[{2}]", rows, cols, valnum);

			for (int i = 0; i< valnum; i++)
			{
				Elem e = buffer [i];
				Console.WriteLine("{0}, {1}, {2}", e.rid, e.cid, e.val);
			}
        }

		public void transpose()
		{
			int [] startpoint = new int [cols];

			foreach (int i in startpoint)
			{
				startpoint[i] = 0;
			}

			foreach (Elem i in buffer)
			{
				for (int j = 0; j < cols; j++)
				{
					if (i.cid == j)
					{
						startpoint[j]++;
					}
				}
			}

			int[] pointarray = new int[cols];

			foreach (int i in startpoint)
			{
				pointarray[i] = startpoint[i];	
			}

			pointarray[1] = startpoint[0];
			pointarray[0] = 0;

			for (int i =2; i < startpoint.Length; i++)
			{
				pointarray[i] = startpoint[i - 1] + pointarray[i- 1];  
			}

			

			/*SparseMatrix trans = new SparseMatrix();

			trans.rows = rows;
			trans.cols = cols;*/
			
			Elem[] trans_buffer = new Elem[valnum];
			
			//trans.buffer = trans_buffer;

			foreach (Elem i in buffer)
			{
				Elem trans_elem = new Elem(i.cid, i.rid, i.val);

				trans_buffer[pointarray[trans_elem.rid]] = trans_elem;

				pointarray[trans_elem.rid]++;
			}

			buffer = trans_buffer;

			//return trans;

		}

		public void PrintMatrix()
		{
			double[,] m = new double[rows, cols];
			int p = 0;

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (p < valnum && buffer[p].rid == i && buffer[p].cid == j)
					{
						Console.Write(" {0}", buffer[p].val);
						p++;
					}
					else
					{
						Console.WriteLine(" 0 ");
					}


				}
				Console.WriteLine("");
			}
		}

		public void Sort()
		{
			Elem[] tmp = new Elem[valnum];
			for (int i = 0; i < valnum; i++)
			{
				tmp[i] = buffer[i];
			}
			Array.Sort(tmp,delegate(Elem x, Elem y){
				
				if (x.rid < y.rid)
				{
					return -1;
				}
				else if (x.rid > y.rid)
				{
					return 1;
				}
				else
				{
					if (x.cid < y.cid)
					{
						return -1;
					}
					else if (x.cid > y.cid)
					{
						return 1;
					}
					else
					{
						return 0;
					}
				}
				
			});

			for (int i = 0; i < valnum; i++)
			{
				buffer[i] = tmp[i];
			}
		}

		public SparseMatrix Add(SparseMatrix that)
		{
			SparseMatrix res = new SparseMatrix();
			int left = 0, right = 0;
			while (left < valnum && right < that.valnum)
			{
				if (buffer[left].rid < that.buffer[right].rid)
				{
					Elem e = buffer[left];
					res.Create(e.rid, e.cid, e.val);
					left++;
				}
				else if (buffer[left].rid > that.buffer[right].rid)
				{
					Elem e = that.buffer[right];
					res.Create(e.rid, e.cid, e.val);
					right++;
				}
				else
				{
					if (buffer[left].cid < that.buffer[right].cid)
					{
						Elem e = buffer[left];
						res.Create(e.rid, e.cid, e.val);
						left++;
					}
					else if (buffer[left].cid > that.buffer[right].cid)
					{
						Elem e = that.buffer[right];
						res.Create(e.rid, e.cid, e.val);
						right++;
					}
					else
					{
						Elem a = buffer[left], b = that.buffer[right];
						res.Create(a.rid, a.cid, a.val + b.val);
						left++;
						right++;
					}
				}
			}
			while (left < valnum)
			{
				Elem e = buffer[left];
				res.Create(e.rid, e.cid, e.val);
				left++;
			}

			while (right < that.valnum)
			{
				Elem e = buffer[right];
				res.Create(e.rid, e.cid, e.val);
				right++;
			}

			return res;
		}

    }


    class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix m = new SparseMatrix();

            m.rows = 6;
            m.cols = 6;
			m.Create(1, 2, 3);
			m.Create(2, 3, -6);
			m.Create(4, 0, 91);
			m.Create(5, 2, 28);
			m.Create(0, 0, 15);
            m.Create(0, 3, 22);
            m.Create(0, 5, -15);
            m.Create(1, 1, 11);
            

            m.print();

			Console.WriteLine("");

			m.Sort();
			m.print();

			m.Add(m).print();

			/*m.transpose();

			m.print();

            Console.WriteLine("Hello");*/
        }
    }
}

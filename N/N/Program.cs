using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace N
{
    class student
    {
        public int id;
        public string name;
        public string picture;
        public student left;
        public student right;

        public student(int id, string name, string picture)
        {
            this.id = id;
            this.name = name;
            this.picture = picture;

            left = null;
            right = null;
        }

        public void Add(student s)
        {
            if (s.id < id)
            {
                if (left == null)
                {
                    left = s;
                }
                else
                {
                    left.Add(s);
                }
            }
            else if (s.id > id)
            {
                if (right == null)
                {
                    right = s;
                }
                else
                {
                    right.Add(s);
                }
            }
            else
            {
                Console.WriteLine("Error!!!");
            }

        }

        public void PrintSubtree(int level)
        { 
            if (left != null)
            {
                left.PrintSubtree(level +1);
            }

            for (int i = 0; i < level; i++)
            {
                Console.Write("    ");
            }
            Console.WriteLine("{0} {1} {2}", id, name, picture);
           
            if (right != null)
            {
                right.PrintSubtree(level +1);
            }
        }

        public student SearchStudent(int id)
        {
            if (id == this.id)
            {
                return this;
            }

            else if(id < this.id )
            {
                if (left == null)
                {
                    return null;
                }
                else
                {
                    return left.SearchStudent(id);
                }


            }

            else if (id > this.id)
            {
                if (right == null)
                {
                    return null;
                }
                else
                {
                    return right.SearchStudent(id);
                }
            }
            else
            {
                return null;
            }
        }

		public static student findsuc(student delete)
		{
			int level_left = 0;
			int level_right = 0;

			student l = delete.left;
			student r = delete.right;

			while (l.right != null){
				
				level_left++;
				l = l.right;
			}

			while(r.left != null)
			{
				level_right++;
				r = r.left;
			}

			if (level_left >= level_right)
			{
				return r;
			}
			else
			{
				return l;
			}
			


		}

        public static void delete(int id, ref student root)
        {
			if (root.id == id)
			{
				if (root.left == null && root.right == null)
				{
					root = null;
				}
				else if (root.left != null && root.right == null)
				{
					root = root.left;
				}
				else if (root.left == null && root.right != null)
				{
					root = root.right;
				}

				else
				{
					student temp = findsuc(root);
					//student delete_stu = root.SearchStudent(id);

					delete(temp.id, ref root);
					temp.left = root.left;
					temp.right = root.right;
					root = temp;
				}
			}

            else if (root.left != null &&root.left.id == id )
            {
                if (root.left.left == null && root.left.right == null)
                {
                    root.left = null;
                }
                else if (root.left.left != null && root.left.right == null)
                {
                    root.left = root.left.left;
                }
				else if (root.left.left == null && root.left.right != null)
				{
					root.left = root.left.right;
				}

				else
				{
					student temp = findsuc(root.left);
					student delete_stu = root.SearchStudent(id);

					delete(temp.id, ref delete_stu);
					temp.left = root.left.left;
					temp.right = root.left.right;
					root.left = temp;
				}
            }
                
            else if (root.right != null&&root.right.id == id )
            {
					if (root.right.left == null && root.right.right == null)
                    {
                        root.right = null;
                    }
                    else if (root.right.left != null&&root.right.right == null)
                    {
                        root.right = root.right.left;
                    }
                    else if (root.right.left == null &&root.right.right != null)
                    {
                        root.right = root.right.right;
                    }

					else
					{
						student temp = findsuc(root.right);
						student delete_stu = root.SearchStudent(id);

						delete(temp.id, ref delete_stu);
						temp.left = root.right.left;
						temp.right = root.right.right;
						root.right = temp;
					}
                }

                
                else if (id < root.id)
                {
                    delete(id, ref root.left);
                }
                else if (id > root.id)
                {
                    delete(id, ref root.right);
                }

            
            
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("bst");
            student s = new student(50, "lim", "asdf.jpg");
            s.Add(new student(25, "kim", "kim.jpg"));
            s.Add(new student(100, "lee", "lee.jpg"));
            s.Add(new student(21, "ha", "ha.jpg"));
            s.Add(new student(35, "k", "k.jpg"));
			s.Add(new student(80, "j", "j.jpg"));
			s.Add(new student(150, "a", "a.jpg"));
			s.Add(new student(23, "b","b.jpg"));
			s.Add(new student(27, "b", "b.jpg"));
			s.Add(new student(38, "b", "b.jpg"));
			s.Add(new student(60, "b", "b.jpg"));
			s.Add(new student(90, "b", "b.jpg"));
			s.Add(new student(37, "b", "b.jpg"));
			s.Add(new student(39, "b", "b.jpg"));
			//s.Add(new student(15, "b", "b.jpg"));

            //s.SearchStudent(3).PrintSubtree(0);

            Console.WriteLine("");

            s.PrintSubtree(0);

            Console.WriteLine("");
            Console.WriteLine("What do you want to delete id?");

            int delete_id = int.Parse(Console.ReadLine());

            student.delete(delete_id, ref s);

            s.PrintSubtree(0);
			 

			//Console.WriteLine(student.findsuc(s.left).id);

            
        }
    }
}

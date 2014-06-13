using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListExample
{
    class Program
    {
        
        
        class Term
        {
            public double coef;
            public int exp;
            public Term next;

            
        };

        class Polynomial
        {
            public Term first;
            
            public Polynomial()
            {
                first = null;
            }

            public void AddTerm(double coef, int exp)
            {
                Term t = new Term();
                t.coef = coef;
                t.exp = exp;

                if (first == null)
                {
                    first = t;
                    t.next = null;
                }
                else
                {
                    t.next = first;
                    first = t;
                }


            }

            public void PrintPoly()
            {


                for (Term t = first; t != null; t = t.next)
                {
                    Console.Write(" ");

                    if (t.coef > 0)
                    {
                        Console.Write("+");
                    }
                    else if (t.coef <= 0)
                    {
                    }

                    if (t.exp == 0)
                    {
                        Console.Write("{0}", t.coef);
                    }
                    else if (t.coef == 1 && t.exp == 1)
                    {
                        Console.Write("x");
                    }
                    else if (t.coef == 1)
                    {
                        Console.Write("x^{0}", t.exp);
                    }
                    else if (t.exp == 1)
                    {
                        Console.Write("{0}x", t.coef);
                    }
                    else
                    {
                        Console.Write("{0}x^{1}", t.coef, t.exp);
                    }
                }

                Console.WriteLine();
            }

            public void DeleteTerm(Term s)
            {
                s.coef = 0;
                for (Term t = first; t != null; t = t.next)
                {
                    if (t.next == s)
                    {
                        t.next = s.next;
                        s.next = null;
                        break;
                    }
                }

            }


            public Polynomial Simplify()
            {
                Polynomial res = new Polynomial();

                for (Term t = first; t != null; t = t.next)
                {

                    int exp = t.exp;
                    double coef = t.coef;

                    for (Term s = t.next; s != null; s = s.next)
                    {
                        if (s.exp == exp)
                        {
                            coef += s.coef;
                            DeleteTerm(s);
                        }
                    }

                    res.AddTerm(coef, exp);
                }
                
                return res;
            }

            public Polynomial Reverse()
            {
                Polynomial rev = new Polynomial();
                
                for (Term t = first; t != null; t = t.next)
                {

                    int exp = t.exp;
                    double coef = t.coef;

                    rev.AddTerm(coef, exp);
                }

                return rev;
            }

            public Polynomial Sort()
            {
                Polynomial sor = new Polynomial();

                for (int i = 0; i < 5; i++)
                {


                    for (Term t = first; t != null; t = t.next)
                    {

                        int exp = t.exp;
                        double coef = t.coef;

                        if (t.exp == i)
                        {
                            sor.AddTerm(coef, exp);
                        }

                    }
                }

                return sor;
            }
        }

        

        static void Main(string[] args)
        {
            Polynomial p = new Polynomial();

            p.AddTerm(1, 2);
            p.AddTerm(-2, 1);
            p.AddTerm(1, 0);
            p.PrintPoly();

            Polynomial s = p.Simplify();

            s.PrintPoly();

            Polynomial v = s.Reverse();

            v.PrintPoly();

            Polynomial j = v.Sort();

            j.PrintPoly();
        }
    }
}

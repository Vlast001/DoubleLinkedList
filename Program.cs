using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyList
{
    
    class Program
    {
        static void Main(string[] args)
        {
            #region Range tests
            //Random rand = new Random();
            //DoubleList<int> d = new DoubleList<int>();
            //List<int> a = new List<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    a.Add(rand.Next(-20, 40));
            //}

            //foreach (var i in a)
            //{
            //    Console.Write($"{i} ");
            //}

            //Console.WriteLine();
            //d.AddFirst(-999);
            //d.AddFirst(999);
            //d.PrintForward();
            //d.InsertRange(a.ToArray(), 1);
            //d.PrintForward();
            //d.RemoveRange(1, d.Count-2);
            //d.PrintForward();

            #endregion

            #region Add,Insert,Pop,Clear,Print tests
            //DoubleList<int> dl = new DoubleList<int>() { 2, 3, 4, 6, 7, 9, -2 };
            //dl.AddFirst(100);
            //dl.AddLast(-100);
            //dl.PrintForward();
            //dl.PrintBackward();
            //DoubleList<int> doubleList = new DoubleList<int>() { 2, 3, 4 };
            //doubleList.PrintForward();
            //doubleList.Insert(5, 0);
            ////doubleList.PopBack();
            ////doubleList.PopBack();
            ////doubleList.PopBack();
            ////dl1.PopFront();
            ////dl1.PopFront();
            ////dl1.PopFront();
            //doubleList.PrintForward();
            //doubleList.Insert(50, 1);
            //doubleList.PrintForward();
            //doubleList.Insert(500, doubleList.Count);
            //doubleList.PrintForward();
            //doubleList.Insert(-999, 3);
            //doubleList.PrintForward();
            ////Console.WriteLine(doubleList.Count);
            //doubleList.Clear();

            #endregion

            #region Remove tests
            //DoubleList<int> a = new DoubleList<int>() { 1, 2, 3, 4, 5 };
            //a.PrintForward();
            //a.Remove(0);
            //a.Remove(a.Count - 1);
            //a.Remove(1);
            //a.PrintForward();
            //a.Remove(1);
            //a.PrintForward();
            //a.Remove(0);
            //int pos = 4;
            //Console.WriteLine($"Count: {a.Count}");
            //while (a.Count>pos)
            //{
            //    a.Remove(pos);
            //}
            //Console.WriteLine($"Count: {a.Count}");
            //a.PrintForward();
            #endregion

            DoubleList<int> a = new DoubleList<int>(){1,2,3,4,5,6,7,8,9,10};
            //Console.WriteLine(a.Count);
            //a.RemoveRange(2,8);
            a.ReverseSort();
            a.PrintForward();
            a.Sort();
            a.PrintForward();
        }
    }
}

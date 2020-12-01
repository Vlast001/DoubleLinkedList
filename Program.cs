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
            Random rand = new Random();
            DoubleList<int> d = new DoubleList<int>();
            List<int> a = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                a.Add(rand.Next(-20,40));
            }

            foreach (var i in a)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            d.AddFirst(-999);
            d.AddFirst(999);
            d.PrintForward();
            d.InsertRange(a.ToArray(),1);
            d.PrintForward();

            //DoubleList<int> dl = new DoubleList<int>(){2,3,4,6,7,9,-2};
            //dl.AddFirst(100);
            //dl.AddLast(-100);
            //dl.PrintForward();
            //dl.PrintBackward();
            //DoubleList<int> doubleList = new DoubleList<int>() { 2,3,4 };
            //doubleList.PrintForward();
            //doubleList.Insert(5,0);
            ////doubleList.PopBack();
            ////doubleList.PopBack();
            ////doubleList.PopBack();
            ////dl1.PopFront();
            ////dl1.PopFront();
            ////dl1.PopFront();
            //doubleList.PrintForward();
            //doubleList.Insert(50,1);
            //doubleList.PrintForward();
            //doubleList.Insert(500,doubleList.Count);
            //doubleList.PrintForward();
            //doubleList.Insert(-999,3);
            //doubleList.PrintForward();
            ////Console.WriteLine(doubleList.Count);
            //doubleList.Clear();


            //foreach (var i in dl)
            //{
            //    Console.Write($"{i} ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(dl.Contains(50));
            //Console.WriteLine(dl.Count);
            //Console.WriteLine();
            //dl.Delete(3);
            //dl.Delete(2);
            //foreach (var i in dl)
            //{
            //    Console.Write($"{i} ");
            //}

            //Console.WriteLine();
            //Console.WriteLine(dl.Count);


            //LinkedList<int> c = new LinkedList<int>();
            //c.AddFirst(1);
            //c.AddFirst(2);
            //c.AddFirst(3);
            //c.AddFirst(4);
            //c.AddFirst(5);
            
            //c.Remove(2);
            //foreach (var i in c)
            //{
            //    Console.Write($"{i} ");
            //}

            //DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();
            //// добавление элементов
            //linkedList.AddLast("Bob");
            //linkedList.AddLast("Bill");
            //linkedList.AddLast("Tom");
            //linkedList.AddFirst("Kate");
            //foreach (var item in linkedList)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine();
            //// удаление
            //linkedList.Remove("Bill");

            //// перебор с последнего элемента
            //foreach (var t in linkedList.BackEnumerator())
            //{
            //    Console.WriteLine(t);
            //}
        }
    }
}

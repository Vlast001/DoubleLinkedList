using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DoublyList
{
    class DoubleList<T> : IEnumerable<T>
    {

        protected class Node<TN>
        {
            public TN Data { get; set; }
            public Node(TN data)
            {
                Data = data;
            }
            public Node<TN> Next { get; set; }
            public Node<TN> Previous { get; set; }
        }

        private Node<T> _head;
        private Node<T> _tail;
        private int _count;
        public int Count => _count;
        public bool IsEmpty => _count == 0;
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        /// <summary>
        /// AddLast for initializer list
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (_head == null)
                _head = node;
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }

            _tail = node;
            _count++;
        }
        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);
            if (_head == null)
                _head = node;
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }

            _tail = node;
            _count++;
        }

        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> temp = _head;
            node.Next = temp;
            _head = node;
            if (_count == 0)
                _tail = _head;
            else
                temp.Previous = node;
            _count++;
        }

        public void Insert(T data, int pos)
        {
            if (pos < 0 || pos > _count)
            {
                return;
            }
            if (pos == 0)
            {
                AddFirst(data);
                return;
            }
            if (pos == _count)
            {
                AddLast(data);
                return;
            }

            var tmp = new Node<T>(data);
            var cur = _head;
            for (int i = 0; i < pos-1; i++)
            {
                cur.Data = cur.Data;
                cur = cur.Next;
            }

            tmp.Previous = cur;
            tmp.Next = cur.Next;
            cur.Next.Previous = tmp;
            cur.Next = tmp;
            _count++;
        }

        public void PopFront()
        {
            if(_count==0)
                return;
            if (_count == 1)
            {
                _head = null;
                _head = _tail = null;
                _count = 0;
                return;
            }

            _head = _head.Next;
            _head.Previous = null;
            _count--;
        }

        public void PopBack()
        {
            if (_count == 0)
                return;
            if (_count == 1)
            {
                _head = null;
                _head = _tail = null;
                _count = 0;
                return;
            }

            _tail = _tail.Previous;
            _tail.Next = null;
            _count--;
        }

        //public bool Delete(T data)
        //{
        //    Node<T> current = new Node<T>(data);
        //    while (current != null)
        //    {
        //        if (current.Data.Equals(data))
        //            break;
        //        current = current.Next;
        //    }

        //    if (current != null)
        //    {
        //        if (current.Next != null)
        //            current.Next.Previous = current.Previous;
        //        else
        //            _tail = current.Previous;

        //        if (current.Previous != null)
        //            current.Previous.Next = current.Next;
        //        else
        //            _head = current.Next;

        //        _count--;
        //        return true;
        //    }

        //    return false;
        //}

        public bool Contains(T data)
        {
            Node<T> current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void PrintForward()
        {
            var cur = _head;
            while (cur!=null)
            {
                Console.Write($"{cur.Data} ");
                cur = cur.Next;
            }

            Console.WriteLine();
        }

        public void PrintBackward()
        {
            var cur = _tail;
            while (cur != null)
            {
                Console.Write($"{cur.Data} ");
                cur = cur.Previous;
            }

            Console.WriteLine();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            Node<T> current = _tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}

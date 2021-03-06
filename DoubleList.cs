﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DoublyList
{
    public partial class DoubleList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private Node _head;
        private Node _tail;
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
            Node node = new Node(data);
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
            Node node = new Node(data);
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
            Node node = new Node(data);
            Node temp = _head;
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
                throw new ArgumentOutOfRangeException("Wrong position");
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

            var tmp = new Node(data);
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

        /// <summary>
        /// Insert special for InsertRange
        /// I used this to insert a range of values correctly: {1,2,3,4,5} -> {10,-10} = {10, 1, 2, 3, 4, 5, -10}
        /// right now it private method so name "Insert2" doesn't matter
        /// P.S. Iteration from the end...InsertLast? InsertBackward ?)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        private void Insert2(T data, int pos)
        {
            if (pos < 0 || pos > _count)
            {
                throw new ArgumentOutOfRangeException("Wrong position");
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

            var tmp = new Node(data);
            var cur = _tail;
            for (int i = 0; i < pos - 1; i++)
            {
                cur.Data = cur.Data;
                cur = cur.Previous;
            }

            tmp.Next = cur;
            tmp.Previous = cur.Previous;
            cur.Previous.Next = tmp;
            cur.Previous = tmp;
            _count++;
        }

        /// <summary>
        /// Adding a range of elements at a specified position
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pos"></param>
        public void InsertRange(T[] data, int pos)
        {
            foreach (var item in data)
            {
                Insert2(item,pos);
            }
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

        public void Remove(int pos)
        {
            if (pos < 0 || pos >= _count)
            {
                throw new ArgumentOutOfRangeException("Wrong position");
            }
            if (pos == 0)
            {
                PopFront();
                return;
            }
            if (pos == _count-1)
            {
                PopBack();
                return;
            }

            int i = 0;
            var del = _head;

            while (i<pos)
            {
                del = del.Next;
                i++;
            }

            var prev = del.Previous;
            var next = del.Next;
            if (prev != null && _count != 0)
                prev.Next = next;
            if (next != null && _count != 0)
                next.Previous = prev;

            del = null;
            _count--;
        }

        /// <summary>
        /// Removing a range of elements from a specified position
        /// </summary>
        /// <param name="pos"></param>
        public void RemoveRange(int pos)
        {
            try
            {
                while (_count>pos)
                {
                    Remove(pos);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                throw;
            }
        }
        public void RemoveRange(int pos1, int pos2)
        {

            //if (pos1 > pos2)
            //{
            //    throw new ArgumentException("pos1 must be < then pos");
            //}
            if (pos1 > pos2)
                (pos1, pos2) = (pos2, pos1);

            for (int index = pos2; index >= pos1; index--)
                Remove(index);
        }

        public bool Contains(T data)
        {
            Node current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void ReverseSort()
        {
            bool flag = true;
            for (int i = 1; i < _count; i++)
            {
                var cur = _head;
                for (int j = 0; j <= _count - i - 1; j++)
                {
                    if (cur.Data.CompareTo(cur.Next.Data) == -1)
                    {
                        flag = false;
                        var left = cur.Previous;
                        var right = cur.Next;
                        if (left != null)
                            left.Next = right;
                        else
                            _head = right;

                        cur.Next = right.Next;
                        cur.Previous = right;

                        if (right.Next != null)
                            right.Next.Previous = cur;
                        else
                            _tail = right.Previous;

                        right.Next = cur;
                        right.Previous = left;
                    }
                    else
                        cur = cur.Next;
                }
                if(flag)
                    break;
            }
        }
        public void Sort()
        {
            bool flag = true;
            for (int i = 1; i < _count; i++)
            {
                var cur = _head;
                for (int j = 0; j <= _count - i - 1; j++)
                {
                    if (cur.Data.CompareTo(cur.Next.Data) == 1)
                    {
                        flag = false;
                        var left = cur.Previous;
                        var right = cur.Next;
                        if (left != null)
                            left.Next = right;
                        else
                            _head = right;

                        cur.Next = right.Next;
                        cur.Previous = right;

                        if (right.Next != null)
                            right.Next.Previous = cur;
                        else
                            _tail = right.Previous;

                        right.Next = cur;
                        right.Previous = left;
                    }
                    else
                        cur = cur.Next;
                }
                if (flag)
                    break;
            }
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

        public IEnumerator<T> GetEnumerator()
        {
            Node current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        /// <summary>
        /// Upd: try use PrintBackward
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> BackEnumerator()
        {
            Node current = _tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

    }
}

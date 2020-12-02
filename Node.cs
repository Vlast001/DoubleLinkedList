using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyList
{
    public partial class DoubleList<T>
    {
        protected class Node
        {
            public T Data { get; set; }
            public Node(T data)
            {
                Data = data;
            }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public static bool operator >(Node a, Node b)
            {
                return a.Data.CompareTo(b.Data) == 1;
            }
            public static bool operator <(Node a, Node b)
            {
                return a.Data.CompareTo(b.Data) == -1;
            }
        }
    }
}

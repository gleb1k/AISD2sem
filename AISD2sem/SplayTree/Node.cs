using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD2sem.SplayTree
{
    // Узел АВЛ-дерева 
    public class Node
    {
        public int Key { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
    };
}

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

        public Node(int key, Node leftChild, Node rightChild)
        {
            Key = key;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
        public Node(int key)
        {
            Key = key;
        }
    }
}

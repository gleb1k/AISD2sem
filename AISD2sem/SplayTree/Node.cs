using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD2sem.SplayTree
{
    /// <summary>
    /// Узел бинарного дерева
    /// </summary>
    public class Node
    {
        public int Key { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Node Parent { get; set; }

        public Node(int key, Node leftChild, Node rightChild, Node parent)
        {
            Key = key;
            LeftChild = leftChild;
            RightChild = rightChild;
            Parent = parent;
        }
        public Node(int key, Node parent)
        {
            Key = key;
            Parent = parent;
        }
        public Node(int key)
        {
            Key = key;
        }
        public override string ToString()
        {
            return $"Узел: {Key}";
        }
    }
}

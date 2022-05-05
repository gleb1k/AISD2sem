using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD2sem.SplayTree
{
    public class SplayTreeRunner
    {
        public static void Run()
        {
            //Cоздание дерева
            Node root = new Node(100);
            SplayTree splayTree = new SplayTree();
            splayTree.Add(100);
            splayTree.Add(50);
            splayTree.Add(200);
            splayTree.Add(40);
            splayTree.Add(30);
            splayTree.Add(20);

            //root.LeftChild = new Node(50);
            //root.RightChild = new Node(200);
            //root.LeftChild.LeftChild = new Node(40);
            //root.LeftChild.LeftChild.LeftChild = new Node(30);
            //root.LeftChild.LeftChild.LeftChild.LeftChild = new Node(20);
            

            //Поворот дерева
            root = splayTree.Search(20);
            Console.Write("Preorder traversal of the" +
                          " modified Splay tree is \n");

            SplayTree.PreOrder(root);

        }
    }
}

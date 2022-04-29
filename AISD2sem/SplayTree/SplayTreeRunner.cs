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
            Node root = SplayTree.NewNode(100);
            
            root.LeftChild = SplayTree.NewNode(50);
            root.RightChild = SplayTree.NewNode(200);
            root.LeftChild.LeftChild = SplayTree.NewNode(40);
            root.LeftChild.LeftChild.LeftChild = SplayTree.NewNode(30);
            root.LeftChild.LeftChild.LeftChild.LeftChild = SplayTree.NewNode(20);
            

            //Поворот дерева
            root = SplayTree.Search(root, 20);
            Console.Write("Preorder traversal of the" +
                          " modified Splay tree is \n");

            SplayTree.PreOrder(root);

        }
    }
}

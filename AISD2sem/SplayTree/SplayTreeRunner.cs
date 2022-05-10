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

            SplayTree splayTree = new SplayTree();
            splayTree.Add(100);
            splayTree.Add(50);
            splayTree.Add(200);
            splayTree.Add(40);
            splayTree.Add(30);
            splayTree.Add(20);

            //string s = splayTree.BreadthFirst();
            //splayTree.InfixTraverse();

            //Поворот дерева
            splayTree.Search(20);

            //splayTree.InfixTraverse();
            //s = splayTree.BreadthFirst();

        }
    }
}

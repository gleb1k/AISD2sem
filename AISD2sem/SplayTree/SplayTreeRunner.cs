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
            //Создание дерева
            SplayTree splayTree = new SplayTree();
            splayTree.Add(100);
            splayTree.Add(50);
            splayTree.Add(200);
            splayTree.Add(40);
            splayTree.Add(30);
            splayTree.Add(20);

            //string s = splayTree.BreadthFirst();
            splayTree.InfixTraverse();

            //Поворот дерева
            splayTree.Search(20);

            splayTree.Remove(30);

            splayTree.InfixTraverse();
            //s = splayTree.BreadthFirst();


            //SplayTree splayTree = new SplayTree();
            
            //splayTree.Add(920);
            //splayTree.Add(92);
            //splayTree.Add(60);
            //splayTree.Add(693);
            //splayTree.Add(251);
            //splayTree.Add(146);
            //splayTree.Add(547);
            //splayTree.Add(343);
            //splayTree.Add(826);
            //splayTree.Add(1000);

            //splayTree.Remove(920);

            //string s = splayTree.BreadthFirst();


        }
    }
}

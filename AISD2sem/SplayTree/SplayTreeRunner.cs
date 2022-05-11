﻿using System;
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
            //splayTree.Add(100);
            //splayTree.Add(50);
            //splayTree.Add(200);
            //splayTree.Add(40);
            //splayTree.Add(30);
            //splayTree.Add(20);

            ////string s = splayTree.BreadthFirst();
            ////splayTree.InfixTraverse();

            ////Поворот дерева
            //splayTree.Search(20);

            ////splayTree.InfixTraverse();
            ////s = splayTree.BreadthFirst();
            ///SplayTree splayTree = new SplayTree();
            splayTree.Add(100);
            splayTree.Add(50);
            splayTree.Add(200);
            splayTree.Add(40);
            splayTree.Add(30);
            splayTree.Add(20);
            splayTree.Add(51);
            splayTree.Add(52);

            splayTree.Remove(50);

            string s = splayTree.BreadthFirst();


        }
        //черновик 
        static void Test()
        {
            SplayTree test = TreeFulling();
            for (int i = 0; i < 10; i++)
            {
                var rnd = new Random();
                AddTest(test, rnd.Next(1, 1000));
                RemoveTest(test, rnd.Next(1, 1000));
                SearchTest(test, rnd.Next(1, 1000));
            }
        }
        static void AddTest(SplayTree test, int key)
        {
            test.Add(key);
        }
        static void RemoveTest(SplayTree test, int key)
        {
            test.Remove(key);
        }
        static void SearchTest(SplayTree test, int key)
        {
            test.Search(key);
        }
        static SplayTree TreeFulling()
        {
            SplayTree test = new SplayTree();
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                test.Add(rnd.Next(1, 1000)); //Enumerable.Range(1, 100 + i * 100).Select(j => rnd.Next(1, 10000));
            }

            return test;
        }
    }
}

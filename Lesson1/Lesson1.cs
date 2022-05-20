using System;
using System.IO;
using Lesson1.Graphs;
using Lesson1.CodeForces;
using Lesson1.Multiplication;


namespace Lesson1
{
    class Lesson1
    {
        static void Main(string[] args)
        {
            //int[] arr1 = new int[] { 1, 10, 20, 30, 40, 50 };
            //int[] arr2 = new int[] { 2, 3, 10, 11, 23, 33, 50 };
            //ArrayTasks.Print(ArrayTasks.ArrayFusion(arr1, arr2));
            //int[] arr3 = ArrayTasks.ArrayDelete(arr1, arr2);
            //int[] arr4 = ArrayTasks.ArrayIntersection(arr1, arr2);

            //int[] arr5 = ArrayTasks.MultiArrayFusion(2);


            //string path = "C:\\Users\\gleb\\Desktop\\Прога\\AISD2sem\\Lesson1\\Arrays.txt";

            //int[] array4number = ArrayTasks.MultiArrayFusion(3, path);
            //int[] aa = ArrayTasks.ReadFromFile(path, 1);

            //ДОМАШКА 2 ----------------------------------------------------

            //int a =ArrayTasks.MajorityElement(new int[] {1,2,3,4,4,4,4,4,5} );

            //int[] array = new int[] { 1, 2, 3 };

            //ArrayTasks.RemoveAt(ref array, 1);
            //Console.WriteLine(array[0]);
            //Console.WriteLine(array[1]);

            //string[] result = Permutations.GetAllPermutations(array);

            //----------------------------------------------------------

            //int[,] wp = new int[,]
            //{
            //    {1,2},
            //    {2,1},
            //    {1,1}
            //};
            //DynamicTasks.KnapSack.Run();

            //DynamicTasks.Sakhir.Run();


            //DijkstraAlg dijAlg = new DijkstraAlg();
            //dijAlg.Run();
            //BellFordAlg dfa = new BellFordAlg();
            //dfa.Run();

            //_492B.Run();
            //Reposts.Run();
            //Reposts.Run2();

            //int[] ar = new int[] { 4, 33, 23, 66, 43, 0, 12, 5, 34, 99, 333333, 1 };
            ////int max = ArrayTasks.FindMaxRecursive(ar);
            //int max2 = ArrayTasks.FindMaxRecursive2(ar);

            //Karatsuba kar = new Karatsuba();
            //double d = kar.Calc(12345, 98765);

            MultiplicationRunner.Run();
        }
    }
}

using System;
using System.IO;
using System.Diagnostics;

namespace AISD2sem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка Шелла: ");
            string path = @"C:\Users\gleb\Desktop\Прога\gleb1k\AISD2sem\files\numbersF.txt";
            string pathTest = @"C:\Users\gleb\Desktop\Прога\gleb1k\AISD2sem\files\numbers2.txt";

            //FileTasks.FileFilling(path);

            int[][] intArray = FileTasks.ArrayRead(path);
            var list = FileTasks.ListRead(path);

            int iterations = 0;

            using var table = new StreamWriter(new FileStream(@"C:\Users\gleb\Desktop\Прога\gleb1k\AISD2sem\files\FileGrapgics.csv",
                FileMode.Create,
                FileAccess.Write)); //Табличка 

            for (int i = 0; i < intArray.Length; i++)
            {
                var timer = new Stopwatch();
                timer.Start();
                var result = Sort.ShellSort(intArray[i], ref iterations);
                timer.Stop();

                //table.WriteLine($"{intArray[i].Length}; {iterations}; {timer.Elapsed.Ticks}"); //Запись в табличку

            }

            //for (int i = 0; i < list.Count; i++)
            //{
            //    var timer = new Stopwatch();
            //    timer.Start();
            //    var result = Sort.ShellSort(list[i], ref iterations);
            //    timer.Stop();

            ////    table.WriteLine($"{list[i].Count}; {iterations}; {timer.Elapsed.Ticks}"); //Запись в табличку
            //}

        }
    }
}

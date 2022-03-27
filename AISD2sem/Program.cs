using System;
using System.IO;

namespace AISD2sem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка Шелла: ");
            //string path1 = @"C:\Users\gleb\Desktop\Прога\gleb1k\AISD2sem\numbers1.txt";
            string path2 = @"C:\Users\gleb\Desktop\Прога\gleb1k\AISD2sem\numbers2.txt";

            int[][] intArray = FileTasks<int>.ArrayRead2(path2);
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine($"{i}. Отсортированный массив: {string.Join(", ", ArrayShellSort.ShellSort(intArray[i]))}");
            }

            Console.WriteLine();

            var list = FileTasks<int>.ListRead(path2);
            Console.WriteLine($"Отсортированный список: {string.Join(", ", ListShellSort<int>.ShellSort(list))}");


        }
    }
}

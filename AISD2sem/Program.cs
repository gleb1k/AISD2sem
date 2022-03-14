using System;
using System.IO;

namespace AISD2sem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка Шелла");
            //Console.Write("Введите элементы массива: ");
            //var s = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            string[] s = new string[] { "100", "20", "30", "14", "1", "2", "3", "5", "4" };
            var array = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                array[i] = Convert.ToInt32(s[i]);
            }
            Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", Semestrovka.ShellSort(array)));

            
        }
    }
}

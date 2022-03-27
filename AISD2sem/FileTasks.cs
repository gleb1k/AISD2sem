using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD2sem
{
     public class FileTasks<T>
    {
        /// <summary>
        /// Считывает всё из файла в один массив, (все строки в один массив)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int[] ArrayRead(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            List<int> list = new List<int>();
            foreach (string line in lines)
            {
                list.AddRange(line.Split(' ', ',', ';')/*.Select(line => !string.IsNullOrEmpty(line)*/.Select(x => int.Parse(x)));
            }
            return list.ToArray();
        }
        /// <summary>
        /// Построчное считывание в зубчатый массив
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int[][] ArrayRead2(string path)
        {
            string[] rows = System.IO.File.ReadAllLines(path);
            int[][] array = new int[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                string[] numbers = rows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                array[i] = new int[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                array[i][j] = int.Parse(numbers[j]);
                }
            }
            return array;
        }
        /// <summary>
        /// Считывает всё из файла в один список, (все строки в один список)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<int> ListRead(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            List<int> list = new List<int>();
            foreach (string line in lines)
            {
                list.AddRange(line.Split(' ', ',', ';')/*.Select(line => !string.IsNullOrEmpty(line)*/.Select(x => int.Parse(x)));
            }
            return list;
        }
        public static void FileFilling(string path)
        {

            for (int i = 0; i < 100; i++)
            {

            }
        }
    }
}

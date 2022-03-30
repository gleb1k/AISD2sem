using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AISD2sem
{
     public class FileTasks
    {
        /// <summary>
        /// Считывает всё из файла в один массив, (все строки в один массив)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int[] ArrayRead2(string path)
        {
            string[] lines = File.ReadAllLines(path);
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
        public static int[][] ArrayRead(string path)
        {
            string[] rows = File.ReadAllLines(path);
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
        /// Построчное считывание в список списков
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<List<int>> ListRead(string path)
        {
            string[] rows = File.ReadAllLines(path);
            List<List<int>> list = new List<List<int>>(rows.Length) ;
            for (int i = 0; i < rows.Length; i++)
            {
                string[] numbers = rows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                list.Add(numbers.Select(int.Parse).ToList());
            }
            return list;
        }

        /// <summary>
        /// Считывает всё из файла в один список, (все строки в один список)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<int> ListRead2(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<int> list = new List<int>();
            foreach (string line in lines)
            {
                list.AddRange(line.Split(' ', ',', ';')/*.Select(line => !string.IsNullOrEmpty(line)*/.Select(x => int.Parse(x)));
            }
            return list;
        }
        /// <summary>
        /// 75 строк 100 до 10 000 элементов (числа от 1 до 1.
        /// </summary>
        /// <param name="path"></param>
        public static void FileFilling(string path)
        {
            Random random = new Random();

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 75; i++) //Колво строк
                {
                    int numCount = random.Next(100,10000); //Размер строки
                    for (int j = 0; j<numCount; j++)
                    {
                        sb.Append(random.Next(1, 10000) + " "); //Добавляем чиселки
                    }
                    writer.WriteLine(sb);
                    sb.Clear();
                }
            }

        }
    }
}

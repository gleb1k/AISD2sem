using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD2sem
{
    public class Sort
    {
        public static int[] ShellSort(int[] array, ref int iterations)
        {
            iterations = 0;
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        var t = array[j];
                        array[j] = array[j - d];
                        array[j - d] = t;
                        j = j - d;

                        iterations++;
                    }
                }
                d = d / 2;
            }
            return array;
        }
        public static List<int> ShellSort(List<int> list, ref int iterations)
        {
            iterations = 0;
            //расстояние между элементами, которые сравниваются
            var d = list.Count / 2;
            int listSize = list.Count;
            while (d >= 1)
            {
                for (var i = d; i < listSize; i++)
                {
                    var j = i;
                    while ((j >= d) && ((list[j - d].CompareTo(list[j]) == 1))) //array[j - d] > array[j]
                    {
                        var t = list[j];
                        list[j] = list[j - d];
                        list[j - d] = t;
                        j = j - d;

                        iterations++; //Кол-во итераций
                    }
                }
                d = d / 2;
            }
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD2sem
{
    public class ListShellSort<T> where T : IComparable<T>
    {
        public static List<T> ShellSort(List<T> list)
        {
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
                    }
                }
                d = d / 2;
            }
            return list;
        }
    }
}

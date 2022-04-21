using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson1
{
    class ArrayTasks
    {
        public static void Print<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
        public static int[] ArrayFusion(int[] a, int[] b)
        {
            if (a?.Length == 0 && b?.Length == 0)
            {
                throw new Exception("Оба массива пусты");
            }
            if (a?.Length == 0 && b?.Length > 0)
            {
                return b;
            }
            if (a?.Length > 0 && b?.Length == 0)
            {
                return a;
            }
            int i1 = 0;
            int i2 = 0;
            int[] result = new int[a.Length + b.Length];
            int iResult = 0;
            while (i1 < a.Length && i2 < b.Length)
            {
                if (a[i1] < b[i2])
                {
                    result[iResult] = a[i1];
                    i1++;
                }
                else
                {
                    result[iResult] = b[i2];
                    i2++;
                }
                iResult++;
            }
            if (i1 < a.Length)
                for (int i = i1; i < a.Length; i++)
                {
                    result[iResult] = a[i];
                    iResult++;
                }
            if (i2 < b.Length)
                for (int i = i1; i < a.Length; i++)
                {
                    result[iResult] = a[i];
                    iResult++;
                }
            return result;
        }

        // ВОТ ТУТ ПЕРВАЯ ДОМАШКА ---------------------------
        public static int[] ArrayDelete(int[] a, int[] b)
        {
            if (a?.Length == 0 && b?.Length == 0)
            {
                throw new Exception("Оба массива пусты");
            }
            if (a?.Length == 0 && b?.Length > 0)
            {
                return null;
            }
            if (a?.Length > 0 && b?.Length == 0)
            {
                return a;
            }
            int i1 = 0;
            int i2 = 0;
            int iResult = 0;
            int[] result = new int[a.Length];
            while (i1 < a.Length && i2 < b.Length)
            {
                if (a[i1] < b[i2])
                {
                    result[iResult] = a[i1];
                    i1++;
                    iResult++;
                }
                else if (a[i1] == b[i2])
                {
                    i1++;
                    i2++;
                }
                else if (a[i1] > b[i2])
                {
                    i2++;
                }
            }
            if (i1 < a.Length)
                for (int i = i1; i < a.Length; i++)
                {
                    result[iResult] = a[i];
                    iResult++;
                }

            if (i2 < b.Length)
                for (int i = i2; i < b.Length; i++)
                {
                    result[iResult] = b[i];
                    iResult++;
                }
            return result;
        }

        public static int[] ArrayIntersection(int[] arr1, int[] arr2)
        {
            if (arr1?.Length == 0 && arr2?.Length == 0)
            {
                Console.WriteLine("Arrays are empty");
                return null;
            }
            if (arr1?.Length == 0 && arr2?.Length > 0)
                return arr2;
            if (arr1?.Length > 0 && arr2?.Length == 0)
                return arr2;
            int[] result = new int[arr1.Length + arr2.Length];
            int i1 = 0;
            int i2 = 0;
            int iResult = 0;
            while (i1 < arr1.Length && i2 < arr2.Length)
            {
                if (arr1[i1] < arr2[i2])
                {
                    i1++;
                }
                else if (arr1[i1] == arr2[i2])
                {
                    result[iResult] = arr1[i1];
                    iResult++;
                    i1++;
                    i2++;
                }
                else i2++;
            }
            return result;
        }

        public static int[] MultiArrayFusion(int k, string path)
        {
            int[] result = new int[0];
            for (int i = 1; i <= k; i++)
            {
                int[] arr = ReadFromFile(path, i);
                result = ArrayFusion(result, arr);
            }
            return result;
        }
        public static int[] ReadFromConsole()
        {
            Console.Write("Задайте массив: ");
            string[] s = Console.ReadLine().Split(' ');
            int[] result = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                result[i] = Int32.Parse(s[i]);
            }
            return result;
        }
        /// <summary>
        /// Cчитывание строки в массив инт
        /// </summary>
        /// <param name="path"></param>
        /// <param name="numberOfLine">номер считываемой строки</param>
        /// <returns></returns>
        public static int[] ReadFromFile(string path, int numberOfLine)
        {
            if (File.Exists(path) == false)
            {
                throw new Exception("Указанный файл не найден");
            }
            string line = File.ReadLines(path).Skip(numberOfLine - 1).First();
            int[] result = line.Split(' ').Select(x => int.Parse(x)).ToArray();
            return result;
        }
        //Конец первой домашки ---------------------
        public static Couple[] UniqNumCount(int[] array)
        {
            if (array == null)
            {
                throw new Exception("Массив пуст!");
            }
            Couple[] couple = new Couple[0];
            foreach (var el in array)
            {
                int i = 0;
                while (i < couple.Length)
                {
                    if (couple[i].Key == el)
                    {
                        couple[i].Value++;
                        break;
                    }
                    i++;
                }
                if (i == couple.Length)
                {
                    Array.Resize(ref couple, couple.Length + 1);
                    couple[i] = new Couple(el, 1);

                }
            }
            return couple;
        }
        //ВОТ ОТСЮДА ПОШЛА 2 ДОМАШКА -------------------------------

        public static int MajorityElement(int[] array)
        {
            Couple[] couple = UniqNumCount(array);
            int majorityEl = 0;
            double majorityCount = (double)array.Length / 2.0;
            foreach (var element in couple)
            {
                if (element.Value >= majorityCount)
                {
                    majorityEl = element.Key;
                    majorityCount = element.Value;
                }
            }
            return majorityEl;
        }

        public static void RemoveAt(ref int[] array, int k)
        {
            if (k < 0)
                throw new ArgumentOutOfRangeException("Элемента меньше нуля не существует");
            if (k >= array.Length)
                throw new ArgumentOutOfRangeException("Индекс больше длины массива");
            for (int i = k; i < array.Length-1; i++)
            { 
                array[i] = array[i + 1];
            }

            Array.Resize<int>(ref array, array.Length - 1);
        }
        /// <summary>
        /// Максимальный элемент в массиве методом разделяй и властвуй. Дз до 21.04.22
        /// </summary>
        /// <returns></returns>
        public static int FindMaxRecursive(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"Массив нулл");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"Массив пуст");
            }

            return FindMax(array, 0);
        }
        private static int FindMax(int[] array, int index, int currentMax = 0)
        {
            if (index == 0)
            {
                currentMax = array[0];
            }

            if (index == array.Length)
            {
                return currentMax;
            }
            else
            {
                currentMax = Math.Max(currentMax, array[index]);
                return FindMax(array, index + 1, currentMax);
            }
        }
        /// <summary>
        /// Второй способ поиска максимума рекурсивно (более правильный вариант)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static int FindMaxRecursive2(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"Массив нулл");
            }
            if (array.Length == 0)
            {
                throw new ArgumentException($"Массив пуст");
            }

            if (array.Length == 1)
            {
                return array[0];
            }
            else
            {
                int mid = array.Length / 2;
                int[] left = new int[mid];
                int[] right = new int[array.Length - mid];

                for (int i = 0; i < mid; i++)
                {
                    left[i] = array[i];
                }
                for (int i = mid; i < array.Length; i++)
                {
                    right[i - mid] = array[i];
                }

                return Math.Max(FindMaxRecursive2(left),FindMaxRecursive2(right));
            }
        }
        /// <summary>
        /// Сортировка слиянием
        /// </summary>
        /// <param name="array"></param>
        public static void MergeSort(int[] array)
        {
            if (array.Length == 1)
                return;
            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            for (int i = 0; i < mid; i++)
            {
                left[i] = array[i];
            }
            for (int i = mid; i < array.Length; i++)
            {
                right[i - mid] = array[i];
            }

            MergeSort(left);
            MergeSort(right);
            Merge(array, left, right);
        }
        private static void Merge(int[] targetArray, int[] array1, int[] array2)
        {
            int array1MinIndex = 0;
            int array2MinIndex = 0;

            int targetArrayMinIndex = 0;

            //заполняем пока не кончится один из массивов
            while (array1MinIndex < array1.Length && array2MinIndex < array2.Length)
            {
                if (array1[array1MinIndex] < array2[array2MinIndex])
                {
                    targetArray[targetArrayMinIndex] = array1[array1MinIndex];
                    array1MinIndex++;
                }
                else
                {
                    targetArray[targetArrayMinIndex] = array2[array2MinIndex];
                    array2MinIndex++;
                }
                targetArrayMinIndex++;
            }
            //дозаполняем оставшимся
            while (array1MinIndex < array1.Length)
            {
                targetArray[targetArrayMinIndex] = array1[array1MinIndex];
                array1MinIndex++;
                targetArrayMinIndex++;
            }
            while (array2MinIndex < array2.Length)
            {
                targetArray[targetArrayMinIndex] = array2[array2MinIndex];
                array2MinIndex++;
                targetArrayMinIndex++;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public static class Permutations
    {
        public static List<string> GetAllPermutations(List<int> input)
        {
            if (input == null)
                throw new ArgumentNullException("Входящий массив не инициализирован");

            if (input.Distinct().Count() != input.Count())
                throw new ArgumentException("Входящий массив содержит повторения");

            var result = new List<string>();

            GetAllPermutations(input, ref result);

            return result;
        }

        private static void GetAllPermutations(List<int> input,
            ref List<string> result, string current = "")
        {
            if (input.Count == 0)
            {
                result.Add(current);
                return;
            }
            for (int i = 0; i < input.Count; i++)
            {
                var newInput = new List<int>(input);
                newInput.RemoveAt(i);
                GetAllPermutations(newInput, ref result, current + " " + input[i]);
            }
        }
        public static string[] GetAllPermutations(int[] input)
        {
            if (input == null)
                throw new ArgumentNullException("Входящий массив не инициализирован");

            if (input.Distinct().Count() != input.Count())
                throw new ArgumentException("Входящий массив содержит повторения");

            var result = new string[0];

            GetAllPermutations(input, ref result);

            return result;
        }

        private static void GetAllPermutations(int[] input,
            ref string[] result, string current = "")
        {
            if (input.Count() == 0)
            {
                var length = result.Length;
                Array.Resize<string>(ref result, length + 1);
                result[length] = current;
                return;
            }
            for (int i = 0; i < input.Count(); i++)
            {
                int[] newInput = (int[])input.Clone();
                ArrayTasks.RemoveAt(ref newInput, i);
                GetAllPermutations(newInput, ref result, current + " " + input[i]);
            }
        }

        public static bool SummaExist(int a, int b, int c)
        {
            //baobab
        }
    }
}

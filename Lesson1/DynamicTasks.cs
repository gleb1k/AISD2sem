using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class DynamicTasks
    {
        public static class KnapSack
        {
            public static void Run()
            {
                //    var c = new[] { 3, 5, 8, 1, 2 };
                //    var w = new[] { 5, 3, 8, 1, 3 };
                //    int W = 15;


                var c = new[] { 1, 2, 1 };
                var w = new[] { 2, 1, 1 };
                int W = 2;

                var d = new int[c.Length + 1, W + 1];

                for (int i = 1; i <= c.Length; i++)
                    for (var j = 0; j <= W; j++)
                    {
                        d[i, j] = d[i - 1, j];
                        if (j - w[i - 1] >= 0)
                            d[i, j] = Math.Max(d[i, j], d[i - 1, j - w[i - 1]] + c[i - 1]);
                    }


                for (int i = 1; i <= c.Length; i++)
                {
                    Console.Write("k = " + i + " ");
                    for (var j = 0; j <= W; j++)
                        Console.Write(d[i, j] + " ");
                    Console.WriteLine();
                }
            }
        }


    }
}

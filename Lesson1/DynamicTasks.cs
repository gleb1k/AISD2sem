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
        public class Sakhir
        {
            public static void Run()
            {
                var building = GetBuilding();
                int floorCount = building.GetLength(0);
                int roomCount = building.GetLength(1)-2;  

                var dp = new int[floorCount, 4];
                dp[0, 2] = Int32.MaxValue;
                dp[0, 3] = Int32.MaxValue;

                for (int i = 0; i < floorCount; i++)
                {
                    CalcFloor(i, building,ref dp);
                }
                Console.WriteLine($"Колво минут:{ Math.Min(dp[0, floorCount - 1], dp[2, floorCount - 1])}");
            }
            private static void CalcFloor(int floor, int[,] building
                ,ref int[,] dp)
            {
                
            }
            private static int[,] GetBuilding()
            {
                return new int[,]
                {
                    {0,0,0,0,1,0},
                    {0,0,0,0,1,0},
                    {0,0,1,0,0,0}
                };
            }
        }

        public static class RobotPath
        {

        }


    }
}

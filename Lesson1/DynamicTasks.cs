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



        public static class Sakhir
        {
            public static void Run()
            {
                //исходные данные
                var building = GetBuilding();
                int floorCount = building.GetLength(0);
                int roomCount = building.GetLength(1) - 2;
                /*1) выходим с левой лестницы и возвращаемся в левую лестницу
                  2) выходим с левой лестницы, переходим в правую лестницу
                  3) выходим с правой лестницы, возвращаемся в правую лестницу
                  4) выходим с правой лестницы, переходим в левую лестницу 
                */
                //матрица для шагов дп
                var dp = new int[floorCount, 4];

                for (int i = 0; i < floorCount; i++)
                    CalcFloor(i, floorCount, roomCount, building, ref dp);

                Console.WriteLine($"Количество минут " +
                    $"{Math.Min(dp[0, floorCount - 1], dp[2, floorCount - 1])}");

            }
            /// <summary>
            /// Считаем количество минут для одного этажа
            /// </summary>
            /// <param name="floor">текущий номер этажа</param>
            /// <param name="building">матрица здания</param>
            /// <param name="dp">матрица для ДП</param>
            private static void CalcFloor(int floor, int floorCount,
                int roomCount, int[,] building, ref int[,] dp)
            {
                //находим самую левую комнату с вкл светом
                int mostLeftRoomWithLight = 0;
                //самая правая комната с вкл светом
                int mostRightRoomWithLight = roomCount + 1;
                GetMostLeftRight(floor, roomCount, building,
                    ref mostLeftRoomWithLight, ref mostRightRoomWithLight);


                //общий случай (не первый и не последний этажи) 
                if (floor > 0 && floor < floorCount - 1)
                {
                    //выходим с левой лестницы и возвращаемся в левую лестницу
                    dp[floor, 0] =
                        //стоимость дойти до floor - 1 этажа
                        Math.Min(dp[floor - 1, 0], dp[floor - 1, 3]) +
                        //стоимость подъема на этаж
                        1 +
                        //стоимость дойти до последней комнаты 
                        //с вкл светом и обратно
                        mostRightRoomWithLight + mostRightRoomWithLight;

                    //выходим с левой лестницы, переходим в правую лестницу
                    dp[floor, 1] =
                        //стоимость дойти до floor - 1 этажа
                        Math.Min(dp[floor - 1, 0], dp[floor - 1, 3]) +
                        //стоимость подъема на этаж
                        1 +
                        //стоимость пройти весь этаж
                        roomCount + 1;

                    //выходим с правой лестницы, возвращаемся в правую лестницу
                    dp[floor, 2] =
                        //стоимость дойти до floor - 1 этажа
                        Math.Min(dp[floor - 1, 1], dp[floor - 1, 2]) +
                        //стоимость подъема на этаж
                        1 +
                        //стоимость дойти до самой левой комнаты со светом и обратно
                        //= 1(стоимость перейти с лестницы на этаж)
                        // + количество шагов до самой левой комнаты 
                        (1 + roomCount - mostLeftRoomWithLight) * 2;

                    //выходим с правой лестницы, переходим в левую лестницу 
                    dp[floor, 3] =
                        //стоимость дойти до floor - 1 этажа
                        Math.Min(dp[floor - 1, 1], dp[floor - 1, 2]) +
                        //стоимость подъема на этаж
                        1 +
                        //пройти по всему этажу
                        roomCount + 1;
                }
                //первый этаж
                else if (floor == 0)
                {
                    //выходим с левой лестницы и возвращаемся в левую лестницу
                    dp[0, 0] = mostRightRoomWithLight * 2;
                    //выходим с левой лестницы, переходим в правую лестницу
                    dp[0, 1] = roomCount + 1;

                    //начинаем всегда с левой лестницы, 
                    //поэтому выход с правой помечаем 
                    //как Int32.MaxValue
                    dp[0, 2] = Int32.MaxValue;
                    dp[0, 3] = Int32.MaxValue;
                }


            }

            /// <summary>
            /// Самая левая и самая правая комната с включенным светом на этаже 
            /// </summary>
            private static void GetMostLeftRight(int floor, int roomCount, int[,] building,
                ref int mostLeftRoomWithLight, ref int mostRightRoomWithLight)
            {
                for (int i = 1; i <= roomCount; i++)
                {
                    if (building[floor, i] == 1)
                    {
                        if (mostLeftRoomWithLight == 0)
                            mostLeftRoomWithLight = i;
                        mostRightRoomWithLight = i;
                    }
                }
            }

            private static int[,] GetBuilding()
            {
                return new int[,]
                {
                { 0,0,0,0,1,0 },
                { 0,0,0,0,1,0 },
                { 0,0,1,0,0,0 }
                };
            }
        }


        public static class RobotPath
        {

        }



    }
}

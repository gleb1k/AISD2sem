using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class DijkstraAlg
    {
        public  void Run()
        {

            var graph = GetGraph();
            var vCount = graph.GetLength(0);
            //Вершины, которые надо обойти
            var vForVisit = new List<int>() { 0 };
            //Посещенные вершины
            var vVisited = new List<int>();
            //Массив с расстояниями
            var distances = new int[vCount];
            //инициализация расстояний до других вершин
            for (int i = 1; i < vCount; i++)
                distances[i] = Int32.MaxValue;

            while (vForVisit.Count > 0)
            {
                var currentV = vForVisit.First();
                vForVisit.Remove(currentV);
                vVisited.Add(currentV);
                //Пройдемся по строке данной вершины
                for (int i = 0; i < vCount; i++)
                {
                    //если вершину уже посещали, то не обрабатываем
                    if (vVisited.Contains(i) || graph[currentV, i] == 0)
                        continue;
                    vForVisit.Add(i);
                    distances[i] =
                        distances[i] < distances[currentV]
                        + graph[currentV, i]
                        ? distances[i]
                        : distances[currentV] + graph[currentV, i];
                }
            }
        }
        public int[,] GetGraph()
        {
            return new int[,]
            {
                {0,7,9,0,0,14},
                {7,0,10,15,0,0},
                {9,10,0,11,0,2},
                {0,15,11,0,6,0},
                {0,0,0,6,0,9},
                {14,0,2,0,9,0}
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Graphs
{
    public class BellFordAlg
    {
        public void Run()
        {
            var ribs = new (int, int, int)[8]
                {
                (0,1,-1),
                (0,2,4),
                (1,2,3),
                (1,3,2),
                (1,4,2),
                (3,1,1),
                (3,2,5),
                (4,3,-3)
                };
            int[] dist = new int[5];
            for (int i = 1; i < 5; i++)
            {
                dist[i] = Int32.MaxValue;
            }
            for (int i = 1; i < dist.Length; i++)
            {
                foreach (var rib in ribs)
                {
                    if (dist[rib.Item1] > dist[rib.Item2] + rib.Item3)
                        dist[rib.Item1] = dist[rib.Item2] + rib.Item3;
                }
            }
                
        }
    }
}

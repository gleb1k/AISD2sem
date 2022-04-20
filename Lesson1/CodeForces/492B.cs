using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.CodeForces
{
    public class _492B //ваня и фонари
    {
        public static void Run()
        {
            //Console.WriteLine("Задайте n и l: ");
            
            int[] nl = Console.ReadLine().Split(' ').
            Where(x => !string.IsNullOrWhiteSpace(x)).
            Select(x => int.Parse(x)).ToArray();
            int n = nl[0];
            int l = nl[1];
            //int[] dist = new int[n];
            int[] dist = Console.ReadLine().Split(' ').
            Where(x => !string.IsNullOrWhiteSpace(x)).
            Select(x => int.Parse(x)).ToArray();
            
            dist = dist.OrderBy(x => x).ToArray();
            double maxDist = 0;
            for (int i = 0; i < dist.Length - 1; i++)
            {
                if ((dist[i + 1] - dist[i]) > maxDist)
                {
                    maxDist = dist[i + 1] - dist[i];
                }
            }
            double radiusFonyar = maxDist / 2;
            if ((dist[0] != 0) && (dist[0] > radiusFonyar))
                radiusFonyar = dist[0];
            if ((dist[dist.Length - 1] != l) && (l - dist[dist.Length - 1] > radiusFonyar))
                radiusFonyar = l - dist[dist.Length - 1];

            Console.WriteLine(radiusFonyar);
        }
    }
}

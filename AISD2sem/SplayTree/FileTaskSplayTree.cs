using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD2sem.SplayTree
{
    public class FileTaskSplayTree
    {
        static void Test()
        {
            SplayTree test = TreeFulling();
            for (int i = 0; i < 10; i++)
            {
                var rnd = new Random();
                AddTest(test, rnd.Next(1, 1000));
                RemoveTest(test, rnd.Next(1, 1000));
                SearchTest(test, rnd.Next(1, 1000));
            }
        }
        static void AddTest(SplayTree test, int key)
        {
            test.Add(key);
        }
        static void RemoveTest(SplayTree test, int key)
        {
            test.Remove(key);
        }
        static void SearchTest(SplayTree test, int key)
        {
            test.Search(key);
        }
        static SplayTree TreeFulling()
        {
            SplayTree test = new SplayTree();
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                test.Add(rnd.Next(1, 1000)); //Enumerable.Range(1, 100 + i * 100).Select(j => rnd.Next(1, 10000));
            }

            return test;
        }
    }
}

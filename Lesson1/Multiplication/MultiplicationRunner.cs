using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Multiplication
{
    public static class MultiplicationRunner
    {
        public static void Run()
        {
            var bm = new BinaryMultiply();
            double result = bm.Calc("101", "101");
        }
    }
}

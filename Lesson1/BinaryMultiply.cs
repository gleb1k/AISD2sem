using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class BinaryMultiply
    {
        public double Calc(string str1, string str2)
        {
            int a = Convert.ToInt32(str1);
            int b = Convert.ToInt32(str2);

            if (a == 1) return b;
            if (b == 1) return a;
            if (a == 0) return 0;
            if (b == 0) return 0;

            
            throw new NotImplementedException();
        }
    }
}

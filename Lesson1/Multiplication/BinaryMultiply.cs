using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Multiplication
{

    public class BinaryMultiply
    {
        //Тупое решение в лоб
        public double Calc(string str1, string str2)
        {
            int a = Convert.ToInt32(str1);
            int b = Convert.ToInt32(str2);

            //Элементарный случай случай
            if (a == 1) return b;
            if (b == 1) return a;
            if (a == 0) return 0;
            if (b == 0) return 0;


            int result = 0;
            int number = 1;

            while (b != 0)
            {
                number = b % 10;

                if (number == 1)
                {
                   
                }
                else
                {
                   
                }

                
            }
            return result;
        }
    }
}

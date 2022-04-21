using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public class Karatsuba
    {
        public double Calc(int a, int b)
        {
            var res = Cacl(new Number(a, 0), new Number(b, 0));
            return (res.Numeral * Math.Pow(10, res.Discharge));

        }
        private int IntLength(int a )
        {
            int i = 0;  
            while (a!=0)
            {
                i++;
                a = a / 10;
            }
            return i;
        }
        private Number Cacl (Number a, Number b)
        {
            if (b.Numeral == 0 || a.Numeral == 0) return new Number(0, 0);
            if (a.Numeral == 1) return new Number(b.Numeral, b.Discharge + a.Discharge);
            if (b.Numeral == 1) return new Number(a.Numeral, b.Discharge + a.Discharge);
            if (a.Numeral < 10 || b.Numeral < 10) return new Number(b.Numeral * a.Numeral, 0);


            return new Number(0, 0);


        }
    }
    public struct Number
    {
        /// <summary>
        /// 
        /// </summary>
        public int Numeral;
        /// <summary>
        /// Cдвиг
        /// </summary>
        public int Discharge;
        public Number(int num, int dis)
        {
            Numeral = num;
            Discharge = dis;
        }

    }
    
}

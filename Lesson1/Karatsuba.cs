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
            var result = calc(new Number(a, 0), new Number(b, 0));
            return (result.Numeral * Math.Pow(10, result.Discharge));
        }
        /// <summary>
        /// Неоптимальный метод нахождения длины интового числа
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private int IntLength(int a)
        {
            int i = 1;
            while (a / 10 != 0)
            {

                i++;
                a /= 10;
            }
            return i;
        }
        private Number calc(Number a, Number b)
        {
            if (b.Numeral == 0 || a.Numeral == 0) return new Number(0, 0);
            if (a.Numeral == 1) return new Number(b.Numeral, b.Discharge + a.Discharge);
            if (b.Numeral == 1) return new Number(a.Numeral, b.Discharge + a.Discharge);
            if (a.Numeral < 10 || b.Numeral < 10) return new Number(b.Numeral * a.Numeral, 0);

            int aLength = IntLength(a.Numeral);
            int bLength = IntLength(b.Numeral);
            int halfLength1 = aLength / 2;
            int halfLength2 = bLength / 2;

            Number a1 = new Number(Convert.ToInt32(a.Numeral / Math.Pow(10, halfLength1)), 1);
            Number a2 = new Number(Convert.ToInt32(a.Numeral % Math.Pow(10, aLength - halfLength1)), 0);
            Number b1 = new Number(Convert.ToInt32(b.Numeral / Math.Pow(10, halfLength2)), 1);
            Number b2 = new Number(Convert.ToInt32(b.Numeral % Math.Pow(10, bLength - halfLength2)), 0);

            Number ac = calc(a1, b1);
            Number bd = calc(a2, b2);
            Number bigsum = calc(new Number(a1.Numeral + a2.Numeral, 0), new Number(b1.Numeral + b2.Numeral, 0));
            int x = Convert.ToInt32(Math.Sqrt(ac.Discharge));

            Number middleExpression = new Number (bigsum.Numeral - ac.Numeral - bd.Numeral, x);
            //int numeralResult = Convert.ToInt32(ac.Numeral * Math.Pow(10, ac.Discharge)
            //                    + middleExpression.Numeral * Math.Pow(10,middleExpression.Discharge) + bd.Numeral);
            //return new Number(numeralResult, 0);

            //Как мне собрать число воедино?? 2*10^2 + 7*10 + 6 => в Number ? если Number.Numeral.type == int ?? 
            //Если бы было double я мог бы 276 / 10^2 =2.76 и засунуть в new Number(2,76 , 2) == 276;
            throw new Exception();
        }
    }
    /// <summary>
    /// Структура числа с ее разрядом
    /// </summary>
    public class Number
    {
        /// <summary>
        /// цифра
        /// </summary>
        public int Numeral;
        /// <summary>
        ///  разряд
        /// </summary>
        public int Discharge;

        public Number(int numeral, int discharge)
        {
            Numeral = numeral;
            Discharge = discharge;
        }
    }

}

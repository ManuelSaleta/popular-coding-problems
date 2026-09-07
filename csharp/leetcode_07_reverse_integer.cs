using System;
using System.Collections.Generic;
using System.Text;

namespace SandBox
{
    public static class ReverseInteger
    {
        public static int Reverse(int num)
        {
            var revNum = 0;
            var isNeg = false;

            if (num < 0)
            {
                isNeg = true;
                num *= -1; // make pos
            }
            while (num > 0)
            {
                var pop = num % 10;
                num /= 10;
                // overflow check
                if (revNum > int.MaxValue / 10 || (revNum == int.MaxValue / 10 && pop > 7)) return 0;
                if (revNum < int.MinValue / 10 || (revNum == int.MinValue / 10 && pop < -8)) return 0;
                
                revNum = revNum * 10 + pop;
            }

            if (isNeg)
                revNum *= -1;
            return revNum;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace NextBiggerNumber
{
    public class NextBiggerNumber
    {
        public static long Find(long n)
        {
            List<int> digitsFirstNumber = NumberToDigitsList(n);
            var tempList = digitsFirstNumber;
            tempList.Sort();
            tempList.Reverse();
            long maxValue = IntListToInt(tempList);
            if(maxValue == n) { return -1; }

            long firstNumber = n;
            while (true)
            {
                firstNumber += 1;
                List<int> digitsNewNumber = NumberToDigitsList(firstNumber);
                digitsFirstNumber.Sort();
                digitsNewNumber.Sort();
                if (Enumerable.SequenceEqual(digitsNewNumber, digitsFirstNumber))
                {
                    return firstNumber;
                }
            }
        }

        private static long IntListToInt(List<int> digits)
        {
            long number = 0;
            for (int i = 0; i < digits.Count; i++)
            {
                number += (long)(digits[i] * (Math.Pow(10, digits.Count - i - 1)));
            }
            return number;
        }

        private static List<int> SwapElementsInList(int IDfirst, int IDsecond, List<int> digits)
        {
            int temp = digits[IDfirst];
            digits[IDfirst] = digits[IDsecond];
            digits[IDsecond] = temp;

            return digits;
        }

        private static List<int> NumberToDigitsList(long n)
        {
            List<int> digits = new List<int>();

            while (n != 0)
            {
                digits.Add((int)(n % 10));
                n /= 10;
            }

            digits.Reverse();

            return digits;
        }
    }
}

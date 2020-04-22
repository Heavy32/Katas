using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PositionsAverage
{
    public class PositionsAverage
    {
        public double Count(string s)
        {         
            string[] numbers = Regex.Replace(s, @"\s+", "").Split(',');
            double counter = default;
            double operationsCounter = default;

            
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    for (int k = 0; k < numbers[i].Length; k++)
                    {
                        if (numbers[i][k] == numbers[j][k])
                            counter++;
                        operationsCounter++;
                    }
                }
            }
            return Math.Round((counter / operationsCounter * 100), 10);
        }
    }
}

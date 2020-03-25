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
            
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    for (int k = 0; k < numbers[i].Length; k++)
                    {
                        if (numbers[i][k] == numbers[j][k])
                            counter++;
                    }
                }
            }

            return Math.Round((counter / (numbers[0].Length * numbers.Length * (numbers.Length - 1) / 2)) * 100, 10);
        }
    }
}

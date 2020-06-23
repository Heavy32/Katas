using System;
using System.Collections.Generic;
using System.Linq;

namespace SnailWay
{
    public class SnailWay
    {
        public static int[] CalculateWay(int[][] grid)
        {
            List<int> snailWay = new List<int>();
            var tempGrid = grid as IEnumerable<IEnumerable<int>>;

            while (tempGrid.Count() != 0)
            {
                snailWay.AddRange(tempGrid.ElementAt(0));
                tempGrid = tempGrid.Skip(1);
                snailWay.AddRange((tempGrid.Select(line => line.Last())));
                tempGrid = tempGrid.Select(line => line.SkipLast(1))
                              .Reverse()
                              .Select(line => line.Reverse());
            }
            return snailWay.ToArray();
        }
    }
}
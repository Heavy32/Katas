using System;
using System.Collections.Generic;
using System.Linq;

namespace SnailWay
{
    public class SnailWay
    {
        public static int[] CalculateWay(int[][] grid)
        {
            if(grid == null)
            {
                return null;
            }

            List<int> snailWay = new List<int>();

            while (grid.Count() != 0)
            {
                snailWay.AddRange(grid[0]);
                grid = grid.Skip(1).ToArray();
                snailWay.AddRange(grid.Select(line => line[^1]));
                grid = grid.Select(line => line.SkipLast(1).Reverse().ToArray()).Reverse().ToArray();
            }

            return snailWay.ToArray();
        }
    }
}
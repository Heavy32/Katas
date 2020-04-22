using System;
using System.Collections.Generic;
using System.Linq;

namespace SnailWay
{
    public class SnailWay
    {
        public static int[] CalculateWay(int[][] grid, List<int> snailWay)
        {
            snailWay.AddRange(grid[0]);
            grid = grid.Skip(1).ToArray();

            snailWay.AddRange(grid.Where((item, index) => index != grid.Length - 1).Select(x => x.Last()).ToArray());
            grid = Enumerable.Range(0, grid.Length).Select(x => (x == grid.Length - 1) ? grid[x] : grid[x].Where((number, index) => index != grid[x].Length - 1).ToArray()).ToArray();

            Array.Reverse(grid);
            grid = grid.Select(x => x.Reverse().ToArray()).ToArray();

            return (grid.Length == 0) ? snailWay.ToArray() : CalculateWay(grid, snailWay);
        }
    }
}

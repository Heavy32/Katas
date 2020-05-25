using System.Collections.Generic;
using System.Linq;

namespace SnailWay
{
    public class SnailWay
    {
        public static int[] CalculateWay(int[][] grid)
        {
            List<int> snailWay = new List<int>();
            var tempGrid = grid.Select(item => item);

            while (tempGrid.Count() != 0)
            {
                snailWay.AddRange(tempGrid.ElementAt(0));
                tempGrid = tempGrid.Skip(1);

                snailWay.AddRange(tempGrid.Where((item, index) => index != tempGrid.Count() - 1).Select(x => x.Last()));
                tempGrid = Enumerable.Range(0, tempGrid.Count()).Select(x => (x == tempGrid.Count() - 1) ? tempGrid.ElementAt(x) : tempGrid.ElementAt(x).Where((number, index) => index != tempGrid.ElementAt(x).Count() - 1).ToArray()).Reverse().Select(x => x.Reverse().ToArray());
            }

            return snailWay.ToArray();
        }
    }
}

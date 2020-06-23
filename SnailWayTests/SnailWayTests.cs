using NUnit.Framework;

namespace SnailWay.Tests
{
    public class SnailWayTests
    {
        [Test]
        public void Array4x4()
        {
            int[][] grid =
            {
                new []{ 1, 2, 3, 9 },
                new []{ 4, 5, 6, 4 },
                new []{ 7, 8, 9, 1 },
                new []{ 1, 2, 3, 4 },
            };

            Assert.AreEqual(new int[] { 1, 2, 3, 9, 4, 1, 4, 3, 2, 1, 7, 4, 5, 6, 9, 8 }, SnailWay.CalculateWay(grid));
        }

        [Test]
        public void Array3x3()
        {
            int[][] grid =
            {
                new []{ 1, 2, 3},
                new []{ 8, 9, 4},
                new []{ 7, 6, 5},
            };

            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SnailWay.CalculateWay(grid));
        }
    }
}
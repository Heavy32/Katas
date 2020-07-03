using NUnit.Framework;
using System.Linq;

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

        [Test]
        public void NullArray()
        {
            int[][] grid = null;

            Assert.AreEqual(null, SnailWay.CalculateWay(grid));
        }

        [Test]
        public void Array1x1()
        {
            int[][] grid = new[] { new[] { 1 } };

            Assert.AreEqual(new[] { 1 }, SnailWay.CalculateWay(grid));
        }

        [Test]
        public void Array3x3RepeatedDigits()
        {
            int[][] grid =
            {
                new[] { 1, 2, 3 },
                new[] { 1, 2, 3 },
                new[] { 1, 2, 3 },
            };

            Assert.AreEqual(new[] { 1,2,3,3,3,2,1,1,2 }, SnailWay.CalculateWay(grid));
        }

        [Test]
        public void Array3x3SameDigits()
        {
            int[][] grid =
            {
                new[] { 1, 1, 1 },
                new[] { 1, 1, 1 },
                new[] { 1, 1, 1 },
            };

            Assert.AreEqual(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, SnailWay.CalculateWay(grid));
        }

        [Test]
        public void Array10x10()
        {
            int[][] grid = new[]
            {
                new []{0,1,2,3,4,5,6,7,8,9},
                new []{0,1,2,3,4,5,6,7,8,9},
                new []{0,1,2,3,4,5,6,7,8,9},
                new []{0,1,2,3,4,5,6,7,8,9},
                new []{0,1,2,3,4,5,6,7,8,9},
                new []{0,1,2,3,4,5,6,7,8,9},
                new []{0,1,2,3,4,5,6,7,8,9},
                new []{0,1,2,3,4,5,6,7,8,9},
                new []{0,1,2,3,4,5,6,7,8,9},
                new []{0,1,2,3,4,5,6,7,8,9},
            };

            int[] ExpectedSnailWay = new int[]
            {
                0,1,2,3,4,5,6,7,8,9,
                9,9,9,9,9,9,9,9,9,8,
                7,6,5,4,3,2,1,0,0,0,
                0,0,0,0,0,0,1,2,3,4,
                5,6,7,8,8,8,8,8,8,8,
                8,7,6,5,4,3,2,1,1,1,
                1,1,1,1,2,3,4,5,6,7,
                7,7,7,7,7,6,5,4,3,2,
                2,2,2,2,3,4,5,6,6,6,
                6,5,4,3,3,3,4,5,5,4
            };
            Assert.AreEqual(ExpectedSnailWay, SnailWay.CalculateWay(grid));
        }
    }
}
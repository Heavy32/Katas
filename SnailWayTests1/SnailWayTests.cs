using NUnit.Framework;
using SnailWay;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnailWay.Tests
{
    [TestFixture]
    public class SnailWayTests
    {
        [Test]
        public void CalculateWayTest()
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
    }
}
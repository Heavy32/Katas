using NUnit.Framework;

namespace PositionsAverageTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string s = "444996, 699990, 666690, 096904, 600644, 640646, 606469, 409694, 666094, 606490";
            PositionsAverage.PositionsAverage positionsAverage = new PositionsAverage.PositionsAverage();

            Assert.AreEqual(29.2592592593, positionsAverage.Count(s));
        }

        [Test]
        public void Test2()
        {
            string s = "6900690040, 4690606946, 9990494604";
            PositionsAverage.PositionsAverage positionsAverage = new PositionsAverage.PositionsAverage();

            Assert.AreEqual(26.6666666667, positionsAverage.Count(s));
        }

        [Test]
        public void Test3()
        {
            string s = "4444444, 4444444, 4444444, 4444444, 4444444, 4444444, 4444444, 4444444";
            PositionsAverage.PositionsAverage positionsAverage = new PositionsAverage.PositionsAverage();

            Assert.AreEqual(100, positionsAverage.Count(s));
        }
    }
}
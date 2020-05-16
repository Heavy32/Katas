using NUnit.Framework;

namespace NextBiggerNumber.Tests
{
    [TestFixture]
    public class NextBiggerNumberTests
    {
        [Test]
        public void In123_Out132()
        {
            Assert.AreEqual(132, NextBiggerNumber.Find(123));
        }

        [Test]
        public void In698_Out869()
        {
            Assert.AreEqual(869, NextBiggerNumber.Find(698));
        }

        [Test]
        public void In144_Out414()
        {
            Assert.AreEqual(414, NextBiggerNumber.Find(144));
        }

        [Test]
        public void In2017_Out2071()
        {
            Assert.AreEqual(2071, NextBiggerNumber.Find(2017));
        }

        [Test]
        public void In2071_Out2107()
        {
            Assert.AreEqual(2107, NextBiggerNumber.Find(2071));
        }

        [Test]
        public void In227801797_Out227801977()
        {
            Assert.AreEqual(227801977, NextBiggerNumber.Find(227801797));
        }

        [Test]
        public void In1797_Out1977()
        {
            Assert.AreEqual(1977, NextBiggerNumber.Find(1797));
        }

        [Test]
        public void In531_OutMinus1()
        {
            Assert.AreEqual(-1, NextBiggerNumber.Find(531));
        }

        [Test]
        public void In9887654332_OutMinus1()
        {
            Assert.AreEqual(-1, NextBiggerNumber.Find(9887654332));
        }
    }
}
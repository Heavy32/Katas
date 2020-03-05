using NUnit.Framework;

namespace Cipher.Tests
{
    [TestFixture()]
    public class DecodeTests
    {
        [Test()]
        public void DecodeTest()
        {
            IterativeRotationCipher cipher = new IterativeRotationCipher();

            string expected = "If you wish to make an apple pie from scratch, you must first invent the universe.";
            string actual = cipher.Decode("10 hu fmo a,ys vi utie mr snehn rni tvte .ysushou teI fwea pmapi apfrok rei tnocsclet");

            Assert.AreEqual(expected, actual);
        }
    }
}
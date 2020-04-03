using NUnit.Framework;

namespace Cipher.Tests
{
    [TestFixture()]
    public class DecodeTests
    {
        [Test()]
        public void DecodeTest()
        {
            IterativeRotationCipher cipher = new IterativeRotationCipher("10 hu fmo a,ys vi utie mr snehn rni tvte .ysushou teI fwea pmapi apfrok rei tnocsclet", 10);

            string expected = "If you wish to make an apple pie from scratch, you must first invent the universe.";
            string actual = cipher.Decode();

            Assert.AreEqual(expected, actual);
        }
    }
}
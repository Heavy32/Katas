using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Cipher.Tests
{
    [TestFixture()]
    public class EncodeTests
    {
        [Test()]
        public void EncodeTest()
        {
            IterativeRotationCipher cipher = new IterativeRotationCipher("If you wish to make an apple pie from scratch, you must first invent the universe.", 10);

            string expected = "10 hu fmo a,ys vi utie mr snehn rni tvte .ysushou teI fwea pmapi apfrok rei tnocsclet";
            string actual = cipher.Encode();

            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ReturnSpaces()
        {
            IterativeRotationCipher cipher = new IterativeRotationCipher("You are my friend, how are you doing?", 10);

            string expected = "You are my friend, how are you doing?";
            cipher.WriteSpacePositions();
            cipher.inputText = Regex.Replace(cipher.inputText, @"\s+", "");
            cipher.ReturnSpaces();

            Assert.AreEqual(expected, cipher.inputText);

        }
    }
}

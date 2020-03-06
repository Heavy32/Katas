using NUnit.Framework;

namespace Cipher.Tests
{
    [TestFixture()]
    public class EncodeTests
    {
        [Test()]
        public void EncodeTest()
        {
            IterativeRotationCipher cipher = new IterativeRotationCipher();

            string expected = "10 hu fmo a,ys vi utie mr snehn rni tvte .ysushou teI fwea pmapi apfrok rei tnocsclet";
            string actual = cipher.Encode("If you wish to make an apple pie from scratch, you must first invent the universe.", 10);

            Assert.AreEqual(expected, actual);
        }

        //[Test()]
        //public void RemoveSpaces()
        //{
        //    IterativeRotationCipher cipher = new IterativeRotationCipher();

        //    string expected = "Ifyouwishtomakeanapplepiefromscratch,youmustfirstinventtheuniverse.";
        //    string actual = cipher.RemoveSpaces("If you wish to make an apple pie from scratch, you must first invent the universe.");

        //    Assert.AreEqual(expected, actual);
        //}

        //[Test()]
        //public void ReturnSpaces()
        //{
        //    IterativeRotationCipher cipher = new IterativeRotationCipher();

        //    string expected = "eu niv erse .I fyou wi shtom ake anap plepiefr oms crat ch,yo umustf irs tinventth";
        //    string actual = cipher.ReturnSpaces("euniverse.Ifyouwishtomakeanapplepiefromscratch,youmustfirstinventth",
        //                                        cipher.WriteSpacePositions("If you wish to make an apple pie from scratch, you must first invent the universe."));

        //    Assert.AreEqual(expected, actual);
        //}

        //[Test()]
        //public void ShiftLettersInSubstring()
        //{
        //    IterativeRotationCipher cipher = new IterativeRotationCipher();

        //    string expected = "eu vni seer .I oufy wi shtom eak apan frplepie som atcr ch,yo ustfum sir htinventt";
        //    string actual = cipher.ShiftLettersInSubstring("eu niv erse .I fyou wi shtom ake anap plepiefr oms crat ch,yo umustf irs tinventth", 10);

        //    Assert.AreEqual(expected, actual);
        //}
    }
}

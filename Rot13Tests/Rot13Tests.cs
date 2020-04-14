using NUnit.Framework;
using Rot13;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rot13.Tests
{
    [TestFixture]
    public class Rot13Tests
    {
        [Test]
        public void test_To_grfg()
        {
            Rot13 encoder = new Rot13();
            Assert.AreEqual("grfg", encoder.Encode("test"));
        }

        [Test]
        public void Test_To_Grfg()
        {
            Rot13 encoder = new Rot13();
            Assert.AreEqual("Grfg", encoder.Encode("Test"));
        }

        [Test]
        public void TEST_To_GRFG()
        {
            Rot13 encoder = new Rot13();
            Assert.AreEqual("GRFG", encoder.Encode("TEST"));
        }

        [Test]
        public void test10plus2_is_twelve()
        {
            Rot13 encoder = new Rot13();
            Assert.AreEqual("10+2 is twelve.", encoder.Encode("10+2 vf gjryir."));
        }
    }
}


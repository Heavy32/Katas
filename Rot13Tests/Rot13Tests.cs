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
            Assert.AreEqual("grfg", encoder.Encode("test"));
        }
    }
}


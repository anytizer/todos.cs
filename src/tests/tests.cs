using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void TestDateTime()
        {
            // unused test
            string datetime = "2017-04-10 10:15:08";
            string formatted = string.Format("{0}", datetime);
            Assert.AreEqual(datetime, formatted);
        }

        [TestMethod]
        public void TestGuid()
        {
            // unused test
            string guid1 = Guid.NewGuid().ToString();
            string guid2 = string.Format("{0}", guid1);
            Assert.AreEqual(guid1, guid2);
        }
    }
}

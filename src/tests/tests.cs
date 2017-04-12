using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void TestDateTime()
        {
            string datetime = "2017-04-10 10:15:08";
            string formatted = string.Format("{0}", datetime);
            Assert.AreEqual(datetime, formatted);
        }
    }
}

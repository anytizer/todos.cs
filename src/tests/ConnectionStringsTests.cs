using Microsoft.VisualStudio.TestTools.UnitTesting;
using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    [TestClass()]
    public class ConnectionStringsTests
    {
        [TestMethod()]
        public void plainTest()
        {
            string plain = ConnectionStrings.plain();
            Assert.IsTrue(plain.Contains("port"));
        }
    }
}
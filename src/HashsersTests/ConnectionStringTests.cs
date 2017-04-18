using Microsoft.VisualStudio.TestTools.UnitTesting;
using helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helpers.Tests
{
    [TestClass()]
    public class ConnectionStringTests
    {
        [TestMethod()]
        public void dsnTest()
        {
            ConnectionString cs = new ConnectionString();

            string dsn = cs.dsn();
            Assert.IsTrue(dsn.Contains("edmx"));
            Assert.AreNotEqual("", dsn);
        }

        [TestMethod()]
        public void edmxTest()
        {
            ConnectionString cs = new ConnectionString();

            string edmx = cs.edmx();
            Assert.IsTrue(edmx.Contains("edmx"));
            Assert.AreNotEqual("", edmx);
        }

        [TestMethod()]
        public void nativeTest()
        {
            ConnectionString cs = new ConnectionString();

            string native = cs.native();
            Assert.IsTrue(native.Contains("native"));
            Assert.AreNotEqual("", native);
        }

        [TestMethod()]
        public void odbcTest()
        {
            ConnectionString cs = new ConnectionString();

            string odbc = cs.odbc();
            Assert.IsTrue(odbc.Contains("odbc"));
            Assert.AreNotEqual("", odbc);
        }
    }
}
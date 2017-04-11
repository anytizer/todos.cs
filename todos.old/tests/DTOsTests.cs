using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dtos;

namespace tests
{
    [TestClass]
    public class DTOsTests
    {
        [TestMethod]
        public void TestGuidLength()
        {
            NameIDDTO n = new NameIDDTO();
            n.id = Guid.NewGuid();

            Assert.AreEqual(36, n.id.ToString().Length);
        }
    }
}

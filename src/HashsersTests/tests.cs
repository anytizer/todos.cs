using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hashers;

namespace HashsersTests
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        [TestCategory("Encryption")]
        public void EncryptionTest()
        {
            SimpleEncrypter s = new SimpleEncrypter();

            string source = "something";
            string encrypted = s.encrypt(source);
            string derypted = s.decrypt(encrypted);

            Assert.AreNotEqual(source, encrypted);
            Assert.AreEqual(source, derypted);
        }
    }
}

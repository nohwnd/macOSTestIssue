using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestAesGcm()
        {
            var key = new byte[16];
            RandomNumberGenerator.Fill(key);
            using var aes = new AesGcm(key);

            var encryptedData = new byte[128];
            var tag = new byte[12];
            aes.Encrypt(new byte[12], new byte[128], encryptedData, tag);
            Assert.IsNotNull(encryptedData);
        }
    }
}

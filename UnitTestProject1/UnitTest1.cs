using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRsa()
        {
            var rsa = RSA.Create();
            Assert.IsNotNull(rsa);

            var encryptedData = rsa.Encrypt(new byte[16], RSAEncryptionPadding.OaepSHA256);
            Assert.IsNotNull(encryptedData);
        }

        [TestMethod]
        public void TestEcdh()
        {
            var ecdh = ECDiffieHellman.Create();
            var ecdh2 = ECDiffieHellman.Create();
            Assert.IsNotNull(ecdh);

            var derivedKey = ecdh.DeriveKeyFromHash(ecdh2.PublicKey, HashAlgorithmName.SHA256);
            Assert.IsNotNull(derivedKey);
        }

        [TestMethod]
        public void TestSha256()
        {
            var sha256 = HashAlgorithm.Create("SHA256");
            Assert.IsNotNull(sha256);

            var hashedData = sha256.ComputeHash(new byte[16]);
            Assert.IsNotNull(hashedData);
        }

        [TestMethod]
        public void TestAes()
        {
            var key = new byte[16];
            RandomNumberGenerator.Fill(key);
            var aes = Aes.Create();
            aes.Key = key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var encryptor = aes.CreateEncryptor();

            var encryptedData = encryptor.TransformFinalBlock(new byte[16], 0, 16);
            Assert.IsNotNull(encryptedData);
        }
    }
}

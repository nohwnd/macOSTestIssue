using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestRsa()
        {
            var rsa = RSA.Create();
            Assert.NotNull(rsa);

            var encryptedData = rsa.Encrypt(new byte[16], RSAEncryptionPadding.OaepSHA256);
            Assert.NotNull(encryptedData);
        }

        [Fact]
        public void TestEcdh()
        {
            var ecdh = ECDiffieHellman.Create();
            var ecdh2 = ECDiffieHellman.Create();
            Assert.NotNull(ecdh);

            var derivedKey = ecdh.DeriveKeyFromHash(ecdh2.PublicKey, HashAlgorithmName.SHA256);
            Assert.NotNull(derivedKey);
        }

        [Fact]
        public void TestSha256()
        {
            var sha256 = HashAlgorithm.Create("SHA256");
            Assert.NotNull(sha256);

            var hashedData = sha256.ComputeHash(new byte[16]);
            Assert.NotNull(hashedData);
        }

        [Fact]
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
            Assert.NotNull(encryptedData);
        }

        //[Fact]
        //public void TestAesGcm()
        //{
        //    var key = new byte[16];
        //    RandomNumberGenerator.Fill(key);
        //    using var aes = new AesGcm(key);

        //    var encryptedData = new byte[128];
        //    var tag = new byte[12];
        //    aes.Encrypt(new byte[12], new byte[128], encryptedData, tag);
        //    Assert.NotNull(encryptedData);
        //}

        [Fact]
        public void TestX509Certificate()
        {
            var certificate = new X509Certificate2();
            Assert.NotNull(certificate);
        }
    }
}

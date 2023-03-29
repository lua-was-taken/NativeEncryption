using NativeEncryption.Models;
using NativeEncryption.Models.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace NativeEncryption {
    public static class RsaEncryption {
        public static RsaKey GenerateKey() {
            using RSACryptoServiceProvider rsa = new();

            return new RsaKey {
                PublicKey = rsa.ToXmlString(false),
                PrivateKey = rsa.ToXmlString(true)
            };
        }

        public static string Encrypt(in string data, in RsaKey key) {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(data), key).Span);
        }
        public static Memory<byte> Encrypt(in Memory<byte> blob, in RsaKey key) {
            if(string.IsNullOrWhiteSpace(key.PublicKey)) {
                throw new MissingPublicKeyException($"Provided {nameof(RsaKey)} instance contains invalid Xml public key.");
            }

            using RSA rsa = RSA.Create();
            rsa.FromXmlString(key.PublicKey);

            return rsa.Encrypt(blob.Span, RSAEncryptionPadding.Pkcs1);
        }

        public static string Decrypt(in string data, in RsaKey key) {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(data), key).Span);
        }
        public static Memory<byte> Decrypt(in Memory<byte> blob, in RsaKey key) {
            if (string.IsNullOrWhiteSpace(key.PrivateKey)) {
                throw new MissingPublicKeyException($"Provided {nameof(RsaKey)} instance contains invalid Xml private key.");
            }

            using RSA rsa = RSA.Create();
            rsa.FromXmlString(key.PrivateKey);

            return rsa.Decrypt(blob.Span, RSAEncryptionPadding.Pkcs1);
        }
    }
}
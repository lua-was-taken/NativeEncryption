using NativeEncryption.Models;
using System.Text;

namespace NativeEncryption.Extensions {
    public static class StringExtensions {
        public static Memory<byte> AsBytes(this string value) {
            return Encoding.UTF8.GetBytes(value);
        }
        public static string EncryptAes(this string value, in AesKey key) {
            return AesEncryption.Encrypt(value, key);
        }
        public static string EncryptRsa(this string value, in RsaKey key) {
            return RsaEncryption.Encrypt(value, key);
        }
        public static string DecryptAes(this string value, in AesKey key) {
            return AesEncryption.Decrypt(value, key);
        }
        public static string DecryptRsa(this string value, in RsaKey key) {
            return RsaEncryption.Decrypt(value, key);
        }
    }
}
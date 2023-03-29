using NativeEncryption.Models;
using System.Text;

namespace NativeEncryption.Extensions {
    public static class MemoryExtensions {
        public static string AsString(this Memory<byte> memory) {
            return Encoding.UTF8.GetString(memory.Span);
        }
        public static Memory<byte> EncryptAes(this Memory<byte> memory, in AesKey key) {
            return AesEncryption.Encrypt(memory, key);
        }
        public static Memory<byte> EncryptRsa(this Memory<byte> memory, in RsaKey key) {
            return RsaEncryption.Encrypt(memory, key);
        }
        public static Memory<byte> DecryptAes(this Memory<byte> memory, in AesKey key) {
            return AesEncryption.Decrypt(memory, key);
        }
        public static Memory<byte> DecryptRsa(this Memory<byte> memory, in RsaKey key) {
            return RsaEncryption.Decrypt(memory, key);
        }
    }
}
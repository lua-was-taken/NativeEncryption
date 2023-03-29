namespace NativeEncryption.Models.Exceptions {
    public sealed class MissingPublicKeyException : Exception {
        public MissingPublicKeyException(string message) : base(message) { }
    }
}
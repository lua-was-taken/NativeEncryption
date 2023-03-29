namespace NativeEncryption.Models.Exceptions {
    public sealed class MissingPrivateKeyException : Exception {
        public MissingPrivateKeyException(string message) : base(message) { }
    }
}
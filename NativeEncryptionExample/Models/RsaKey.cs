namespace NativeEncryption.Models {
    public sealed record RsaKey {
        public required string PublicKey { get; init; }
        public required string PrivateKey { get; init; }
    }
}
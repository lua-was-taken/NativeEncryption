namespace NativeEncryption.Models {
    public sealed record AesKey {
        public string KeyBase64 => Convert.ToBase64String(Key);
        public string IVBase64 => Convert.ToBase64String(IV);

        public required byte[] Key { get; init; }
        public required byte[] IV { get; init; }
    }
}
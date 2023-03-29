using NativeEncryption;
using NativeEncryption.Extensions;
using NativeEncryption.Models;

Console.WriteLine("[RSA Test]");
RsaKey rsaKey = RsaEncryption.GenerateKey();

string exampleRsa = "Hello World!";
string exampleRsaEnc = exampleRsa.EncryptRsa(rsaKey);
string exampleRsaDec = exampleRsaEnc.DecryptRsa(rsaKey);

Console.WriteLine($"Text: '{exampleRsa}'\n" +
                  $"Encrypted (RSA): '{exampleRsaEnc}'\n" +
                  $"Decrypted (RSA): '{exampleRsaDec}'");

Console.Write("\n");

Console.WriteLine("[AES Test]");
AesKey aesKey = AesEncryption.GenerateKey();

string exampleAes = "Goodbye World!";
string exampleAesEnc = exampleAes.EncryptAes(aesKey);
string exampleAesDec = exampleAesEnc.DecryptAes(aesKey);

Console.WriteLine($"Text: '{exampleAes}'\n" +
                  $"Encrypted (AES): '{exampleAesEnc}'\n" +
                  $"Decrypted (AES): '{exampleAesDec}'");

Console.ReadKey();
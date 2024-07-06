

using System;
using System.Security.Cryptography;


Console.WriteLine("Hello, World!");


EncryptionHelper.GenerateKeyAndIV(out string base64Key, out string base64IV);

Console.WriteLine($"Base64 Key: {base64Key}");
Console.WriteLine($"Base64 IV: {base64IV}");
public class EncryptionHelper
{
    public static void GenerateKeyAndIV(out string base64Key, out string base64IV)
    {
        using (Aes aes = Aes.Create())
        {
            aes.KeySize = 256; // Key size can be 128, 192, or 256 bits
            aes.GenerateKey();
            aes.GenerateIV();

            base64Key = Convert.ToBase64String(aes.Key);
            base64IV = Convert.ToBase64String(aes.IV);
        }
    }
}

using System;
using System.Text;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

string secret = "%&&¤iudsb¤5yux7807ehl3g2ldwjpør3ip2mdxjcidp3957r89p7¤6yurtfgk";

var sha = Sha256(secret);
Console.WriteLine(sha);

Console.ReadLine();

static string Sha256( string input)
{

    using (var sha = SHA256.Create())
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = sha.ComputeHash(bytes);

        return Convert.ToBase64String(hash);
    }
}
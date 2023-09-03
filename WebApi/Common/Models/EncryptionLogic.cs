using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace WebApi.Common.Models;

public static class EncryptionLogic
{
    /// <summary></summary>
    public const int saltIteration = 512;

    /// <summary></summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public static (string, string) Passecurity(this string password)
    {
        var salt = GenerateSalt();
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 100000,
            numBytesRequested: 256));

        return (Convert.ToBase64String(salt), hashed);
    }

    /// <summary></summary>
    /// <param name="password"></param>
    /// <param name="salt"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public static bool VerifyPassword(this string password, string salt, string hash)
    {
        var saltBytes = Convert.FromBase64String(salt);
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
           password: password,
           salt: saltBytes,
           prf: KeyDerivationPrf.HMACSHA512,
           iterationCount: 100000,
           numBytesRequested: 256));
        if (hashed == hash)
            return true;
        else
            return false;
    }


    /// <summary>
    /// generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
    /// </summary>
    /// <returns></returns>
    private static byte[] GenerateSalt()
    {
        byte[] salt = new byte[saltIteration];
        using (var rngCsp = new RNGCryptoServiceProvider())
        {
            rngCsp.GetNonZeroBytes(salt);
            return salt;
        }
    }
}

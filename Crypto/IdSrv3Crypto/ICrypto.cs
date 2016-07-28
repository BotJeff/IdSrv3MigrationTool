/*
 * Copyright (c) Brock Allen.  All rights reserved.
 * see license.txt
 */


namespace IdSrv3DataMigrationTool.Crypto.IdSrv3Crypto
{
    public interface ICrypto
    {
        string Hash(string value);
        bool VerifyHash(string value, string hash);
        string Hash(string value, string key);
        bool VerifyHash(string value, string key, string hash);
        string GenerateNumericCode(int digits);
        string GenerateSalt();
        string HashPassword(string password, int iterations);
        bool VerifyHashedPassword(string hashedPassword, string password);
    }
}

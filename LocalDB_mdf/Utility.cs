using System;
using System.Configuration;
using System.Security.Cryptography;

namespace LocalDB_mdf
{
    static class Utility
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["LocalDBCrudDemo"].ConnectionString; }
        }

        public const string MasterConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30";

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var provider = RandomNumberGenerator.Create())
            {
                provider.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string ComputeHashWithSalt(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            using (var derivation = new Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256))
            {
                return Convert.ToBase64String(derivation.GetBytes(32));
            }
        }
    }
}

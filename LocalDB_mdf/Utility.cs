using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LocalDB_mdf
{
    static class Utility
    {
        // Stringa di connessione al database LocalDB
        public static string connStringUtenti = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseEsempio.mdf;Integrated Security=True";
        // Stringa di connessione al database LocalDB con file MDF allegato
        public static string connStringProdotti = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DatabaseEsempio.mdf;Initial Catalog=MioDatabaseProgetto;Integrated Security=True";

        // Genera un sale casuale unico per ogni utente
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Calcola l'hash della password combinata con il suo sale
        public static string ComputeHashWithSalt(string password, string salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Uniamo password e sale
                string combined = password + salt;
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(combined));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

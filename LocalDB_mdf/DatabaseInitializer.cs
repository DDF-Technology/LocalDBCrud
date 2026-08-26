using System.Data.SqlClient;

namespace LocalDB_mdf
{
    internal static class DatabaseInitializer
    {
        private const string DatabaseName = "LocalDBCrudDemo";

        public static void Initialize()
        {
            using (var connection = new SqlConnection(Utility.MasterConnectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "IF DB_ID(@databaseName) IS NULL CREATE DATABASE [LocalDBCrudDemo];";
                command.Parameters.AddWithValue("@databaseName", DatabaseName);
                command.ExecuteNonQuery();
            }

            using (var connection = new SqlConnection(Utility.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = @"
IF OBJECT_ID(N'dbo.Prodotti', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Prodotti
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Nome NVARCHAR(120) NOT NULL,
        Prezzo DECIMAL(12,2) NOT NULL CHECK (Prezzo >= 0)
    );
END;

IF OBJECT_ID(N'dbo.Utenti', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Utenti
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Username NVARCHAR(80) NOT NULL UNIQUE,
        Password NVARCHAR(128) NOT NULL,
        Salt NVARCHAR(64) NOT NULL
    );
END;";
                command.ExecuteNonQuery();
            }

            SeedDemoData();
        }

        private static void SeedDemoData()
        {
            using (var connection = new SqlConnection(Utility.ConnectionString))
            {
                connection.Open();

                using (var products = connection.CreateCommand())
                {
                    products.CommandText = @"
IF NOT EXISTS (SELECT 1 FROM dbo.Prodotti)
BEGIN
    INSERT INTO dbo.Prodotti (Nome, Prezzo) VALUES
        (N'Sensore demo', 24.90),
        (N'Modulo I/O demo', 49.50),
        (N'Alimentatore demo', 32.00);
END;";
                    products.ExecuteNonQuery();
                }

                using (var users = connection.CreateCommand())
                {
                    string salt = Utility.GenerateSalt();
                    string hash = Utility.ComputeHashWithSalt("demo", salt);
                    users.CommandText = @"
IF NOT EXISTS (SELECT 1 FROM dbo.Utenti WHERE Username = @username)
    INSERT INTO dbo.Utenti (Username, Password, Salt) VALUES (@username, @password, @salt);";
                    users.Parameters.AddWithValue("@username", "demo");
                    users.Parameters.AddWithValue("@password", hash);
                    users.Parameters.AddWithValue("@salt", salt);
                    users.ExecuteNonQuery();
                }
            }
        }
    }
}

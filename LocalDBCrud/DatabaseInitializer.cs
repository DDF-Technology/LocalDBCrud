using System.Data.SqlClient;

namespace LocalDBCrud
{
    internal static class DatabaseInitializer
    {
        private const string DatabaseName = "LocalDBCrud";

        public static void Initialize()
        {
            using (var connection = new SqlConnection(Utility.MasterConnectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "IF DB_ID(@databaseName) IS NULL CREATE DATABASE [LocalDBCrud];";
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
END;";
                command.ExecuteNonQuery();
            }

            SeedProducts();
        }

        private static void SeedProducts()
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
        (N'Sensore di temperatura', 24.90),
        (N'Modulo I/O', 49.50),
        (N'Alimentatore', 32.00);
END;";
                    products.ExecuteNonQuery();
                }
            }
        }
    }
}

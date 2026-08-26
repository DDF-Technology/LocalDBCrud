using System.Configuration;

namespace LocalDBCrud
{
    static class Utility
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["LocalDBCrud"].ConnectionString; }
        }

        public const string MasterConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30";

    }
}

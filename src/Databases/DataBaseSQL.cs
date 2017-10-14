using System.Data.Entity;
using System.Data.SqlClient;


namespace Databases
{
    public class DataBaseSQL : DataBase
    {
        static string connection;
        public DataBaseSQL(SqlConnection connectionString, IDatabaseInitializer<DataBaseSQL> initializer)
            : base(connectionString)
        {
            connection = this.Database.Connection.ConnectionString;
            Database.SetInitializer(initializer);
        }

        public DataBaseSQL(IDatabaseInitializer<DataBaseSQL> initializer)
            : base(new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseStories"].ConnectionString))
        {
            connection = this.Database.Connection.ConnectionString;
            Database.SetInitializer(initializer);
        }

        public DataBaseSQL()
            : base(new SqlConnection(connection))
        {
        }
    }
}

using System;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Databases.Factories
{
    public class FactorySQL : FactoryDbBase, IFactoryDB, IDisposable
    {
        IDatabaseInitializer<DataBaseSQL> inicializer;

        public FactorySQL(IDatabaseInitializer<DataBaseSQL> inicializer)
        {
            this.inicializer = inicializer;
        }


        protected override void AsignDatabaseProperties(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
                database = new DataBaseSQL(inicializer);
            else
            {
                ConnectionStringOld = connectionString;
                database = new DataBaseSQL(new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=" + connectionString + ";" + "Integrated Security=True;Persist Security Info=False;"), inicializer);
            }
        }

    }
}

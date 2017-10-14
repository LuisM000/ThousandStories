using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Factories
{
    public abstract class FactoryDbBase : IFactoryDB, IDisposable
    {
        protected DataBase database;
        protected String ConnectionStringOld;

        public virtual void Dispose()
        {
            if (database != null) database.Dispose();
        }

        public DataBase CreateDataBase(string connectionString)
        {
            if (ConnectionStringOld != connectionString || database == null)
            {
                if (database != null) database.Dispose();
                AsignDatabaseProperties(connectionString);
            }
            return database;
        }

        public DataBase CreateNewDataBase(string connectionString)
        {
            if (database != null)
                database.Dispose();
            AsignDatabaseProperties(connectionString);
            return database;
        }

        protected abstract void AsignDatabaseProperties(string connectionString);
    }
}

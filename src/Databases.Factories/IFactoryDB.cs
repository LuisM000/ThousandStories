using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.Factories
{
    public interface IFactoryDB
    {
        DataBase CreateDataBase(string connectionString);

        DataBase CreateNewDataBase(string connectionString);
    }
}

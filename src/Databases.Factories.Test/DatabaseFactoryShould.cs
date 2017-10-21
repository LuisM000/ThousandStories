using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Databases.Factories.Test
{
    [TestClass]
    public class DatabaseFactoryShould
    {
        [Ignore]
        [TestMethod]
        public void CreateNewDatabase()
        {
            IDatabaseInitializer<DataBaseSQL> initializer = new DropCreateDatabaseAlways<DataBaseSQL>();
            FactorySQL factory = new FactorySQL(initializer);

            DataBase db = factory.CreateDataBase("dummy stories");
            db.Set<Story>().Add(new Story()
            {
                Title = new Model.Title("dummy title"),
                Images = new List<Image>() { new Image() }
            });
            db.SaveChanges();
            db.Dispose();
        }
    }
}

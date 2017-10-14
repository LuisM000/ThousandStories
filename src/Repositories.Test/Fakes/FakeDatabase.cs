using Databases;
using Databases.Factories;
using Model.Story;
using Moq;
using System;
using System.Data.Common;

namespace Repositories.Test.Fakes
{
    public class FakeDatabase : DataBase
    {
        public FakeDatabase(DbConnection conection)
            : base(conection)
        {
            this.Database.CommandTimeout = Int32.MaxValue;
        }
        public FakeDbSet<Story> Story { get; set; }
        public FakeDbSet<FooEntity> Foo { get; set; }


        public static Mock<IFactoryDB> GivenAFactoryWithDatabase(DataBase database)
        {
            Mock<IFactoryDB> factoryDB = new Mock<IFactoryDB>();
            factoryDB.Setup(f => f.CreateDataBase(null)).Returns(database);
            return factoryDB;
        }

        public static Mock<FakeDatabase> CreateMockOfFakeDatabase<T>(FakeDbSet<T> storyDbSet) where T : class
        {
            Mock<DbConnection> dbConnectionMoq = new Mock<DbConnection>();
            Mock<FakeDatabase> database = new Mock<FakeDatabase>(dbConnectionMoq.Object);
            database.Setup(db => db.Set<T>()).Returns(storyDbSet);
            return database;
        }
    }
}

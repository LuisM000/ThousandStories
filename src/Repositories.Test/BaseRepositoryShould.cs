using Databases;
using Infrastructure;
using Infrastructure.Order;
using Infrastructure.Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories.Test.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Test
{
    [TestClass]
    public class BaseRepositoryShould
    {
        [TestMethod]
        public void ReturnsFirstThreeResults()
        {
            Pagination firstPageThreeResults = new Pagination(1, 3);
            IEnumerable<FooEntity> tenFooEntities = this.GivenAFooEntities(10);
            FakeDbSet<FooEntity> fooDbSet = new FakeDbSet<FooEntity>(tenFooEntities);
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(fooDbSet);
            BaseRepository<FooEntity> baseRepository = this.GivenABaseRepositoryWithDatabase(database.Object);

            IEnumerable<FooEntity> results = baseRepository.GetAll(new Query<FooEntity>(null, firstPageThreeResults, null));

            CollectionAssert.AreEqual(tenFooEntities.Take(3).ToList(), results.ToList());
        }

        [TestMethod]
        public void ReturnsSecondPageOfResults()
        {
            Pagination secondPageThreeResults = new Pagination(2, 3);
            IEnumerable<FooEntity> tenFooEntities = this.GivenAFooEntities(10);
            FakeDbSet<FooEntity> fooDbSet = new FakeDbSet<FooEntity>(tenFooEntities);
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(fooDbSet);
            BaseRepository<FooEntity> baseRepository = this.GivenABaseRepositoryWithDatabase(database.Object);

            IEnumerable<FooEntity> results = baseRepository.GetAll(new Query<FooEntity>(null, secondPageThreeResults, null));

            CollectionAssert.AreEqual(tenFooEntities.Skip(3).Take(3).ToList(), results.ToList());
        }

        [TestMethod]
        public void ReturnsAllResultsOfLastPage()
        {
            Pagination lastPageThreeResults = new Pagination(4, 3);
            IEnumerable<FooEntity> tenFooEntities = this.GivenAFooEntities(10);
            FakeDbSet<FooEntity> fooDbSet = new FakeDbSet<FooEntity>(tenFooEntities);
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(fooDbSet);
            BaseRepository<FooEntity> baseRepository = this.GivenABaseRepositoryWithDatabase(database.Object);

            IEnumerable<FooEntity> results = baseRepository.GetAll(new Query<FooEntity>(null, lastPageThreeResults, null));

            CollectionAssert.AreEqual(tenFooEntities.Skip(9).Take(1).ToList(), results.ToList());
        }

        [TestMethod]
        public void ReturnsResultsOrderByIndex()
        {
            IOrdering<FooEntity> orderingById = new FooOrderById();
            IEnumerable<FooEntity> tenFooEntities = this.GivenAFooEntitiesWithRandomId(10);
            FakeDbSet<FooEntity> fooDbSet = new FakeDbSet<FooEntity>(tenFooEntities);
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(fooDbSet);
            BaseRepository<FooEntity> baseRepository = this.GivenABaseRepositoryWithDatabase(database.Object);

            IEnumerable<FooEntity> results = baseRepository.GetAll(new Query<FooEntity>(null, null, orderingById));

            CollectionAssert.AreEqual(tenFooEntities.OrderBy(i => i.Id).ToList(), results.ToList());
        }

        [TestMethod]
        public void ReturnsResultsOrderDescendingByIndex()
        {
            IOrdering<FooEntity> orderingById = new FooOrderByDescendingId();
            IEnumerable<FooEntity> tenFooEntities = this.GivenAFooEntitiesWithRandomId(10);
            FakeDbSet<FooEntity> fooDbSet = new FakeDbSet<FooEntity>(tenFooEntities);
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(fooDbSet);
            BaseRepository<FooEntity> baseRepository = this.GivenABaseRepositoryWithDatabase(database.Object);

            IEnumerable<FooEntity> results = baseRepository.GetAll(new Query<FooEntity>(null, null, orderingById));

            CollectionAssert.AreEqual(tenFooEntities.OrderByDescending(i => i.Id).ToList(), results.ToList());
        }


        [TestMethod]
        public void ReturnsResultsWithSpecText()
        {
            ISpecification<FooEntity> barTextSpecification = new FooWithBarSpec("bar text dummy");
            FooEntity fooCorrectText = this.GivenAFooEntityWithBarText("bar text dummy");
            FooEntity fooNoCorrectText = this.GivenAFooEntityWithBarText("other dummy");
            FooEntity fooNoCorrectText2 = this.GivenAFooEntityWithBarText("other dummy 2");

            FakeDbSet<FooEntity> fooDbSet = new FakeDbSet<FooEntity>(){fooCorrectText,fooNoCorrectText,fooNoCorrectText2};
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(fooDbSet);
            BaseRepository<FooEntity> baseRepository = this.GivenABaseRepositoryWithDatabase(database.Object);

            IEnumerable<FooEntity> results = baseRepository.GetAll(new Query<FooEntity>(barTextSpecification, null, null));

            Assert.AreEqual(1, results.Count());
            Assert.AreEqual(fooCorrectText, results.FirstOrDefault());
        }

        [TestMethod]
        public void ReturnsPaginatedList()
        {
            Pagination firstPageThreeResults = new Pagination(1, 3);
            IEnumerable<FooEntity> tenFooEntities = this.GivenAFooEntities(10);
            FakeDbSet<FooEntity> fooDbSet = new FakeDbSet<FooEntity>(tenFooEntities);
            Mock<FakeDatabase> database = FakeDatabase.CreateMockOfFakeDatabase(fooDbSet);
            BaseRepository<FooEntity> baseRepository = this.GivenABaseRepositoryWithDatabase(database.Object);

            IPagedList<FooEntity> pageResults = baseRepository.GetPage(new Query<FooEntity>(null, firstPageThreeResults, null));

            CollectionAssert.AreEqual(tenFooEntities.Take(3).ToList(), pageResults.ToList());
            
        }


        private IEnumerable<FooEntity> GivenAFooEntities(int numberOfFooEntities)
        {
            return new List<FooEntity>(Enumerable.Range(0, numberOfFooEntities).Select(x => new FooEntity()));
        }
        private IEnumerable<FooEntity> GivenAFooEntitiesWithRandomId(int numberOfFooEntities)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            return new List<FooEntity>(Enumerable.Range(0, numberOfFooEntities).
                Select(x => new FooEntity() { Id = random.Next(100) }));
        }
        private FooEntity GivenAFooEntityWithBarText(string barText)
        {
            return new FooEntity() { Bar = barText };
        }
        private BaseRepository<FooEntity> GivenABaseRepositoryWithDatabase(DataBase database)
        {
            return new BaseRepository<FooEntity>(FakeDatabase.GivenAFactoryWithDatabase(database).Object);
        }
    }
}

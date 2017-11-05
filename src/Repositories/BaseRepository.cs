using Databases;
using Databases.Factories;
using Domain.Interfaces;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected IFactoryDB factoryDB;
        protected DataBase database;
        public virtual String Connection { protected get; set; }


        public BaseRepository(IFactoryDB factoryDB)
        {
            this.factoryDB = factoryDB;
        }

        public virtual TEntity GetById(int id)
        {
            var v = factoryDB.CreateDataBase(Connection);
            return v.Set<TEntity>().FirstOrDefault(t => t.Id == id);
        }

        public TEntity GetOriginalById(int id)
        {
            var v = factoryDB.CreateNewDataBase(Connection);
            return v.Set<TEntity>().FirstOrDefault(t => t.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var v = this;
            return factoryDB.CreateDataBase(Connection).Set<TEntity>().ToList<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetTake(int start, int count)
        {
            return factoryDB.CreateDataBase(Connection).Set<TEntity>().OrderBy(t => t.Id).Skip(start).Take(count).ToList();
        }
        public IEnumerable<TEntity> GetSkip(int count)
        {
            return factoryDB.CreateDataBase(Connection).Set<TEntity>().OrderBy(t => t.Id).Skip(count).ToList();
        }

        public virtual IQueryable<TEntity> GetAllIQuery()
        {
            return factoryDB.CreateDataBase(Connection).Set<TEntity>();
        }

        public virtual bool Delete(TEntity item)
        {
            factoryDB.CreateDataBase(Connection).Set<TEntity>().Remove(item);
            return true;
        }

        public virtual int Insert(TEntity item)
        {
            factoryDB.CreateDataBase(Connection).Set<TEntity>().Add(item);
            return 1;
        }

        public virtual int Update(TEntity item)
        {
            factoryDB.CreateDataBase(Connection).Entry(item).State = EntityState.Modified;
            return 1;
        }

        public virtual int SaveChanges()
        {
            factoryDB.CreateDataBase(Connection).SaveChanges();
            return 1;
        }


        protected IEnumerable<TEntity> GetAllIn(IEnumerable<int> idList)
        {
            return factoryDB.CreateDataBase(Connection).Set<TEntity>().Where(t => idList.Contains(t.Id)).ToList();
        }

        public IEnumerable<TEntity> GetAll(Query<TEntity> query)
        {
            return factoryDB.CreateDataBase(Connection).Set<TEntity>().Prepare(query);
        }


        public void RollBack()
        {
            try
            {
                var changedEntries = factoryDB.CreateDataBase(Connection).ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

                foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
                {
                    entry.State = EntityState.Detached;
                }

                foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
                {
                    entry.Reload();
                }

                foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
                {
                    entry.Reload();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        bool Delete(TEntity item);
        int Insert(TEntity item);
        int Update(TEntity item);
        int SaveChanges();
        string Connection { set; }

    }
}

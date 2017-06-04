using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //READS
        
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //UPDATES
        //Actualiza un registro al repositorio (SQL Server) a la tabla TEntity
        //void Update(TEntity entity);
        //Actualiza un grupo de registros al repositorio (SQL Server) a la tabla TEntity
        //void UpdateRange(IEnumerable<TEntity> entities);

        //DELETES
       
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}

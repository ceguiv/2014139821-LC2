using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2014139821_ENT.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //C REATES
        //Agregar un registro al repositorio (SQL SEVER) a la tabla TEntity
        void add(TEntity entity);
        //Agregar  un grupo de registros al repositorio (SQL SERVER) a la tabla TEntity
        void addRange(IEnumerable<TEntity> entities);

        //R EADS
        //Obtiene el registro con Primary Key = id igual de la tabla TEntity
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerator<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //U PDATES
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //D DELETES
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}

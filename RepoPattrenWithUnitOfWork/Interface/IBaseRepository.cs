using RepoPattrenWithUnitOfWork.Core.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.Interface
{
    public interface IBaseRepository<T> where T : class
    {
         T GetById(int id);
         Task<T> GetByIdAsync(int id);
         Task<IEnumerable<T>> GetAll();
         T Find(Expression<Func<T, bool>> predicate,string[] includes=null);
         IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate,string[] includes=null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate,int take ,int skip);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate,int? take ,int? skip,
            Expression<Func<T, object>> orderBy = null,string OrderByDirection=OrderBy.Assending);

        T Add(T entity);

        IEnumerable<T> AddRange(IEnumerable<T> entities);

        T update(T entity);
        
        void Delete(T entity); 
        void DeleteRange(IEnumerable<T> entities); 
        void Attach(T entity);
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        

    }
}

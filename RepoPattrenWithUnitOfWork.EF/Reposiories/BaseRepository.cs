using Microsoft.EntityFrameworkCore;
using RepoPattrenWithUnitOfWork.Core.Const;
using RepoPattrenWithUnitOfWork.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.EF.Reposiories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public T Find(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();// this to make not null with author relation 
            if (includes != null) { // send name of table that we want include
                foreach (var include in includes)
                {
                    query = query.Include(include);//include will fix null 
                }
            }
            return query.SingleOrDefault(predicate);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();// this to make not null with author relation 
            if (includes != null)
            { // send name of table that we want include
                foreach (var include in includes)
                {
                    query = query.Include(include);//include will fix null 
                }
            }
            return query.Where(predicate).ToList();//the different here we can here return many so we use where with query
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int take, int skip)
        {

            return _context.Set<T>().Where(predicate).Skip(take).Take(take);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Assending)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);

            if(take.HasValue)
                query= query.Take(take.Value);


            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if(orderBy != null)
            {
                if (orderByDirection == OrderBy.Assending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                    query = query.OrderByDescending(orderBy);

            }
            return query.ToList();
        }
        public T Add(T entity) { 
            _context.Set<T>().Add(entity);
          //  _context.SaveChanges();

            return entity;
        }
        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
          //  _context.SaveChanges();

            return entities;
        }

        public T update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);   
            
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Count(predicate);
        }

       
    }
}

using RepoPattrenWithUnitOfWork.Core;
using RepoPattrenWithUnitOfWork.Core.Interface;
using RepoPattrenWithUnitOfWork.Core.Models;
using RepoPattrenWithUnitOfWork.EF.Reposiories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Author> Authors { get; private set; }

        //public IBaseRepository<book> Books { get; private set; }
        public IBooksRepository Books { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new BaseRepository<Author>(_context);    
            //Books = new BaseRepository<book>(_context);    
            Books = new BooksRepository(_context);    
        }
     
        public int Complete()
        {
            return _context.SaveChanges();  // this method number of row the affect changed in database
        }

        public void Dispose()
        {
             _context.Dispose();
        }
    }
}

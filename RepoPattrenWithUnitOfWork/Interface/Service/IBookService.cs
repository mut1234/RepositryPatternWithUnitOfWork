using RepoPattrenWithUnitOfWork.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.Interface.Service
{
    public interface IBookService
    {
        Task<BookDto> GetByIdAsync(int id);
        IEnumerable<BookDto> GetAll();
        BookDto Find(int id);//int only
        IEnumerable<BookDto> FindAll(String name);//name

        int Add(BookDto DtoBook); // take dto return  int


        BookDto update(BookDto entity);

        void Delete(BookDto entity);
    }
}

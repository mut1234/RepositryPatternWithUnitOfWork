using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Book;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book;
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
        Task<GetByIdBookResponseDto> GetByIdAsync(GetByIdBookQuery request);
        Task<IEnumerable<GetAllBookResponseDto>> GetAll();
        BookDto Find(int id);//int only
        Task<IEnumerable<GetByNameResponseDto>> FindAll(GetByNameQuery request);//name

        int Add(BookDto DtoBook); // take dto return  int

        Task<UpdateBookResponseDto> Update(UpdateBookCommand request);

        void Delete(BookDto entity);
    }
}

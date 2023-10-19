using CSharpFunctionalExtensions;
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
        Task<IEnumerable<GetByNameResponseDto>> FindAll(GetByNameQuery request);//name

        Task<AddBookResponseDto> Add(AddBookCommand request);

        Task<UpdateBookResponseDto> Update(UpdateBookCommand request);

        Task<Result<string>> Delete(DeleteBookCommand request);
    }
}

using CSharpFunctionalExtensions;
using RepoPattrenWithUnitOfWork.Core.Const;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.Interface.Service
{
    public interface IAuthorService
    {

     //   Author? GetById(int id);
        Task<AuthorDto> GetByIdAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAll();
        AuthorDto Find(int id);//int only
        Task<IEnumerable<AuthorDto>> FindAll(String name);//name

        //  Task<int> Add(AuthorDto DtoAuthor);  // take dto return  int
        Task<AddAuthorResponseDto> Add(AddAuthorCommand DtoAuthor);
        AuthorDto Update(AuthorDto entity);

        Task<Result<string>> Delete(DeleteAuthorCommand DtoAuthor);

        void Attach(AuthorDto entity);
        int Count();
    }
}

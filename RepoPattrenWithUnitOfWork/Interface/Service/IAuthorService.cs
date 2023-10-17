using CSharpFunctionalExtensions;
using RepoPattrenWithUnitOfWork.Core.Const;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
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
        Task<GetByIdAuthorResponseDto> GetByIdAsync(GetByIdAuthorQuery request);
        Task<IEnumerable<GetAllAuthorResponseDto>> GetAll();
        Task<FindAuthorResponseDto> FindByIdAsync(FindAuthorQuery request);//int only
        Task<IEnumerable<FindAllAuthorResponseDto>> FindAll(FindAllAuthorQuery request);//name

        //  Task<int> Add(AuthorDto DtoAuthor);  // take dto return  int
        Task<AddAuthorResponseDto> Add(AddAuthorCommand DtoAuthor);
        Task<UpdateAuthorDto> Update(UpdateAuthorCommand request);

        Task<Result<string>> Delete(DeleteAuthorCommand DtoAuthor);

        void Attach(AuthorDto entity);
        int Count();
    }
}

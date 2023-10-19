using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using RepoPattrenWithUnitOfWork.Core.Const;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Book;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using RepoPattrenWithUnitOfWork.Core.Models;

namespace RepoPattrenWithUnitOfWork.Core.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddBookResponseDto> Add(AddBookCommand request)
        {
            var entity = _mapper.Map<Book>(request);
            entity.AuthorId = request.AuthorId;
            _unitOfWork.Books.Add(entity);
            await _unitOfWork.CompleteAsync();
            return new AddBookResponseDto { Id = entity.Id };
        }

        public async Task<Result<string>> Delete(DeleteBookCommand request)
        {
            var entity2 = _mapper.Map<Book>(request);           
            if (entity2 == null)
            return Result.Failure<string>(KeysEnum.ENTITYNOTFOUND);
            _unitOfWork.Books.Delete(entity2);
            await _unitOfWork.CompleteAsync();
            return Result.Success(KeysEnum.DeletedSuccessfully);
        }


        public async Task<IEnumerable<GetByNameResponseDto>> FindAll(GetByNameQuery request)
        {
            var entity = await _unitOfWork.Books.FindAll(e => e.Title == request.Title);
            var result = _mapper.Map<IEnumerable<GetByNameResponseDto>>(entity);
            return result;
        }

        public async Task<IEnumerable<GetAllBookResponseDto>> GetAll()
        {
            var entity2 = await  _unitOfWork.Books.GetAll();
           return _mapper.Map<IEnumerable<GetAllBookResponseDto>>(entity2);
        }

        public async Task<GetByIdBookResponseDto> GetByIdAsync(GetByIdBookQuery request)
        {
            var data = await _unitOfWork.Books.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetByIdBookResponseDto>(data);
            return result;
        }


        public async Task<UpdateBookResponseDto> Update(UpdateBookCommand request)
        {
            var entity2 = await _unitOfWork.Books.GetByIdAsync(request.Id);
            entity2.Title = request.Title;
            var result = _unitOfWork.Books.update(entity2);

            await _unitOfWork.CompleteAsync();

            return new UpdateBookResponseDto { Message = "Updated Successfully" };
        }
    }
}

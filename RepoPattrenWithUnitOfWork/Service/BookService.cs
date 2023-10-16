using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

        public int Add(BookDto DtoBook)
        {
            var entity = _mapper.Map<Book>(DtoBook);
            return entity.Id;

        }

        public void Delete(BookDto entity)
        {
            var entity2 = _mapper.Map<Book>(entity);
            _unitOfWork.Books.Delete(entity2);
        }

        public BookDto Find(int id)
        {
            var entity = _unitOfWork.Books.Find(e => e.Id == id);
            var result = _mapper.Map<BookDto>(entity);
            return result;
        }

        public IEnumerable<BookDto> FindAll(string name)
        {
            var entity = _unitOfWork.Books.FindAll(e => e.Title == name);
            var result = _mapper.Map<IEnumerable< BookDto>>(entity);
            return result;
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var entity2 = await  _unitOfWork.Books.GetAll();
           return _mapper.Map< IEnumerable<BookDto>>(entity2);
        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Books.GetByIdAsync(id);
            var result = _mapper.Map<BookDto>(data);
            return result;
        }

        public BookDto update(BookDto entity)
        {
            var entity2 = _mapper.Map<Book>(entity);
            var result = _unitOfWork.Books.update(entity2);
            return _mapper.Map<BookDto>(result);
        }
    }
}

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
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public int Add(DtoAuthor DtoAuthor)
        {
            var entity = _mapper.Map<Author>(DtoAuthor);
            _unitOfWork.Authors.Add(entity);
            return entity.Id;
        }

        public void Attach(DtoAuthor entity)
        {
            var entity2 = _mapper.Map<Author>(entity);
            _unitOfWork.Authors.Attach(entity2);
        }

        public int Count()
        {
            return _unitOfWork.Authors.Count();
        }

        public void Delete(DtoAuthor entity)
        {
            var entity2 = _mapper.Map<Author>(entity);
            _unitOfWork.Authors.Delete(entity2);
        }

        public DtoAuthor Find(int id)
        {

            var entity = _unitOfWork.Authors.Find(e => e.Id == id);
            var result = _mapper.Map<DtoAuthor>(entity);
            return result;

        }

        public IEnumerable<DtoAuthor> FindAll(string name)
        {
            var entity = _unitOfWork.Authors.FindAll(e => e.Name == name);
            var result = _mapper.Map<IEnumerable<DtoAuthor>>(entity);
            return result;
        }

        public IEnumerable<DtoAuthor> GetAll()
        {
            var entity2 = _unitOfWork.Authors.GetAll();
            return _mapper.Map<IEnumerable<DtoAuthor>>(entity2);
        }

        public async Task<DtoAuthor> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Authors.GetByIdAsync(id);
            var result = _mapper.Map<DtoAuthor>(data);
            return result;
        }

        public DtoAuthor Update(DtoAuthor entity)
        {
            var entity2 = _mapper.Map<Author>(entity);
            var result = _unitOfWork.Authors.update(entity2);
            return _mapper.Map<DtoAuthor>(result);
        }
    }
}

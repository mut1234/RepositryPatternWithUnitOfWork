using AutoMapper;
using CSharpFunctionalExtensions;
using RepoPattrenWithUnitOfWork.Core.Const;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands;
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

        public async Task<AddAuthorResponseDto> Add(AddAuthorCommand dtoAuthor)
        {
            var entity = _mapper.Map<Author>(dtoAuthor);
            _unitOfWork.Authors.Add(entity);
           await _unitOfWork.CompleteAsync();
            return new AddAuthorResponseDto { Id = entity.Id };
        }

        public void Attach(AuthorDto entity)
        {
            var entity2 = _mapper.Map<Author>(entity);
            _unitOfWork.Authors.Attach(entity2);
        }

        public int Count()
        {
            return _unitOfWork.Authors.Count();
        }

        public async Task<Result<string>> Delete(DeleteAuthorCommand request)
        {
            var entity2 = _mapper.Map<Author>(request);
            if (entity2 == null)
            return Result.Failure<string>( KeysEnum.ENTITYNOTFOUND);
            _unitOfWork.Authors.Delete(entity2);
            await _unitOfWork.CompleteAsync();
            return Result.Success( KeysEnum.DeletedSuccessfully);
        }

        public AuthorDto Find(int id)
        {

            var entity = _unitOfWork.Authors.Find(e => e.Id == id);
            var result = _mapper.Map<AuthorDto>(entity);
            return result;

        }

        public async Task<IEnumerable<AuthorDto>> FindAll(string name)
        {
            var entity = _unitOfWork.Authors.FindAll(e => e.Name == name);
            var result = _mapper.Map<IEnumerable<AuthorDto>>(entity);
            return  result;
        }

        public async Task<IEnumerable<AuthorDto>> GetAll()
        {
            var entity2 =await _unitOfWork.Authors.GetAll();
            return _mapper.Map<IEnumerable<AuthorDto>>(entity2);
        }

        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.Authors.GetByIdAsync(id);
            var result = _mapper.Map<AuthorDto>(data);
            return result;
        }

        public AuthorDto Update(AuthorDto entity)
        {
            var entity2 = _mapper.Map<Author>(entity);
            var result = _unitOfWork.Authors.update(entity2);
            return _mapper.Map<AuthorDto>(result);
        }

     
    }
}

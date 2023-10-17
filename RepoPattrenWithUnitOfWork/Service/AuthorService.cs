using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using RepoPattrenWithUnitOfWork.Core.Const;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
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

        public async Task<FindAuthorResponseDto> FindByIdAsync(FindAuthorQuery request)
        {

            var entity =  _unitOfWork.Authors.FindByIdAsync(e => e.Id == request.Id);
            var result = _mapper.Map<FindAuthorResponseDto>(entity);

            return  result;
        }

        public async Task<IEnumerable<FindAllAuthorResponseDto>> FindAll(FindAllAuthorQuery request)
        {
            var entity = await _unitOfWork.Authors.FindAll(e => e.Name == request.Name);
            var result = _mapper.Map<IEnumerable<FindAllAuthorResponseDto>>(entity);

            return result;
        }
  
        public async Task<IEnumerable<GetAllAuthorResponseDto>> GetAll()
        {
            var entity2 =await _unitOfWork.Authors.GetAll();
            return _mapper.Map<IEnumerable<GetAllAuthorResponseDto>>(entity2);
        }

        public async Task<GetByIdAuthorResponseDto> GetByIdAsync(GetByIdAuthorQuery request)
        {
            var data = await _unitOfWork.Authors.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetByIdAuthorResponseDto>(data);
            return result;
        }
        


        public async Task<UpdateAuthorDto> Update(UpdateAuthorCommand request)
        {
            var entity2 = _mapper.Map<Author>(request);
            var result = _unitOfWork.Authors.update(entity2);
            await _unitOfWork.CompleteAsync();

            return new UpdateAuthorDto { Message = "Updated Successfully" };
        }

      
    }
}

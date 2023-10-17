using CSharpFunctionalExtensions;
using MediatR;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Author
{
    public class GetByIdAuthorQueryHandler : IRequestHandler<GetByIdAuthorQuery, Result<GetByIdAuthorResponseDto>>
    {
        private readonly IAuthorService _authorService;

        public GetByIdAuthorQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<Result<GetByIdAuthorResponseDto>> Handle(GetByIdAuthorQuery request, CancellationToken cancellationToken)
        {

            var result = await _authorService.GetByIdAsync(request);
            return Result.Success(result);
        }


    }
}

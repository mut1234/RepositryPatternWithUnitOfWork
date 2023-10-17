using MediatR;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Author
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<GetAllAuthorResponseDto>>
    {
        readonly IAuthorService _authorService;

        public GetAllAuthorQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IEnumerable<GetAllAuthorResponseDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {

            var result = await _authorService.GetAll();
            return result;
        }
    }
}

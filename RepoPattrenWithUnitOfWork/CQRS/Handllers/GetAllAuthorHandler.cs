using MediatR;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers
{
    public class GetAllAuthorHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<AuthorDto>>
    {
        readonly IAuthorService _authorService;

        public GetAllAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {

            var result = await _authorService.GetAll();
            return result;
        }
    }
}

using RepoPattrenWithUnitOfWork.Core.CQRS.Querys;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers
{
    public class GetByIdAuthorHandler
    {
        IAuthorService _authorService;

        public GetByIdAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<AuthorDto> Handle(GetByIdAuthorQuery request, CancellationToken cancellationToken)
        {

            var result = await _authorService.GetByIdAsync(request.Id);
            return result;
        }
    }
}

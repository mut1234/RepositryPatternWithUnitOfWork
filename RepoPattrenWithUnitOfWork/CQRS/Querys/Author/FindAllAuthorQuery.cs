using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author
{
    public class FindAllAuthorQuery : IRequest<Result<IEnumerable<FindAllAuthorResponseDto>>>
    {
        public string Name { get; set; }

    }
    public class FindAllAuthorResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}

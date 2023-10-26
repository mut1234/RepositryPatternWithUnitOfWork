using CSharpFunctionalExtensions;
using MediatR;
using RepoPattrenWithUnitOfWork.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author
{
    public class FindAuthorQuery : IRequest<Result<FindAuthorResponseDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FindAuthorResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

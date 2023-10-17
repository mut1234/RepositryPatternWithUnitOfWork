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
    public class GetByIdAuthorQuery : IRequest<Result<GetByIdAuthorResponseDto>>
    {
        public int Id { get; set; }


    }
    public class GetByIdAuthorResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

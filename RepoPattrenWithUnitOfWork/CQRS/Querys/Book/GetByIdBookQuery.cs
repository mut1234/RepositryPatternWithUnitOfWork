using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book
{
    public class GetByIdBookQuery : IRequest<Result<GetByIdBookResponseDto>>
    {
        public int Id { get; set; }

    }
    public class GetByIdBookResponseDto
    {
        public int Id { get; set; }

    }
}



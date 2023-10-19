using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book
{
    public class FindBookQuery : IRequest<Result<FindBookResponseDto>>
    {
        public int Id { get; set; }
    }
    public class FindBookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
}

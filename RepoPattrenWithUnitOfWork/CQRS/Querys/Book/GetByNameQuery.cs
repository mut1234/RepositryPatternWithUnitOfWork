using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book
{
    public class GetByNameQuery : IRequest<IEnumerable<GetByNameResponseDto>>
    {
        public string Title { get; set; }
    }
    public class GetByNameResponseDto
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }
}

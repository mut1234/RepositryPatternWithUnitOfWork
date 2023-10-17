using MediatR;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book
{
    public class GetAllBookQuery : IRequest<IEnumerable<GetAllBookResponseDto>>
    {
    }
    public class GetAllBookResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }


    }
}

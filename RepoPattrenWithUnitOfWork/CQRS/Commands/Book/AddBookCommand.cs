using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Book
{
    public class AddBookCommand : IRequest<AddBookResponseDto>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }


    }

    public class AddBookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }


    }
}

using CSharpFunctionalExtensions;
using MediatR;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Book
{
    public class UpdateBookCommand : IRequest<Result<UpdateBookResponseDto>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class UpdateBookResponseDto
    {
        public string Message { get; set; }
    }
}

using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Book
{
    public class DeleteBookCommand : IRequest<Result<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteBookResponseDto
    {
        public int Id { get; set; }
    }
}

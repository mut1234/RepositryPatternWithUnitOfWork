using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;


namespace RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author
{
    public class DeleteAuthorCommand : IRequest<Result<string>>
    {
        public int Id { get; set; }
    }
    public class DeleteAuthorResponseDto
    {
        public int Id { get; set; }
    }
}

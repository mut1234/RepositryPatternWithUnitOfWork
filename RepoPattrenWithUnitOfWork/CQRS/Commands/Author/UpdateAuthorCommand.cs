using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author
{
    public class UpdateAuthorCommand : IRequest<Result<UpdateAuthorDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateAuthorDto
    {
        public string Message { get; set; }
    }
}

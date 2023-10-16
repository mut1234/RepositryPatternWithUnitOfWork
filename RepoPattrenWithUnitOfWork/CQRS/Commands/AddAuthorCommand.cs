using MediatR;
using RepoPattrenWithUnitOfWork.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Commands
{
    public class AddAuthorCommand : IRequest<AddAuthorResponseDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }

    public class AddAuthorResponseDto
    {
        public int Id { get; set; }
    }
}

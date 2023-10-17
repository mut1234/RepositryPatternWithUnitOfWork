using MediatR;
using RepoPattrenWithUnitOfWork.Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author
{
    public class GetAllAuthorQuery : IRequest<IEnumerable<GetAllAuthorResponseDto>>
    {
    }

    public class GetAllAuthorResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

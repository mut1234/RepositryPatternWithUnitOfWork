using MediatR;
using RepoPattrenWithUnitOfWork.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Querys
{
    public class GetByIdAuthorQuery : IRequest<IEnumerable<AuthorDto>>
    {
        public int Id { get; set; }

        
    }
}

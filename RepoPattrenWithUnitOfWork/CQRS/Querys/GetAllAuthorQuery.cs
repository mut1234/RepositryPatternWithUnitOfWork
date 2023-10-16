using MediatR;
using RepoPattrenWithUnitOfWork.Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Querys
{
    public class GetAllAuthorQuery : IRequest<IEnumerable<AuthorDto>>
    {
    }
}

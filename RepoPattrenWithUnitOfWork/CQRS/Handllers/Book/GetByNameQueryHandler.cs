using CSharpFunctionalExtensions;
using MediatR;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Book
{
    public class GetByNameQueryHandler : IRequestHandler<GetByNameQuery, IEnumerable<GetByNameResponseDto>>
    {
        private readonly IBookService _bookService;
        public GetByNameQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IEnumerable<GetByNameResponseDto>> Handle(GetByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookService.FindAll(request);
            return result;
        }
    }
}

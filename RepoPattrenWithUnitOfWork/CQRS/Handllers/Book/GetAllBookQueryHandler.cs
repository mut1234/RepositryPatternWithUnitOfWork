using MediatR;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using RepoPattrenWithUnitOfWork.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Book
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, IEnumerable<GetAllBookResponseDto>>
    {
        readonly IBookService _bookService;

        public GetAllBookQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IEnumerable<GetAllBookResponseDto>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookService.GetAll();
            return result;
        }
    }
}

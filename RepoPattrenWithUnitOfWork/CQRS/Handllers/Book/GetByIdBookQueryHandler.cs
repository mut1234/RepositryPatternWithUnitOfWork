using CSharpFunctionalExtensions;
using MediatR;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book;
using RepoPattrenWithUnitOfWork.Core.Data;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using RepoPattrenWithUnitOfWork.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Book
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, Result<GetByIdBookResponseDto>>
    {
        private readonly IBookService _bookService;

        public GetByIdBookQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Result<GetByIdBookResponseDto>> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
        {

            var result = await _bookService.GetByIdAsync(request);
            return result;
        }


    }
}

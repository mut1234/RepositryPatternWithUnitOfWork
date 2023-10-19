using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Book;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Book
{
    public class FindBookQueryHandler : IRequestHandler<FindBookQuery, Result<FindBookResponseDto>>
    {
        private readonly IBookService _bookService;
        private readonly ILogger<FindBookQueryHandler> _logger;

        public FindBookQueryHandler(IBookService bookService, ILogger<FindBookQueryHandler> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }
        public async Task<Result<FindBookResponseDto>> Handle(FindBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookService.FindByIdAsync(request);
            _logger.LogInformation($"Book Founded : " + request.Id);

            return Result.Success(result);
        }


    }
}

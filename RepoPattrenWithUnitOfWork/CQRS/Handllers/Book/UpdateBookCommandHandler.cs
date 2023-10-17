using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Book;
using RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Author;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Book
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Result<UpdateBookResponseDto>>
    {
        private readonly IBookService _bookService;
        private readonly ILogger<UpdateBookCommandHandler> _logger;

        public UpdateBookCommandHandler(IBookService bookService, ILogger<UpdateBookCommandHandler> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }
        public async Task<Result<UpdateBookResponseDto>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookService.Update(request);
            _logger.LogInformation($"Book Updated " + request.Id);

            return Result.Success(result);
        }
    }
}

using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Book;
using RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Author;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using RepoPattrenWithUnitOfWork.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Book
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Result<string>>
    {
        private readonly IBookService _bookService;
        private readonly ILogger<DeleteBookCommandHandler> _logger;

        public DeleteBookCommandHandler(IBookService bookService, ILogger<DeleteBookCommandHandler> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }
        public async Task<Result<string>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookService.Delete(request);
            _logger.LogInformation($"Delete Book " + request.Id);

            return result;
        }
    }
}

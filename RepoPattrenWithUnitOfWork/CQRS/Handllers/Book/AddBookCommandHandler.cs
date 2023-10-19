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
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddBookResponseDto>
    {
        private readonly IBookService _bookService;
        private readonly ILogger<AddBookCommandHandler> _logger;

        public AddBookCommandHandler(IBookService bookService, ILogger<AddBookCommandHandler> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        public async Task<AddBookResponseDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {

            var result = await _bookService.Add(request);
            _logger.LogInformation($"Created New Author " + request.Title + ",Book Id " + result.Id);

            return result;

        }
    }

    }

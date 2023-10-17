using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Author
{
    public class FindAuthorQueryHandler : IRequestHandler<FindAuthorQuery, Result<FindAuthorResponseDto>>
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<FindAuthorQueryHandler> _logger;

        public FindAuthorQueryHandler(IAuthorService authorService, ILogger<FindAuthorQueryHandler> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }
        public async Task<Result<FindAuthorResponseDto>> Handle(FindAuthorQuery request, CancellationToken cancellationToken)
        {
            var result = await _authorService.FindByIdAsync(request);
            _logger.LogInformation($"Author Found : " + request.Id);

            return Result.Success(result);
        }


    }
}

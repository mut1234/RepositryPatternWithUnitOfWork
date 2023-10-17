using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Author
{
    public class FindAllAuthorQueryHandler : IRequestHandler<FindAllAuthorQuery, Result<IEnumerable<FindAllAuthorResponseDto>>>
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<FindAllAuthorQueryHandler> _logger;

        public FindAllAuthorQueryHandler(IAuthorService authorService, ILogger<FindAllAuthorQueryHandler> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }
        public async Task<Result<IEnumerable<FindAllAuthorResponseDto>>> Handle(FindAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var result = await _authorService.FindAll(request);
            _logger.LogInformation($"Author Found : " + request.Name);

            return Result.Success(result);

        }

    }
}

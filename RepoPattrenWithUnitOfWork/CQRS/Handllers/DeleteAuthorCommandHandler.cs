using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Result<string>>
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<DeleteAuthorCommandHandler> _logger;

        public DeleteAuthorCommandHandler(IAuthorService authorService, ILogger<DeleteAuthorCommandHandler> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }
        public async Task<Result<string>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorService.Delete(request);
            _logger.LogInformation($"Delete Author " + request.Id);

            return result;
        }
    }
}

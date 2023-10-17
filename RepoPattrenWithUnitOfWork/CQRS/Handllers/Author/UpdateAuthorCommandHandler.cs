using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.Extensions.Logging;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Author
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Result<UpdateAuthorDto>>
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<UpdateAuthorCommandHandler> _logger;

        public UpdateAuthorCommandHandler(IAuthorService authorService, ILogger<UpdateAuthorCommandHandler> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }
        public async Task<Result<UpdateAuthorDto>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorService.Update(request);
            _logger.LogInformation($"Author Updated " + request.Id);

            return Result.Success(result);
        }
    }
}

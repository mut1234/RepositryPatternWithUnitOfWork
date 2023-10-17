using MediatR;
using Microsoft.Extensions.Logging;
using RepoPattrenWithUnitOfWork.Core.CQRS.Commands.Author;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;


namespace RepoPattrenWithUnitOfWork.Core.CQRS.Handllers.Author
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, AddAuthorResponseDto>
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AddAuthorCommandHandler> _logger;

        public AddAuthorCommandHandler(IAuthorService authorService, ILogger<AddAuthorCommandHandler> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        public async Task<AddAuthorResponseDto> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {

            var result = await _authorService.Add(request);
            _logger.LogInformation($"Created New Author " + request.Name + ",Author Id " + result.Id);

            return result;

        }
    }
}

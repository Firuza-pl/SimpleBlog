using Blog.Application.Commands.ProjectCommands;
using Blog.Application.Services.Interfaces;
using FluentValidation;


namespace Blog.Application.Commands.OrderDetails
{
    public class CreateOrderDetailsCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        private readonly ILookupService _lookupService;

        public CreateOrderDetailsCommandValidator(ILookupService lookupService)
        {
            _lookupService = lookupService;

            RuleFor(x => x.Title).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(20);
        }

        private async Task<bool> NotContainsForbiddenWords(string content, CancellationToken cancellationToken)
        {
            var forbiddenWords = await _lookupService.GetForbiddenWordsAsync();
            var hasForbiddenWord = false;
            if (forbiddenWords.Any(x => content.Contains(x)))
            {
                hasForbiddenWord = true;
            }
            return !hasForbiddenWord;
        }
    }
}

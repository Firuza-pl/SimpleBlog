using Blog.Application.Services.Interfaces;
using FluentValidation;

namespace Blog.Application.Commands.ProductCommand
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly ILookupService _lookupService;

        public CreateProductCommandValidator(ILookupService lookupService)
        {
            _lookupService = lookupService;

            RuleFor(x => x.ProductCode)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(100000)
                .MustAsync(NotContainsForbiddenWords);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(100000)
                .MustAsync(NotContainsForbiddenWords);

            RuleFor(x => x.ListPrice)
                  .NotEmpty()
                  .MaximumLength(100000)
                  .MustAsync(NotContainsForbiddenWords);

        }

        private async Task<bool> NotContainsForbiddenWords(string content, CancellationToken cancellationToken)
        {
            var forbiddenWords = await _lookupService.GetForbiddenWordsAsync();
            var contentHasForbiddenWords = false;

            if (forbiddenWords.Any(x => content.Contains(x)))
            {
                contentHasForbiddenWords = true;
            }

            return !contentHasForbiddenWords;
        }
    }
}

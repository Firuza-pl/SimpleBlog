using Blog.Application.Services.Interfaces;
using FluentValidation;

namespace Blog.Application.Commands.ProdcutsTag
{
    public class CreateProTagCommandValidator : AbstractValidator<CreateProTagCommand>
    {
        private readonly ILookupService _lookupService;

        public CreateProTagCommandValidator(ILookupService lookupService)
        {
            _lookupService = lookupService;

            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.TagId).NotEmpty();
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
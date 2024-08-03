using Blog.Domain.Core;
using Blog.Domain.Entities.Tag;
using Blog.Domain.Repositories.Interfaces;
using MediatR;
namespace Blog.Application.Commands.ProdcutsTag
{
    public class CreateProTagCommandHandler : IRequestHandler<CreateProTagCommand>
    {
        public readonly IProductTagsRepository _productTagRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CreateProTagCommandHandler(IProductTagsRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProTagCommand request, CancellationToken cancellationToken)
        {
            var protags = new ProductTags(request.ProductTagId,request.ProductId, request.TagId);
            await _productTagRepository.AddAsync(protags);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

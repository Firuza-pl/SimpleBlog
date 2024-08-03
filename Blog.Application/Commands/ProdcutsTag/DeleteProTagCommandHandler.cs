using Blog.Application.Exceptions;
using Blog.Domain.Core;
using Blog.Domain.Entities.Tag;
using Blog.Domain.Repositories.Interfaces;
using MediatR;

namespace Blog.Application.Commands.ProdcutsTag
{
    public class DeleteProTagCommandHandler : IRequestHandler<DeleteProTagCommand>
    {
        private readonly IProductTagsRepository _productTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProTagCommandHandler(IProductTagsRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProTagCommand request, CancellationToken cancellationToken)
        {
            var proTags = await _productTagRepository.GetProductTagByIdAsync(request.ProductTagId);
            if (proTags == null)
            {
                throw new NotFoundException(nameof(ProductTags), request.ProductTagId);
            }

            proTags.Remove();
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

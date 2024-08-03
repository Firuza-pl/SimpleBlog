using Blog.Application.Exceptions;
using Blog.Domain.Core;
using Blog.Domain.Entities.ProductAggregate;
using Blog.Domain.Repositories.Interfaces;
using MediatR;

namespace Blog.Application.Commands.ProductCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new NotFoundException(nameof(Products), request.ProductId);
            }


            product.Remove();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

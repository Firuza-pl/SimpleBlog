using Blog.Domain.Core;
using Blog.Domain.Entities.ProductAggregate;
using Blog.Domain.Repositories.Interfaces;
using MediatR;

namespace Blog.Application.Commands.ProductCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Products(request.ProductId, request.ProductCode, request.ProductName, request.Description, request.ListPrice, request.Status);
            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

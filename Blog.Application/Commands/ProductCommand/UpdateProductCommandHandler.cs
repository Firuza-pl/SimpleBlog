using Blog.Application.Exceptions;
using Blog.Client.Pages.Product;
using Blog.Domain.Core;
using Blog.Domain.Repositories.Interfaces;
using Blog.Shared.Enums;
using MediatR;

namespace Blog.Application.Commands.ProductCommand
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            product.Status = ProductStatus.Created;
            
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }
         
            product.Edit(request.ProductCode, request.ProductName, request.Description, request.ListPrice);
         
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

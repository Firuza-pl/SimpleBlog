using Blog.Application.Exceptions;
using Blog.Domain.Core;
using Blog.Domain.Entities.OrderAggregate;
using Blog.Domain.Repositories.Interfaces;
using MediatR;

namespace Blog.Application.Commands.OrderDetails
{
    public class UpdateOrderDetailsCommandHandler : IRequestHandler<UpdateOrderDetailsCommand>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository, IUnitOfWork unitOfWork)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            //order
            var getOrderById = await _orderDetailsRepository.GetById(request.OrderId);
            
            if (getOrderById == null)
            {
                throw new NotFoundException(nameof(Order), request.OrderId);
            }

            getOrderById.Edit(request.ShippedDate);

            //orderdetails
            var getOrderDetailsById = await _orderDetailsRepository.GetOrderById(request.OrderId);

            if (getOrderDetailsById == null)
            {
                throw new NotFoundException(nameof(OrderDetail), request.OrderDetailId);
            }
            getOrderDetailsById.Edit(request.ProductsId, getOrderById.OrderId, request.Quantity, request.UnitPrice);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

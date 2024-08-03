using Blog.Domain.Core;
using Blog.Domain.Entities.OrderAggregate;
using Blog.Domain.Repositories.Interfaces;
using MediatR;


namespace Blog.Application.Commands.OrderDetails
{
    public class CreateOrderDetailsCommandHandler : IRequestHandler<CreateOrderDetailsCommand>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository, IUnitOfWork unitOfWork)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            //add order, get OrderId
            var newOrder = new Order(
                 Guid.NewGuid(),
                 request.ShippedDate // shippedDate;
                 // status will use the default value
             );

            await _orderDetailsRepository.AddOrderAsync(newOrder);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //add orderdetails, add OrderId
            var orderDetails = new OrderDetail(request.OrderDetailId, request.ProductsId, newOrder.OrderId, request.Quantity, request.UnitPrice);
            await _orderDetailsRepository.AddAsync(orderDetails);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

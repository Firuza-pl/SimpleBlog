using Blog.Application.Exceptions;
using Blog.Domain.Core;
using Blog.Domain.Entities.OrderAggregate;
using Blog.Domain.Repositories.Interfaces;
using MediatR;
namespace Blog.Application.Commands.OrderDetails
{
    public class DeleteOrderDetailsCommandHandler : IRequestHandler<DeleteOrderDetailsCommand>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository, IUnitOfWork unitOfWork)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOrderDetailsCommand detailsCommand, CancellationToken cancellation)
        {
            var getId = await _orderDetailsRepository.GetOrderById(detailsCommand.OrderDetailsId);
            if(getId == null)
            {
                throw new NotFoundException(nameof(OrderDetail),detailsCommand.OrderDetailsId);
            }
            getId.Remove();

            await _unitOfWork.SaveChangesAsync(cancellation);
            return Unit.Value;
        }

    }
}

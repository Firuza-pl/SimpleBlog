using Blog.Domain.Core;
using Blog.Infrastructure.Services.Interfaces;
using MediatR;

namespace Blog.Infrastructure.Services
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        //IPublisher is responsible for to publish domain events
        private readonly IPublisher _mediator;

        public DomainEventsDispatcher(IPublisher mediator)
        {
            _mediator = mediator;
        }

        public async Task DispatchEventsAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                //iterates through the provided domian events and async publishes each event using mediator object
                await _mediator.Publish(domainEvent);
            }
        }
    }
}

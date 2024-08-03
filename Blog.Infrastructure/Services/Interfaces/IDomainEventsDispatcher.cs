using Blog.Domain.Core;

namespace Blog.Infrastructure.Services.Interfaces
{
    public interface IDomainEventsDispatcher
    {
        //is to define contract for classes that handle a domain object async
        Task DispatchEventsAsync(IEnumerable<IDomainEvent> domainEvents);
    }
}

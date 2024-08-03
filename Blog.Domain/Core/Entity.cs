namespace Blog.Domain.Core
{
    public abstract class Entity
    {
        //NOTES: DomainEvent are part of DDD
        //this code allows entity to collect and manage domain events and provide method for accesing  and clearing those events when needed 
        private readonly IList<IDomainEvent> _domainEvents = new List<IDomainEvent>(); //collect domain events releated to entitiy

        public IEnumerable<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.AsEnumerable(); //iterate over domain without modifiying list
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear(); //it will work, after domain events have been processed and ensure that they are not processed again.
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);//allows external code to add new domain event to the list, typically raised when some event occurs and need to be captured for further operations
        }

    }
}

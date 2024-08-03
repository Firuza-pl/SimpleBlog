using Blog.Domain.Core;
using Blog.Domain.Events;

namespace Blog.Domain.Entities.ProjectAggregate
{
    public class Project : Entity, IAggregateRoot
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

        public bool isRemoved { get; set; }

        public Project(Guid projectId, string title, string description)
        {
            ProjectId = projectId;
            Title = title;
            Description = description;
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;
            isRemoved = false;
        }

        public void Edit(string title, string description)
        {
            Title = title;
            Description = description;
            CreationDate = DateTime.UtcNow;
            ModificationDate= DateTime.UtcNow;
        }

        public void Remove ()
        {
            isRemoved = true;
        }

}
}

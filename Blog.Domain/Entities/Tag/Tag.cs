using Blog.Shared.Enums;

namespace Blog.Domain.Entities.Tag
{
    public class Tag
    {
        public Guid TagId { get; set; }
        public string Name { get; set; }
        public TagStatus Status { get; set; }
        public ICollection<ProductTags> ProductTags { get; set; }

        public Tag(Guid tagId, string name, TagStatus status = TagStatus.Created)
        {
            TagId = tagId;
            Name = name;
            Status = status;
        }

        public void Edit(string name)
        {
            Name = name;
            Status = TagStatus.Created;
        }

        public void Remove()
        {
            Status = TagStatus.Deleted;
        }
    }
}

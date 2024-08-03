using MediatR;

namespace Blog.Application.Commands.ProdcutsTag
{
    public class UpdateProTagCommand : IRequest
    {
        public Guid ProductTagId { get; set; }
        public Guid ProductId { get; set; }
        public Guid TagId { get; set; }
        }
    }

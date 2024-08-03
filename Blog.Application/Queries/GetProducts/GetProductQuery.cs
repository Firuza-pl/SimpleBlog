using Blog.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Queries.GetProducts
{
    public class GetProductQuery : IRequest<IEnumerable<ProductDTO>>
    {
        public GetProductQuery()
        {

        }
    }
}

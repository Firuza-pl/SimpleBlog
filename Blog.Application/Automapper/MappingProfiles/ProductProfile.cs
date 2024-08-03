using AutoMapper;
using Blog.Domain.Entities.ProductAggregate;
using Blog.Shared.DTOs;

namespace Blog.Application.Automapper.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductDTO>();
        }
    }
}

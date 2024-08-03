using AutoMapper;
using Blog.Domain.Entities.OrderAggregate;
using Blog.Shared.DTOs;

namespace Blog.Application.Automapper.MappingProfiles
{
    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetail, OrderDetailsDTO>();
        }
    }
}

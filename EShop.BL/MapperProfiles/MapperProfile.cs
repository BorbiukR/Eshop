using AutoMapper;
using EShop.BL.DTOs;
using EShop.BL.DTOs.Enums;
using EShop.DAL.Models;
using EShop.DAL.Models.Enums;

namespace EShop.API.MapperProfiles
{
    public class MapperProfile : Profile
    {   
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap(); ;
            CreateMap<Product, ProductDTO>().ReverseMap(); ;
            CreateMap<ProductCategory, ProductCategoryDTO>().ReverseMap(); ;
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap(); ;
            CreateMap<Order, OrderDTO>().ReverseMap().ReverseMap(); ;
            CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap(); ;
        }
    }
}
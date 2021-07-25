using AutoMapper;
using Eshop.DAL.Enums;
using Eshop.DAL.Models;
using EShop.BL.DTOs;
using EShop.BL.DTOs.Enums;
using EShop.BL.Enums;
using EShop.DAL.Enums;
using EShop.DAL.Models;

namespace EShop.API.MapperProfiles
{
    public class BLMapperProfile : Profile
    {   // TODO : пофісити using підключення
        // TODO : зробити інтерфейс IMapFrom<T> з методом з реалізацією по дефолту, щоб автоматично налаштовувати
        public BLMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap().PreserveReferences();
            CreateMap<Product, ProductDTO>().ReverseMap().PreserveReferences();
            CreateMap<ProductCategory, ProductCategoryDTO>().ReverseMap().PreserveReferences();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap().PreserveReferences();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusDTO>().ReverseMap().PreserveReferences();
        }
    }
}
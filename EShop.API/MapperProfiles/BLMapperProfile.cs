using AutoMapper;
using EShop.BL.DTOs;
using EShop.BL.DTOs.Enums;
using EShop.DAL.Models;
using EShop.DAL.Models.Enums;

namespace EShop.API.MapperProfiles
{
    public class BLMapperProfile : Profile
    {  // TODO : зробити інтерфейс IMapFrom<T> з методом з реалізацією по дефолту, щоб автоматично налаштовувати
       // в repo папці є проект CleanAPI (відеоурок з ютуба)
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
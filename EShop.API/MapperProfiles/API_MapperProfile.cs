using AutoMapper;
using EShop.API.Models.Response;
using EShop.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.API.MapperProfiles
{
    public class API_MapperProfile : Profile
    {
        public API_MapperProfile()
        {
            CreateMap<ProductDTO, ProductResponse>().ReverseMap();

            CreateMap<ProductDTO, ProductResponse>();
        }
     
    }
}

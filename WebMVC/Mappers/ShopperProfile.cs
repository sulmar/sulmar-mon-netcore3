using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.ViewModels;

namespace WebMVC.Mappers
{
    public class ShopperProfile : Profile
    {
        public ShopperProfile()
        {
            CreateMap<Product, ProductViewModel>()
               .ForMember(dst => dst.Price, src => src.MapFrom(src => src.UnitPrice))
               .ForMember(dst => dst.BrandName, src => src.MapFrom(src => src.Brand.FirstName + src.Brand.LastName));

        }
    }
}

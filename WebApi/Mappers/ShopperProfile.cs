using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTOs;

namespace WebApi.Mappers
{
    // Install-Package AutoMapper
    public class ShopperProfile : Profile
    {
        public ShopperProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dst=>dst.FullName, 
src => src.MapFrom(src => src.FirstName + " " + src.LastName  ))
                .ForMember(
                    dst => dst.Sex,
                     src => src.MapFrom(src => src.Gender));
                ;

            // CreateMap<CustomerDTO, Customer>();
        }
    }
}

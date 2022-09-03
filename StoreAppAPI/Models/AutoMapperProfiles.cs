using AutoMapper;
using StoreAppAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppAPI.Models
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(m=>m.Brand, c=>c.MapFrom(s => s.Brand.Name))
                .ForMember(m=>m.Category, c=>c.MapFrom(s => s.Category.Name));
        }
    }
}

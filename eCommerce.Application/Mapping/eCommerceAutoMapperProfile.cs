using AutoMapper;
using eCommerce.Application.Responses;
using eCommerce.Domain.eCommerceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Mapping
{
    public class eCommerceAutoMapperProfile : Profile
    {
        public eCommerceAutoMapperProfile()
        {
            CreateMap<User, GetUserResponse>().ReverseMap();
            CreateMap<Brand, GetBrandResponse>().ReverseMap();
            CreateMap<Category, GetCategoryResponse>().ReverseMap();
        }
    }
}

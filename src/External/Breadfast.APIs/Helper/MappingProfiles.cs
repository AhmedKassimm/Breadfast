using AutoMapper;
using Breadfast.Application.Dtos.ProductsDtos;
using Breadfast.Domain.Entities.Products;
using Microsoft.AspNetCore.Mvc;

namespace Breadfast.APIs.Helper
{
    public class MappingProfiles: Profile
    {

        public MappingProfiles()
        {
            // Mapping from Product to ProductToReturnDto


            CreateMap<Product, ProductToReturnDto>()
                .ForMember(D => D.Brand, P => P.MapFrom(S => S.Brand!.Name))
                .ForMember(D => D.Category, P=> P.MapFrom(S => S.Category!.Name));

        }

    }
}

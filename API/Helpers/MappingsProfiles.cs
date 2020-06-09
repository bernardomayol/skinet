using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
  public class MappingsProfiles : Profile
  {
    public MappingsProfiles()
    {
      CreateMap<Product, ProductToReturnDto>()
      .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
      .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
      .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

    }
  }
}
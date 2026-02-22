using AutoMapper;
using JuddFashion.API.Models.DTOs;

namespace JuddFashion.API.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString())).ForMember(dest => dest.Variants, opt => opt.MapFrom(src => src.Variants));
            CreateMap<ProductVariant, ProductVariantDTO>().ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.ToString())).ForMember(dest => dest.FinalPrice, opt => opt.MapFrom(src => src.Product.BasePrice + (src.PriceAdjustment ?? 0)));
        }
    }
}

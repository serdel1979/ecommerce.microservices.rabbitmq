using AutoMapper;
using Products.API.DTOs;
using Products.API.Model;

namespace Products.API.Utilities
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductResponseDTO>()
                .ForMember(x => x.Category, options => options.MapFrom(MapCategory));
            CreateMap<ProductDTO, Product>();
        }

        private Category MapCategory(Product product, ProductResponseDTO productResponseDto)
        {

            //acá puedo agregar lógica de mapeo entre los dto

            return product.Category;
        }


    }
}

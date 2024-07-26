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
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}

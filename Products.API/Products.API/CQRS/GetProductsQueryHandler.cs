using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.API.CQRS.Queries;
using Products.API.DTOs;
using Products.API.Infra;
using Products.API.Model;
using Products.API.Repository;

namespace Products.API.CQRS
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, (List<ProductResponseDTO> Products, int TotalRecords)>
    {

        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IGenericRepository<Product> repository, IMapper mapper)
        {

            this._repository = repository;
            this._mapper = mapper;
        }
        //Task<(List<Product> Products, int TotalRecords)>
        public async Task<(List<ProductResponseDTO> Products, int TotalRecords)> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var (products, totalRecords) = await _repository.GetAll(request.Page, request.Size, "Category");

            var productDtos = _mapper.Map<List<ProductResponseDTO>>(products);

            return (productDtos, totalRecords);

        }
    }
}

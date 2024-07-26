using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.API.CQRS.Queries;
using Products.API.DTOs;
using Products.API.Infra;
using Products.API.Model;

namespace Products.API.CQRS
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductResponseDTO>>
    {
        private readonly ProductsContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(ProductsContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<ProductResponseDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.Include(c=>c.Category).ToListAsync();                       
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }
    }
}

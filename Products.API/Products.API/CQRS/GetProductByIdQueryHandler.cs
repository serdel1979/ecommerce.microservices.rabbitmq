using AutoMapper;
using MediatR;
using Products.API.CQRS.Queries;
using Products.API.DTOs;
using Products.API.Model;
using Products.API.Repository;

namespace Products.API.CQRS
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponseDTO>
    {

        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IGenericRepository<Product> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        async Task<ProductResponseDTO> IRequestHandler<GetProductByIdQuery, ProductResponseDTO>.Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.Get(request.Id, "Category");

            if (product == null)
            {
                throw new KeyNotFoundException();
            }

            return _mapper.Map<ProductResponseDTO>(product);
        }
    }
}

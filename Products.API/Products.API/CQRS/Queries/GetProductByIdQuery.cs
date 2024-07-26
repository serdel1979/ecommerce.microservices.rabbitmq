using MediatR;
using Products.API.DTOs;

namespace Products.API.CQRS.Queries
{
    public class GetProductByIdQuery : IRequest<ProductResponseDTO>
    {
        public int Id { get; set; }
    }
}

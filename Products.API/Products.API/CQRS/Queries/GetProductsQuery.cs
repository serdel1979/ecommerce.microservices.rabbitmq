using MediatR;
using Products.API.DTOs;
using Products.API.Model;

namespace Products.API.CQRS.Queries
{
    public class GetProductsQuery : IRequest<List<ProductResponseDTO>>
    {
    }
}

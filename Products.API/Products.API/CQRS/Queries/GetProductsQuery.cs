using MediatR;
using Products.API.DTOs;
using Products.API.Model;

namespace Products.API.CQRS.Queries
{
    //(List<ProductResponseDTO>, int TotalRecords)
    public class GetProductsQuery : IRequest<(List<ProductResponseDTO>, int TotalRecords)>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 5;
    }
}

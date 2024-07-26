using MediatR;
using Products.API.Model;

namespace Products.API.CQRS.Commands
{
    public class CreateProductCommand : IRequest<int> 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}

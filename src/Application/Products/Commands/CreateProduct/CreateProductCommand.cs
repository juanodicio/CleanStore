using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
    }

    class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = new Guid(),
                Name = request.Name,
                Description = request.Description,
                Sku = request.Sku,
                Stock = request.Stock,
                Brand = request.Brand,
                Price = request.Price
            };
            return product;
        }
    }
    
}
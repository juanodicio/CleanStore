using System;
using System.Threading;
using Application.Products.Commands.CreateProduct;
using MediatR;
using Xunit;

namespace Application.IntegrationTests
{
    public class CreateProductTest
    {
        private readonly IMediator _mediator;

        public CreateProductTest(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Fact]
        public async void AddProduct()
        {
            var createCommand = new CreateProductCommand()
            {
                Name = "HyperX Alloy Origins Core",
                Brand = "HyperX",
                Price = 285,
                Description = "Compact keyboard with TKL layout",
                Sku = "P00EERWER235",
                Stock = 50
            };

            var product = await _mediator.Send(createCommand);
            
            
            Assert.Equal(product.Name, createCommand.Name);
        }

        [Fact]
        public void DumbFailingTests()
        {
            Assert.False(false);
        }
        
    }
}

using System;
using System.Threading;
using Application.Products.Commands.CreateProduct;
using Xunit;

namespace Application.UnitTests
{
    public class CreateProductTest
    {
        [Fact]
        public async void AddProduct()
        {
            var createCommand = new CreateProductCommand()
            {
                Name = "HyperX Alloy 60",
                Brand = "HyperX",
                Price = 350,
                Description = "Compact keyboard with 60% layout",
                Sku = "P00EERWER234",
                Stock = 50
            };
            var commandHandler = new CreateProductCommandHandler();

            var product = await commandHandler.Handle(createCommand, new CancellationToken());
            
            Assert.Equal(product.Name, createCommand.Name);
        }

        [Fact]
        public void DumbFailingTests()
        {
            Assert.False(false);
        }
        
    }
}

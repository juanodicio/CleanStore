using System.Linq;
using System.Threading.Tasks;
using Application.Products.Commands.CreateProduct;
using FluentAssertions;
using MediatR;
using Xunit;

namespace Application.IntegrationTests
{
    public class CreateManyProducts: IClassFixture<DbFixture>
    {
        private readonly DbFixture _dbFixture;
        private readonly IMediator _mediator;

        public CreateManyProducts(DbFixture dbFixture, IMediator mediator)
        {
            _dbFixture = dbFixture;
            _mediator = mediator;
            _dbFixture.ResetState();
        }

        [Fact]
        public async Task CreateMultipleProducts()
        {
            var createProductCmd = new CreateProductCommand
            {
                Name = "Origins core 60",
                Price = 390,
                Description = "Ultra compact keyboard",
                Brand = "HyperX"
            }; 
            
            await _mediator.Send(createProductCmd);
            await _mediator.Send(createProductCmd);
            await _mediator.Send(createProductCmd);

            var prodCount = _dbFixture.DbContext().Products.Count();

            prodCount.Should().Be(3);
        }
    }
}
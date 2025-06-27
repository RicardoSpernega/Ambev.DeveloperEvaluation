using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class DeleteSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository = Substitute.For<ISaleRepository>();
        private readonly ILogger<DeleteSaleHandler> _logger = Substitute.For<ILogger<DeleteSaleHandler>>();

        [Fact]
        public async Task Handle_ValidRequest_DeletesSaleAndLogsEvent()
        {
            var sale = SaleTestData.GenerateValidSale();
            var command = new DeleteSaleCommand { SaleId = sale.Id };
            var handler = new DeleteSaleHandler(_saleRepository, _logger);
            var result = await handler.Handle(command, CancellationToken.None);
            await _saleRepository.Received(1).DeleteAsync(command.SaleId);
            _logger.Received().LogInformation(Arg.Any<string>());
            Assert.True(result.Success);
            Assert.Equal(command.SaleId, result.SaleId);
        }
    }
} 
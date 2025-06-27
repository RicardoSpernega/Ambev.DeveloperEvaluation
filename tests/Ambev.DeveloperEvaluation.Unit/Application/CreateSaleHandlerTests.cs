using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository = Substitute.For<ISaleRepository>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();
        private readonly ILogger<CreateSaleHandler> _logger = Substitute.For<ILogger<CreateSaleHandler>>();

        [Fact]
        public async Task Handle_ValidRequest_CreatesSaleAndLogsEvent()
        {
            var sale = SaleTestData.GenerateValidSale();
            var command = new CreateSaleCommand
            {
                SaleNumber = sale.SaleNumber,
                Date = sale.Date,
                CustomerId = sale.CustomerId,
                CustomerName = sale.CustomerName,
                BranchId = sale.BranchId,
                BranchName = sale.BranchName,
                Items = new List<CreateSaleItemDto>()
            };
            foreach (var item in sale.Items)
            {
                command.Items.Add(new CreateSaleItemDto
                {
                    ProductId = item.ProductId,
                    ProductDescription = item.ProductDescription,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }
            _mapper.Map<Sale>(command).Returns(sale);
            _mapper.Map<CreateSaleResult>(sale).Returns(new CreateSaleResult { SaleId = sale.Id });

            var handler = new CreateSaleHandler(_saleRepository, _mapper, _logger);
            var result = await handler.Handle(command, CancellationToken.None);

            await _saleRepository.Received(1).AddAsync(sale);
            _logger.Received().LogInformation(Arg.Any<string>());
            Assert.Equal(sale.Id, result.SaleId);
        }
    }
} 
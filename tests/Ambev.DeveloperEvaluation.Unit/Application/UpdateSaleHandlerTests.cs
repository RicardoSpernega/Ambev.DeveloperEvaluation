using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class UpdateSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository = Substitute.For<ISaleRepository>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();
        private readonly ILogger<UpdateSaleHandler> _logger = Substitute.For<ILogger<UpdateSaleHandler>>();

        [Fact]
        public async Task Handle_ValidRequest_UpdatesSaleAndLogsEvent()
        {
            var sale = SaleTestData.GenerateValidSale();
            var command = new UpdateSaleCommand
            {
                SaleId = sale.Id,
                SaleNumber = sale.SaleNumber,
                Date = sale.Date,
                CustomerId = sale.CustomerId,
                CustomerName = sale.CustomerName,
                BranchId = sale.BranchId,
                BranchName = sale.BranchName,
                Items = new List<UpdateSaleItemDto>()
            };
            foreach (var item in sale.Items)
            {
                command.Items.Add(new UpdateSaleItemDto
                {
                    ProductId = item.ProductId,
                    ProductDescription = item.ProductDescription,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    Cancelled = item.Cancelled
                });
            }
            _saleRepository.GetByIdAsync(command.SaleId).Returns(sale);
            _mapper.Map(command, sale).Returns(sale);
            _mapper.Map<UpdateSaleResult>(sale).Returns(new UpdateSaleResult { SaleId = sale.Id });

            var handler = new UpdateSaleHandler(_saleRepository, _mapper, _logger);
            var result = await handler.Handle(command, CancellationToken.None);

            await _saleRepository.Received(1).UpdateAsync(sale);
            _logger.Received().LogInformation(Arg.Any<string>());
            Assert.Equal(sale.Id, result.SaleId);
        }
    }
} 
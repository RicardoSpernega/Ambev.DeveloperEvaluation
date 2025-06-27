using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using NSubstitute;
using AutoMapper;
using Bogus;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class GetSaleHandlerTests
    {
        private readonly ISaleRepository _saleRepository = Substitute.For<ISaleRepository>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();

        [Fact]
        public async Task Handle_ValidRequest_ReturnsSale()
        {
            var sale = SaleTestData.GenerateValidSale();
            var command = new GetSaleCommand { SaleId = sale.Id };
            var resultDto = new GetSaleResult { SaleId = sale.Id };
            _saleRepository.GetByIdAsync(sale.Id).Returns(sale);
            _mapper.Map<GetSaleResult>(sale).Returns(resultDto);

            var handler = new GetSaleHandler(_saleRepository, _mapper);
            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(sale.Id, result.SaleId);
        }
    }
} 
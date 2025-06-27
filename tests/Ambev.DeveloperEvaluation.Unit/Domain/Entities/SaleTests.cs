using System;
using Xunit;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        [Fact]
        public void AddItem_WithQuantityAbove20_ThrowsException()
        {
            var sale = SaleTestData.GenerateValidSale();
            var item = SaleTestData.GenerateInvalidSaleItem_TooManyQuantity();
            Assert.Throws<InvalidOperationException>(() => sale.AddItem(item));
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0.10)]
        [InlineData(10, 0.20)]
        [InlineData(20, 0.20)]
        public void ApplyDiscount_AppliesCorrectDiscount(int quantity, decimal expectedDiscount)
        {
            var item = SaleTestData.GenerateValidSaleItem();
            item.Quantity = quantity;
            item.ApplyDiscount();
            Assert.Equal(expectedDiscount, item.Discount);
        }

        [Fact]
        public void Cancel_SetsStatusToCancelled()
        {
            var sale = SaleTestData.GenerateValidSale();
            sale.Cancel();
            Assert.Equal(SaleStatus.Cancelled, sale.Status);
        }
    }
} 
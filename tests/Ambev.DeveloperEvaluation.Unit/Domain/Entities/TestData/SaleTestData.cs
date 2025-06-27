using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class SaleTestData
    {
        private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
            .RuleFor(i => i.ProductId, f => f.Random.Guid().ToString())
            .RuleFor(i => i.ProductDescription, f => f.Commerce.ProductName())
            .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
            .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(1, 100))
            .RuleFor(i => i.Discount, 0)
            .RuleFor(i => i.TotalAmount, f => f.Finance.Amount(1, 100))
            .RuleFor(i => i.Cancelled, false);

        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
            .RuleFor(s => s.Id, f => f.Random.Guid())
            .RuleFor(s => s.SaleNumber, f => f.Commerce.Ean13())
            .RuleFor(s => s.Date, f => f.Date.Past())
            .RuleFor(s => s.CustomerId, f => f.Random.Guid().ToString())
            .RuleFor(s => s.CustomerName, f => f.Name.FullName())
            .RuleFor(s => s.BranchId, f => f.Random.Guid().ToString())
            .RuleFor(s => s.BranchName, f => f.Company.CompanyName())
            .RuleFor(s => s.TotalAmount, f => f.Finance.Amount(10, 1000))
            .RuleFor(s => s.Status, f => f.PickRandom(SaleStatus.Active, SaleStatus.Cancelled))
            .RuleFor(s => s.Items, f => SaleItemFaker.Generate(f.Random.Int(1, 5)));

        public static Sale GenerateValidSale()
        {
            return SaleFaker.Generate();
        }

        public static SaleItem GenerateValidSaleItem()
        {
            return SaleItemFaker.Generate();
        }

        public static SaleItem GenerateInvalidSaleItem_TooManyQuantity()
        {
            var item = SaleItemFaker.Generate();
            item.Quantity = 21;
            return item;
        }

        public static SaleItem GenerateInvalidSaleItem_TooFewQuantityWithDiscount()
        {
            var item = SaleItemFaker.Generate();
            item.Quantity = 2;
            item.Discount = 0.10m;
            return item;
        }
    }
} 
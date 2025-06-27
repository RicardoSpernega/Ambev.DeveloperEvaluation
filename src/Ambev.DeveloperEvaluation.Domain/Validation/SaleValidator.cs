using System;
using System.Linq;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public static class SaleValidator
    {
        public static void Validate(Sale sale)
        {
            foreach (var item in sale.Items)
            {
                if (item.Quantity > 20)
                    throw new InvalidOperationException($"Cannot sell more than 20 units of product {item.ProductDescription}.");
                if (item.Quantity < 4 && item.Discount > 0)
                    throw new InvalidOperationException($"Discount not allowed for less than 4 units of product {item.ProductDescription}.");
            }
        }
    }
} 
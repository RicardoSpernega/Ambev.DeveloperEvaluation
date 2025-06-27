using System;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Cancelled { get; set; }

        public SaleItem()
        {
            Id = Guid.NewGuid();
        }

        public void ApplyDiscount()
        {
            if (Quantity < 4)
            {
                Discount = 0;
            }
            else if (Quantity >= 4 && Quantity < 10)
            {
                Discount = 0.10m;
            }
            else if (Quantity >= 10 && Quantity <= 20)
            {
                Discount = 0.20m;
            }
            else
            {
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");
            }
            TotalAmount = Quantity * UnitPrice * (1 - Discount);
        }

        public void Cancel()
        {
            Cancelled = true;
        }
    }
} 
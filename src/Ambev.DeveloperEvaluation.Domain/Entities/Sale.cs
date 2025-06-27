using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public decimal TotalAmount { get; set; }
        public SaleStatus Status { get; set; }
        public List<SaleItem> Items { get; set; } = new();

        public Sale()
        {
            Id = Guid.NewGuid();
            Date = DateTime.UtcNow;
            Status = SaleStatus.Active;
        }

        public void AddItem(SaleItem item)
        {
            if (item.Quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");
            Items.Add(item);
            RecalculateTotal();
        }

        public void RecalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                item.ApplyDiscount();
                total += item.TotalAmount;
            }
            TotalAmount = total;
        }

        public void Cancel()
        {
            Status = SaleStatus.Cancelled;
        }
    }
} 
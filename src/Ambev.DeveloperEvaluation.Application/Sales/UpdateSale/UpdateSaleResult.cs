using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleResult
    {
        public Guid SaleId { get; set; }
        public string SaleNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public List<UpdateSaleItemResultDto> Items { get; set; }
    }

    public class UpdateSaleItemResultDto
    {
        public string ProductId { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Cancelled { get; set; }
    }
} 
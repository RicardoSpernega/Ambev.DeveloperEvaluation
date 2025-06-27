using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResult
    {
        public Guid SaleId { get; set; }
        public string SaleNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public List<CreateSaleItemResultDto> Items { get; set; }
    }

    public class CreateSaleItemResultDto
    {
        public string ProductId { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
} 
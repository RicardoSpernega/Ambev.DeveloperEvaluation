using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleResponse
    {
        public Guid SaleId { get; set; }
        public string SaleNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public List<UpdateSaleItemResponse> Items { get; set; }
    }

    public class UpdateSaleItemResponse
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
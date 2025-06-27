using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
    {
        public DeleteSaleRequestValidator()
        {
            RuleFor(x => x.SaleId).NotEmpty();
        }
    }

    public class DeleteSaleRequest
    {
        public Guid SaleId { get; set; }
    }
} 
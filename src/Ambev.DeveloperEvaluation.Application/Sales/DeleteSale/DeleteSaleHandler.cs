using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using OneOf.Types;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ILogger<DeleteSaleHandler> _logger;

        public DeleteSaleHandler(ISaleRepository saleRepository, ILogger<DeleteSaleHandler> logger)
        {
            _saleRepository = saleRepository;
            _logger = logger;
        }

        public async Task<DeleteSaleResult> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var success = await _saleRepository.DeleteAsync(request.SaleId);
            if (!success)
                throw new KeyNotFoundException($"User with ID {request.SaleId} not found");

            _logger.LogInformation($"Event: SaleCancelledEvent | SaleId: {request.SaleId}");
            return new DeleteSaleResult { SaleId = request.SaleId, Success = true };
        }
    }
} 
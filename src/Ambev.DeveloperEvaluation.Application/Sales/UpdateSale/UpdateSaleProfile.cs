using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleCommand, Sale>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<UpdateSaleItemDto, SaleItem>();
            CreateMap<Sale, UpdateSaleResult>()
                .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.Id));
            CreateMap<SaleItem, UpdateSaleItemResultDto>();
        }
    }
} 
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<CreateSaleItemDto, SaleItem>();
            CreateMap<Sale, CreateSaleResult>()
                .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.Id));
            CreateMap<SaleItem, CreateSaleItemResultDto>();
        }
    }
} 
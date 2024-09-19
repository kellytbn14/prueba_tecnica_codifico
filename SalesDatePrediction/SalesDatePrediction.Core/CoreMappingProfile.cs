using AutoMapper;
using SalesDatePrediction.Core.Models;
using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Core
{
    public class CoreMappingProfile : Profile
    {
        public CoreMappingProfile()
        {
            CreateMap<Order, CustomerOrderResponse>();
            CreateMap<Employee, EmployeeResponse>()
                .ForMember(dest => dest.FullName, opt =>
                opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<Shipper, ShipperResponse>();
            CreateMap<Product, ProductResponse>();
            CreateMap<CreateOrderRequest, Order>()
                .ForMember(m => m.Customer, p => p.Ignore())
                .ReverseMap();
            CreateMap<Order, OrderDto>();
        }
    }
}

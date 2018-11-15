using AutoMapper;
using XmasTreeApplication.Common.Entities;
using XmasTreeApplication.ViewModels;

namespace XmasTreeApplication.Data
{
    public class XmasTreeMappingProfile : Profile
    {
        public XmasTreeMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();
        }
    }
}
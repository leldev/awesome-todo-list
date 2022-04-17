using AutoMapper;
using Awesome.Datawarehouse.Api.Services.Models;

namespace Awesome.Datawarehouse.Api.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        this.CreateMap<Domain.DWTodo, GenericEventModel>().ReverseMap();
        this.CreateMap<Domain.DWTodo, DWTodoWriteModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId));
    }
}
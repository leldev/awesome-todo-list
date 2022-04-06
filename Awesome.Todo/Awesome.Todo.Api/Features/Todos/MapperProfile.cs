using AutoMapper;
using Awesome.Todo.Api.Features.Todos.Models;
using Awesome.Todo.Api.Services.MessageBusService.Models;

namespace Awesome.Todo.Api.Features.Todos;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        this.CreateMap<Domain.Todo, TodoReadModel>().ReverseMap();
        this.CreateMap<Domain.Todo, Create.CommandRequest>().ReverseMap();
        this.CreateMap<Domain.Todo, TodoWriteModel>().ReverseMap();
        this.CreateMap<Domain.Todo, TodoPublishModel>()
            .ForMember(d => d.Publisher, o => o.MapFrom(s => "Awesome.Todo.Publisher"))
            .ReverseMap();
    }
}

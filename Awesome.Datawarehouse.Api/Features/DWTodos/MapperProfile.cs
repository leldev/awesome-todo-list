using AutoMapper;
using Awesome.Datawarehouse.Api.Features.DWTodos.Models;

namespace Awesome.Datawarehouse.Api.Features.DWTodos;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        this.CreateMap<Domain.DWTodo, DWTodoReadModel>().ReverseMap();
    }
}
using AutoMapper;
using JalaTodoApi.Models;

namespace JalaTodoApi.Dtos.Mappings;

public class TodoMapping : Profile
{
    public TodoMapping()
    {
        CreateMap<CreateTodoDto, Todo>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate));

        CreateMap<UpdateTodoDto, Todo>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.Overdue, opt => opt.MapFrom(src => src.Overdue));
    }
}

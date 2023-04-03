using AutoMapper;
using ToDoList.DTO;
using ToDoList.model;

namespace ToDoList.Profiles
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDoItemDto, ToDoItem>()
                .ForMember(
                    dest => dest.Text,
                    opt => opt.MapFrom(src => $"{src.Text}")
                );

            CreateMap<ToDoItem, ToDoItemDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Text,
                    opt => opt.MapFrom(src => $"{src.Text}")
                );
        }
    }
}

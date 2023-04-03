using AutoMapper;
using ToDoList.DTO;
using ToDoList.model;

namespace ToDoList.Profiles
{
    public class DoneProfile : Profile
    {
           public DoneProfile()
           {
                CreateMap<DoneItemDto, DoneItem>()
                    .ForMember(
                        dest => dest.Text,
                        opt => opt.MapFrom(src => $"{src.Text}")
                    );
                CreateMap<DoneItem, DoneItemDto>()
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

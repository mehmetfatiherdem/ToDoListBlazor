using AutoMapper;
using ToDoList.DTO;
using ToDoList.model;

namespace ToDoList.Profiles
{
    public class DoingProfile : Profile
    {
        public DoingProfile()
        {
            CreateMap<DoingItemDto, DoingItem>()
                .ForMember(
                    dest => dest.Text,
                    opt => opt.MapFrom(src => $"{src.Text}")
                );

            CreateMap<DoingItem, DoingItemDto>()
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

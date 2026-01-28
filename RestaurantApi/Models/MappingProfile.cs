using AutoMapper;
using RestaurantApi.Models;
using RestaurantApi.DTOs;

namespace RestaurantApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // RegisterUserDto → User entity
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse<Role>(src.Role, true)))
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());

            // User → UserDto (response)
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        }
    }

}

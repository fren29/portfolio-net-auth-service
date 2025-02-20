using AutoMapper;
using PortfolioNetAuthService.Application.DTOs;
using PortfolioNetAuthService.Domain.Entities;

namespace PortfolioNetAuthService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }

}

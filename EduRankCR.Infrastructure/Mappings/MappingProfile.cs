using AutoMapper;
using EduRankCR.Application.DTOs;
using EduRankCR.Domain.Entities;

namespace EduRankCR.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
        }
    }
}
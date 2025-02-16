using AutoMapper;
using EduRankCR.Application.DTOs;
using EduRankCR.Application.DTOs.Response;
using EduRankCR.Domain.Entities;

namespace EduRankCR.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, ResponseUserDto>().ReverseMap();
            CreateMap<User, ResponseUserIdDto>().ReverseMap();
        }
    }
}
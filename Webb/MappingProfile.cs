using TddSocialNetwork.Model;
using AutoMapper;
using Webb.Dto;

namespace Webb
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();

            CreateMap<Post, PostDto>()
                .ReverseMap();
        }
    }
}
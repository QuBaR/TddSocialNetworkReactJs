using AutoMapper;
using TddSocialNetwork.Model;
using TddSocialNetwork.Web.Dto;

namespace TddSocialNetwork.Web
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TddSocialNetwork.Web.Dto;

namespace Webb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WallController : ControllerBase
    {
        [HttpGet]
        [Route("posts")]
        public async Task<ICollection<PostDto>> GetPosts()
        {
            var postsDto = new List<PostDto>();

            var user1 = new UserDto
            {
                Id = 1,
                Name = "Robert"
            };

            var post1 = new PostDto
            {
                Message = "Hello World",
                Created = DateTime.Now,
                Id = 1,
                User = user1
            };
            
            var user2 = new UserDto
            {
                Id = 1,
                Name = "Jon Doe"
            };

            var post2 = new PostDto
            {
                Message = "Good night",
                Created = DateTime.Now.AddDays(-30),
                Id = 1,
                User = user2
            };
            
            var user3 = new UserDto
            {
                Id = 1,
                Name = "Bruce Wayne"
            };

            var post3 = new PostDto
            {
                Message = "Whatz up",
                Created = DateTime.Now.AddMonths(12),
                Id = 1,
                User = user3
            };

            postsDto.Add(post1);
            postsDto.Add(post2);
            postsDto.Add(post3);

            return postsDto;
        }
    }
}

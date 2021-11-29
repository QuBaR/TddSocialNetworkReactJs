using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TddSocialNetwork.Data;
using TddSocialNetwork.Model;
using TddSocialNetwork.Web.Dto;

namespace TddSocialNetwork.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WallController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMapper _mapper;

        public WallController(ILogger<WeatherForecastController> logger,
            ApplicationDbContext context,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("posts")]
        public async Task<ICollection<PostDto>> GetPosts()
        {
            var postDto = await _context.Posts
                .Include(x => x.User)
                .Select(x => new PostDto()
                {
                    User = _mapper.Map<UserDto>(x.User),
                    Created = x.Created,
                    Id = x.Id,
                    Message = x.Message
                }).ToListAsync();


            return postDto;
        }
    }
}

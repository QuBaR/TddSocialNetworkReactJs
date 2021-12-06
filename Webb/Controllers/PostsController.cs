using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TddSocialNetwork.Data;
using TddSocialNetwork.Engine;
using TddSocialNetwork.Model;
using Webb.Dto;

namespace Webb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ISocialNetworkEngine _socialNetworkEngine;
        private readonly ILogger<PostsController> _logger;
        private readonly IMapper _mapper;


        public PostsController(
            ILogger<PostsController> logger, 
            IMapper mapper, 
            ISocialNetworkEngine socialNetworkEngine)
        {
            _logger = logger;
            _mapper = mapper;
            _socialNetworkEngine = socialNetworkEngine;
        }

        // GET: api/Posts
        [HttpGet("wall")]
        public async Task<ActionResult<IEnumerable<PostDto>>> Wall(string userName)
        {
            var posts = await _socialNetworkEngine.Wall(userName);
            return _mapper.Map<List<PostDto>> (posts);
        }

        //// GET: api/Posts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<PostDto>> GetPost(int id)
        //{
        //    var post = await _context
        //        .Posts
        //        .Include(x => x.User)
        //        .FirstOrDefaultAsync(x => x.Id == id);

        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return _mapper.Map<PostDto>(post);
        //}

        //// PUT: api/Posts/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPost(int id, Post post)
        //{
        //    if (id != post.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(post).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PostExists(id))
        //        {
        //            return NotFound();
        //        }

        //        throw;
        //    }

        //    return NoContent();
        //}

        //// POST: api/Posts
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PostDto>> PostPost(Post post)
        //{
        //    _context.Posts.Add(post);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPost", new { id = post.Id }, _mapper.Map<PostDto>(post));
        //}

        //// DELETE: api/Posts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePost(int id)
        //{
        //    var post = await _context.Posts.FindAsync(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Posts.Remove(post);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PostExists(int id)
        //{
        //    return _context.Posts.Any(e => e.Id == id);
        //}
    }
}

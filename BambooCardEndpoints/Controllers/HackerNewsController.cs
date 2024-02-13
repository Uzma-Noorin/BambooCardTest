using BambooCardTest.Models;
using BambooCardTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BambooCardEndpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackerNewsController : ControllerBase
    {
        protected IHackerNewsService _hackerNewsService;
        public HackerNewsController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet("TopNews/{n}")]
        public async Task<IEnumerable<Story>> GetTopStories(int n)
        {
            return await _hackerNewsService.GetTopStories(n) ;
        }
    }
}

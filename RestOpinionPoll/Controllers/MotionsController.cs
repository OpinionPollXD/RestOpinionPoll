using Microsoft.AspNetCore.Mvc;
using RestOpinionPoll.Models;
using RestOpinionPoll.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestOpinionPoll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotionsController : ControllerBase
    {
        private MotionsRepos repos;

        public MotionsController(MotionsRepos repository)
        {
            repos = repository;
        }

        // GET: api/<MotionsController>
        [HttpGet("GetAllMotions")]
        public IEnumerable<Motion> GetAllMotions()
        {
            return repos.GetAllMotions();
        }


        // POST api/<MotionsController>
        [HttpPost]
        public IActionResult Post([FromBody] Motion motion)
        {
            repos.AddMotion(motion);
            return Ok();
        }


    }
}

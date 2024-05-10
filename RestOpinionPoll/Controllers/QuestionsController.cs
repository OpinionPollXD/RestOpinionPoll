using Microsoft.AspNetCore.Mvc;
using RestOpinionPoll.Models;
using RestOpinionPoll.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestOpinionPoll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private QuestionsRepos repos;

        public QuestionsController(QuestionsRepos repository)
        {
            repos = repository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return repos.GetQuestions();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Question question)
        {
            repos.AddQuestion(question);
            return Ok();
        }

       
    }
}

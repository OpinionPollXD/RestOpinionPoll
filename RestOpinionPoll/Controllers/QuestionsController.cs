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

        [HttpPut]
        public IActionResult Put([FromBody] Question question)
        {
            var updatedQuestion = repos.UpdateQuestion(question);
            if (updatedQuestion == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedQuestion = repos.DeleteQuestion(id);
            if (deletedQuestion == null)
            {
                return NotFound();
            }
            return Ok();
        }

       
    }
}

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
        public IEnumerable<Question> Get([FromQuery] string? searchQuery)
        {
            return repos.GetQuestions(searchQuery);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Question question)
        {
            repos.AddQuestion(question);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id , [FromBody] Question question)
        {
            var updatedQuestion = repos.UpdateQuestion(id, question);
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

        [HttpPost("SubmitAnswer")]
        public IActionResult SubmitAnswer([FromBody] AnswerSubmission submission)
        {
            var question = repos.SubmitAnswer(submission.QuestionId, submission.Option);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpGet("GetActiveQuestions")]
        public IEnumerable<Question> GetActiveQuestions()
        {
            return repos.GetActiveQuestions();
        }



    }
}
